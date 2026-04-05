#!/usr/bin/env python3
"""
Prepare curated bibliographic batches for CompendioCalc ingestion.

What this tool does:
- Reads input records from .jsonl/.ndjson/.json/.csv (single file or directory)
- Validates required fields and variable schema
- Rejects duplicates by id and bibliographic key (referenciaBibliografica + fonteUrlOuDoi)
- Splits accepted records into output chunks (default: 10,000)
- Writes output .jsonl files to Data/BibliographicBatches
- Emits a JSON report with acceptance/rejection stats
"""

from __future__ import annotations

import argparse
import csv
import hashlib
import json
import re
import time
from collections import Counter
from datetime import datetime, timezone
from pathlib import Path
from typing import Iterable, Iterator, List, Set, Tuple

REQUIRED_FIELDS = [
    "id",
    "nome",
    "categoria",
    "subCategoria",
    "expressao",
    "descricao",
    "exemploPratico",
    "criador",
    "anoOrigin",
    "referenciaBibliografica",
    "fonteUrlOuDoi",
    "variavelResultado",
    "unidadeResultado",
    "variaveis",
]

REQUIRED_VARIABLE_FIELDS = [
    "simbolo",
    "nome",
    "descricao",
    "unidade",
    "valorPadrao",
]

SUPPORTED_EXTENSIONS = {".jsonl", ".ndjson", ".json", ".csv"}


def normalize_text(value: object) -> str:
    if value is None:
        return ""
    return str(value).strip()


def slugify_area(value: object) -> str:
    text = normalize_text(value).lower()
    if not text:
        return "sem-area"

    normalized = re.sub(r"[^a-z0-9]+", "-", text)
    normalized = normalized.strip("-")
    return normalized or "sem-area"


def bibliographic_key(record: dict) -> str:
    reference = normalize_text(record.get("referenciaBibliografica"))
    source = normalize_text(record.get("fonteUrlOuDoi"))
    if not reference or not source:
        return ""
    return f"{reference}||{source}".lower()


def find_calculation_expression(record: dict) -> str:
    expression = normalize_text(record.get("expressaoCalculo"))
    if expression:
        return expression

    base_expression = normalize_text(record.get("expressao"))
    if "=" in base_expression:
        return base_expression.split("=", 1)[1].strip()
    return ""


def validate_variable(variable: object) -> Tuple[bool, str]:
    if not isinstance(variable, dict):
        return False, "variavel-invalida"

    for field in REQUIRED_VARIABLE_FIELDS:
        value = variable.get(field)
        if field == "valorPadrao":
            if value is None:
                return False, "variaveis-incompletas"
            continue

        if not normalize_text(value):
            return False, "variaveis-incompletas"

    return True, ""


def validate_record(record: object) -> Tuple[bool, str]:
    if not isinstance(record, dict):
        return False, "registro-nao-json-objeto"

    for field in REQUIRED_FIELDS:
        value = record.get(field)
        if field == "variaveis":
            if not isinstance(value, list) or len(value) == 0:
                return False, "campos-obrigatorios-ausentes"
            continue

        if not normalize_text(value):
            return False, "campos-obrigatorios-ausentes"

    calc_expr = find_calculation_expression(record)
    if not calc_expr:
        return False, "expressao-calculo-ausente"

    if not isinstance(record.get("variaveis"), list):
        return False, "campos-obrigatorios-ausentes"

    for variable in record["variaveis"]:
        ok, reason = validate_variable(variable)
        if not ok:
            return False, reason

    return True, ""


def iter_input_records(path: Path) -> Iterator[dict]:
    extension = path.suffix.lower()
    if extension not in SUPPORTED_EXTENSIONS:
        raise ValueError(f"Unsupported input extension: {extension}")

    if extension == ".csv":
        with path.open("r", encoding="utf-8-sig", newline="") as handle:
            reader = csv.DictReader(handle)
            if not reader.fieldnames:
                yield {"_invalid_json": True}
                return

            for row in reader:
                variaveis_bruto = (row.get("variaveis") or row.get("variaveisJson") or "").strip()
                if not variaveis_bruto:
                    yield {"_invalid_json": True}
                    continue

                try:
                    variaveis_obj = json.loads(variaveis_bruto)
                except json.JSONDecodeError:
                    yield {"_invalid_json": True}
                    continue

                record: dict = {}
                for key, value in row.items():
                    if key is None:
                        continue
                    record[key] = value if value is not None else ""

                record["variaveis"] = variaveis_obj
                yield record
        return

    if extension in {".jsonl", ".ndjson"}:
        with path.open("r", encoding="utf-8") as handle:
            for line in handle:
                line = line.strip()
                if not line:
                    continue
                try:
                    data = json.loads(line)
                except json.JSONDecodeError:
                    yield {"_invalid_json": True}
                    continue

                if isinstance(data, dict):
                    yield data
                else:
                    yield {"_invalid_json": True}
        return

    with path.open("r", encoding="utf-8") as handle:
        try:
            data = json.load(handle)
        except json.JSONDecodeError:
            yield {"_invalid_json": True}
            return

    if not isinstance(data, list):
        yield {"_invalid_json": True}
        return

    for item in data:
        if isinstance(item, dict):
            yield item
        else:
            yield {"_invalid_json": True}


def collect_existing_uniqueness(output_dir: Path, exclude_files: Set[Path] | None = None) -> Tuple[set[str], set[str]]:
    known_ids: set[str] = set()
    known_keys: set[str] = set()

    if not output_dir.exists():
        return known_ids, known_keys

    excludes: Set[Path] = set()
    if exclude_files:
        excludes = {p.resolve() for p in exclude_files}

    for candidate in sorted(output_dir.rglob("*")):
        if not candidate.is_file():
            continue

        if excludes and candidate.resolve() in excludes:
            continue

        if candidate.suffix.lower() not in SUPPORTED_EXTENSIONS:
            continue
        if candidate.name.lower().startswith("readme"):
            continue

        for record in iter_input_records(candidate):
            if record.get("_invalid_json"):
                continue

            rec_id = normalize_text(record.get("id"))
            if rec_id:
                known_ids.add(rec_id.lower())

            key = bibliographic_key(record)
            if key:
                known_keys.add(key)

    return known_ids, known_keys


def next_batch_index(output_dir: Path) -> int:
    max_index = 0
    pattern = re.compile(r"^(\d{4})_")
    if not output_dir.exists():
        return 1

    for candidate in output_dir.iterdir():
        match = pattern.match(candidate.name)
        if match:
            max_index = max(max_index, int(match.group(1)))

    return max_index + 1


def chunk_records(records: List[dict], chunk_size: int) -> Iterable[List[dict]]:
    for start in range(0, len(records), chunk_size):
        yield records[start : start + chunk_size]


def write_jsonl(path: Path, records: List[dict]) -> None:
    with path.open("w", encoding="utf-8", newline="\n") as handle:
        for record in records:
            handle.write(json.dumps(record, ensure_ascii=False))
            handle.write("\n")


def default_checkpoint_path(output_dir: Path) -> Path:
    return output_dir / "prepare_checkpoint.json"


def default_history_path(output_dir: Path) -> Path:
    return output_dir / "prepare_history.json"


def file_sha256(path: Path) -> str:
    digest = hashlib.sha256()
    with path.open("rb") as handle:
        while True:
            chunk = handle.read(1024 * 1024)
            if not chunk:
                break
            digest.update(chunk)

    return digest.hexdigest()


def file_fingerprint(path: Path, include_content_hash: bool = False) -> dict:
    stat = path.stat()
    data = {
        "path": str(path.resolve().as_posix()),
        "size": int(stat.st_size),
        "mtimeNs": int(getattr(stat, "st_mtime_ns", int(stat.st_mtime * 1_000_000_000))),
    }

    if include_content_hash:
        data["contentSha256"] = file_sha256(path)

    return data


def load_checkpoint(path: Path) -> dict:
    if not path.exists():
        return {"version": 1, "files": {}}

    try:
        raw = json.loads(path.read_text(encoding="utf-8"))
    except Exception:
        return {"version": 1, "files": {}}

    if not isinstance(raw, dict):
        return {"version": 1, "files": {}}

    files = raw.get("files")
    if not isinstance(files, dict):
        raw["files"] = {}

    raw.setdefault("version", 1)
    return raw


def save_checkpoint(path: Path, data: dict) -> None:
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(json.dumps(data, ensure_ascii=False, indent=2), encoding="utf-8")


def is_checkpoint_match(entry: dict, fingerprint: dict) -> bool:
    if not isinstance(entry, dict):
        return False

    if not bool(entry.get("completed", False)):
        return False

    if str(entry.get("path", "")) != str(fingerprint.get("path", "")):
        return False

    entry_hash = normalize_text(entry.get("contentSha256"))
    current_hash = normalize_text(fingerprint.get("contentSha256"))
    if entry_hash and current_hash:
        return entry_hash == current_hash

    return (
        int(entry.get("size", -1)) == int(fingerprint.get("size", -2))
        and int(entry.get("mtimeNs", -1)) == int(fingerprint.get("mtimeNs", -2))
    )


def load_history(path: Path) -> dict:
    if not path.exists():
        return {
            "version": 1,
            "runCount": 0,
            "totals": {
                "read": 0,
                "accepted": 0,
                "rejected": 0,
                "skippedSourceCount": 0,
                "sourceCount": 0,
                "writtenFileCount": 0,
            },
            "runs": [],
        }

    try:
        raw = json.loads(path.read_text(encoding="utf-8"))
    except Exception:
        return load_history(Path("__nonexistent__"))

    if not isinstance(raw, dict):
        return load_history(Path("__nonexistent__"))

    raw.setdefault("version", 1)
    raw.setdefault("runCount", 0)
    raw.setdefault("totals", {})
    raw.setdefault("runs", [])
    return raw


def save_history(path: Path, data: dict) -> None:
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(json.dumps(data, ensure_ascii=False, indent=2), encoding="utf-8")


def append_history(history: dict, report: dict, max_runs: int) -> dict:
    totals = history.setdefault("totals", {})
    totals.setdefault("read", 0)
    totals.setdefault("accepted", 0)
    totals.setdefault("rejected", 0)
    totals.setdefault("skippedSourceCount", 0)
    totals.setdefault("sourceCount", 0)
    totals.setdefault("writtenFileCount", 0)

    totals["read"] += int(report.get("read", 0))
    totals["accepted"] += int(report.get("accepted", 0))
    totals["rejected"] += int(report.get("rejected", 0))
    totals["skippedSourceCount"] += int(report.get("skippedSourceCount", 0))
    totals["sourceCount"] += int(report.get("sourceCount", 0))
    totals["writtenFileCount"] += len(report.get("writtenFiles", []))

    history["runCount"] = int(history.get("runCount", 0)) + 1
    history["lastRunUtc"] = datetime.now(timezone.utc).isoformat()

    run_entry = {
        "runUtc": history["lastRunUtc"],
        "dryRun": bool(report.get("dryRun", False)),
        "read": int(report.get("read", 0)),
        "accepted": int(report.get("accepted", 0)),
        "rejected": int(report.get("rejected", 0)),
        "sourceCount": int(report.get("sourceCount", 0)),
        "skippedSourceCount": int(report.get("skippedSourceCount", 0)),
        "writtenFileCount": len(report.get("writtenFiles", [])),
        "input": report.get("input"),
        "inputDir": report.get("inputDir"),
        "glob": report.get("glob"),
    }

    runs = history.setdefault("runs", [])
    runs.append(run_entry)

    if max_runs > 0 and len(runs) > max_runs:
        del runs[:-max_runs]

    return history


def build_argument_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(description="Prepare bibliographic ingestion batches")
    group = parser.add_mutually_exclusive_group(required=True)
    group.add_argument("--input", help="Path to input .jsonl/.ndjson/.json/.csv file")
    group.add_argument("--input-dir", help="Directory containing source files")
    parser.add_argument(
        "--glob",
        default="*.jsonl,*.ndjson,*.json,*.csv",
        help="Comma-separated file patterns for --input-dir (default: *.jsonl,*.ndjson,*.json,*.csv)",
    )
    parser.add_argument(
        "--recursive",
        action="store_true",
        help="Use recursive search with --input-dir",
    )
    parser.add_argument(
        "--ignore-existing",
        action="store_true",
        help="Do not deduplicate against existing files in output-dir",
    )
    parser.add_argument(
        "--output-dir",
        default="Data/BibliographicBatches",
        help="Output directory for generated .jsonl batches",
    )
    parser.add_argument(
        "--chunk-size",
        type=int,
        default=10000,
        help="Records per output batch file (default: 10000)",
    )
    parser.add_argument(
        "--prefix",
        default="imported",
        help="File name suffix prefix after numeric index (default: imported)",
    )
    parser.add_argument(
        "--split-by-area",
        action="store_true",
        help="Write output batches separated by area (categoria) under subfolders",
    )
    parser.add_argument(
        "--area-root",
        default="areas",
        help="Subfolder name under output-dir used when --split-by-area is enabled (default: areas)",
    )
    parser.add_argument(
        "--report",
        default="",
        help="Optional report JSON path; defaults to <output-dir>/last_prepare_report.json",
    )
    parser.add_argument(
        "--dry-run",
        action="store_true",
        help="Validate and report without writing output files",
    )
    parser.add_argument(
        "--resume-checkpoint",
        action="store_true",
        help="Skip source files already completed with same file fingerprint",
    )
    parser.add_argument(
        "--write-checkpoint",
        action="store_true",
        help="Write/update checkpoint file with completed source file fingerprints",
    )
    parser.add_argument(
        "--reset-checkpoint",
        action="store_true",
        help="Clear checkpoint file before processing",
    )
    parser.add_argument(
        "--checkpoint-file",
        default="",
        help="Checkpoint JSON file path (default: <output-dir>/prepare_checkpoint.json)",
    )
    parser.add_argument(
        "--content-hash-checkpoint",
        action="store_true",
        help="Include SHA-256 content hash in checkpoint fingerprint (more robust than mtime)",
    )
    parser.add_argument(
        "--history-file",
        default="",
        help="History JSON path for accumulated totals (default: <output-dir>/prepare_history.json)",
    )
    parser.add_argument(
        "--disable-history",
        action="store_true",
        help="Disable accumulated history report updates",
    )
    parser.add_argument(
        "--history-max-runs",
        type=int,
        default=500,
        help="Maximum per-run entries to keep in history file (default: 500)",
    )
    parser.add_argument(
        "--watch-interval-seconds",
        type=int,
        default=0,
        help="Continuous mode interval in seconds (0 = single run)",
    )
    parser.add_argument(
        "--watch-max-iterations",
        type=int,
        default=0,
        help="Stop continuous mode after N iterations (0 = unlimited)",
    )
    parser.add_argument(
        "--watch-idle-exit-count",
        type=int,
        default=0,
        help="Stop continuous mode after N consecutive idle iterations (0 = disabled)",
    )
    return parser


def resolve_source_files(args: argparse.Namespace, parser: argparse.ArgumentParser) -> List[Path]:
    source_files: List[Path] = []
    if args.input:
        input_path = Path(args.input)
        if not input_path.exists():
            parser.error(f"Input file not found: {input_path}")
        source_files = [input_path]
    else:
        input_dir = Path(args.input_dir)
        if not input_dir.exists() or not input_dir.is_dir():
            parser.error(f"Input directory not found: {input_dir}")

        patterns = [p.strip() for p in (args.glob or "").split(",") if p.strip()]
        if not patterns:
            parser.error("--glob must include at least one pattern")

        found: Set[Path] = set()
        for pattern in patterns:
            iterator = input_dir.rglob(pattern) if args.recursive else input_dir.glob(pattern)
            for candidate in iterator:
                if candidate.is_file() and candidate.suffix.lower() in SUPPORTED_EXTENSIONS:
                    found.add(candidate)

        source_files = sorted(found)
        if not source_files:
            parser.error("No input files matched --input-dir and --glob")

    return source_files


def run_once(
    args: argparse.Namespace,
    parser: argparse.ArgumentParser,
    output_dir: Path,
    checkpoint_requested: bool,
    checkpoint_path: Path,
    checkpoint_data: dict,
) -> tuple[dict, dict]:
    source_files = resolve_source_files(args, parser)

    if args.ignore_existing:
        known_ids, known_keys = set(), set()
    else:
        known_ids, known_keys = collect_existing_uniqueness(output_dir, exclude_files=set(source_files))

    stats = Counter()
    reject_reasons = Counter()
    accepted: List[dict] = []
    per_source: List[dict] = []
    skipped_sources: List[str] = []
    checkpoint_files = checkpoint_data.setdefault("files", {})

    for source in source_files:
        fingerprint = file_fingerprint(source, include_content_hash=bool(args.content_hash_checkpoint and checkpoint_requested))
        if args.resume_checkpoint:
            prior = checkpoint_files.get(fingerprint["path"])
            if is_checkpoint_match(prior, fingerprint):
                skipped_sources.append(str(source.as_posix()))
                continue

        source_stats = Counter()
        source_rejects = Counter()

        for record in iter_input_records(source):
            stats["read"] += 1
            source_stats["read"] += 1

            if record.get("_invalid_json"):
                reject_reasons["json-invalido"] += 1
                source_rejects["json-invalido"] += 1
                continue

            ok, reason = validate_record(record)
            if not ok:
                reject_reasons[reason] += 1
                source_rejects[reason] += 1
                continue

            rec_id = normalize_text(record.get("id")).lower()
            key = bibliographic_key(record)

            if not rec_id or rec_id in known_ids:
                reject_reasons["id-duplicado-ou-vazio"] += 1
                source_rejects["id-duplicado-ou-vazio"] += 1
                continue

            if not key or key in known_keys:
                reject_reasons["chave-bibliografica-duplicada-ou-vazia"] += 1
                source_rejects["chave-bibliografica-duplicada-ou-vazia"] += 1
                continue

            known_ids.add(rec_id)
            known_keys.add(key)
            accepted.append(record)
            stats["accepted"] += 1
            source_stats["accepted"] += 1

        source_stats["rejected"] = source_stats["read"] - source_stats["accepted"]
        per_source.append(
            {
                "source": str(source.as_posix()),
                "read": int(source_stats["read"]),
                "accepted": int(source_stats["accepted"]),
                "rejected": int(source_stats["rejected"]),
                "rejectReasons": dict(sorted(source_rejects.items(), key=lambda kv: (-kv[1], kv[0]))),
            }
        )

        if checkpoint_requested:
            checkpoint_files[fingerprint["path"]] = {
                **fingerprint,
                "completed": True,
                "read": int(source_stats["read"]),
                "accepted": int(source_stats["accepted"]),
                "rejected": int(source_stats["rejected"]),
                "processedAtUtc": datetime.now(timezone.utc).isoformat(),
            }

    stats["rejected"] = stats["read"] - stats["accepted"]

    written_files: List[str] = []
    written_areas: dict[str, int] = {}
    if not args.dry_run and accepted:
        if args.split_by_area:
            area_root = output_dir / args.area_root
            grouped: dict[str, List[dict]] = {}
            for record in accepted:
                area = normalize_text(record.get("categoria")) or "SemArea"
                grouped.setdefault(area, []).append(record)

            for area in sorted(grouped.keys(), key=lambda x: x.lower()):
                records_area = grouped[area]
                area_slug = slugify_area(area)
                area_dir = area_root / area_slug
                area_dir.mkdir(parents=True, exist_ok=True)
                batch_index = next_batch_index(area_dir)

                for chunk_number, records in enumerate(chunk_records(records_area, args.chunk_size), start=1):
                    filename = f"{batch_index:04d}_{args.prefix}_{chunk_number:03d}.jsonl"
                    destination = area_dir / filename
                    write_jsonl(destination, records)
                    written_files.append(str(destination.as_posix()))
                    written_areas[area] = written_areas.get(area, 0) + len(records)
                    batch_index += 1
        else:
            batch_index = next_batch_index(output_dir)
            for chunk_number, records in enumerate(chunk_records(accepted, args.chunk_size), start=1):
                filename = f"{batch_index:04d}_{args.prefix}_{chunk_number:03d}.jsonl"
                destination = output_dir / filename
                write_jsonl(destination, records)
                written_files.append(str(destination.as_posix()))
                batch_index += 1

    report = {
        "input": str(Path(args.input).as_posix()) if args.input else None,
        "inputDir": str(Path(args.input_dir).as_posix()) if args.input_dir else None,
        "glob": args.glob,
        "recursive": bool(args.recursive),
        "sourceCount": len(source_files),
        "sources": [str(p.as_posix()) for p in source_files],
        "skippedSourceCount": len(skipped_sources),
        "skippedSources": skipped_sources,
        "outputDir": str(output_dir.as_posix()),
        "chunkSize": args.chunk_size,
        "dryRun": bool(args.dry_run),
        "ignoreExisting": bool(args.ignore_existing),
        "read": int(stats["read"]),
        "accepted": int(stats["accepted"]),
        "rejected": int(stats["rejected"]),
        "perSource": per_source,
        "rejectReasons": dict(sorted(reject_reasons.items(), key=lambda kv: (-kv[1], kv[0]))),
        "writtenFiles": written_files,
        "splitByArea": bool(args.split_by_area),
        "areaRoot": args.area_root if args.split_by_area else None,
        "writtenAreas": dict(sorted(written_areas.items(), key=lambda kv: kv[0].lower())),
        "checkpoint": {
            "enabled": bool(checkpoint_requested),
            "resume": bool(args.resume_checkpoint),
            "write": bool(args.write_checkpoint),
            "reset": bool(args.reset_checkpoint),
            "file": str(checkpoint_path.as_posix()) if checkpoint_requested else None,
            "contentHash": bool(args.content_hash_checkpoint),
        },
    }

    return report, checkpoint_data


def main() -> int:
    parser = build_argument_parser()
    args = parser.parse_args()

    output_dir = Path(args.output_dir)
    output_dir.mkdir(parents=True, exist_ok=True)

    if args.chunk_size <= 0:
        parser.error("--chunk-size must be > 0")
    if args.watch_interval_seconds < 0:
        parser.error("--watch-interval-seconds must be >= 0")
    if args.watch_max_iterations < 0:
        parser.error("--watch-max-iterations must be >= 0")
    if args.watch_idle_exit_count < 0:
        parser.error("--watch-idle-exit-count must be >= 0")

    if args.dry_run and args.write_checkpoint:
        parser.error("--write-checkpoint cannot be used together with --dry-run")

    if args.watch_interval_seconds > 0 and args.dry_run:
        parser.error("--watch-interval-seconds cannot be used with --dry-run")

    if args.watch_interval_seconds > 0:
        args.resume_checkpoint = True
        args.write_checkpoint = True

    checkpoint_requested = args.resume_checkpoint or args.write_checkpoint or args.reset_checkpoint or bool(args.checkpoint_file)
    checkpoint_path = Path(args.checkpoint_file) if args.checkpoint_file else default_checkpoint_path(output_dir)
    checkpoint_data = {"version": 1, "files": {}}
    if checkpoint_requested:
        checkpoint_data = load_checkpoint(checkpoint_path)
        if args.reset_checkpoint:
            checkpoint_data = {"version": 1, "files": {}}

    history_enabled = not args.disable_history
    history_path = Path(args.history_file) if args.history_file else default_history_path(output_dir)
    history_data = load_history(history_path) if history_enabled else {}

    iteration = 0
    idle_streak = 0
    iteration_summaries: List[dict] = []
    final_report: dict = {}

    while True:
        iteration += 1
        report, checkpoint_data = run_once(args, parser, output_dir, checkpoint_requested, checkpoint_path, checkpoint_data)
        final_report = report

        if checkpoint_requested and args.write_checkpoint:
            save_checkpoint(checkpoint_path, checkpoint_data)

        if history_enabled:
            history_data = append_history(history_data, report, max_runs=max(0, args.history_max_runs))
            save_history(history_path, history_data)
            report["history"] = {
                "enabled": True,
                "file": str(history_path.as_posix()),
                "runCount": int(history_data.get("runCount", 0)),
                "totals": history_data.get("totals", {}),
            }
        else:
            report["history"] = {"enabled": False, "file": None}

        processed_sources = int(report.get("sourceCount", 0)) - int(report.get("skippedSourceCount", 0))
        is_idle = processed_sources <= 0 and int(report.get("read", 0)) == 0 and len(report.get("writtenFiles", [])) == 0
        idle_streak = idle_streak + 1 if is_idle else 0

        iteration_summaries.append(
            {
                "iteration": iteration,
                "read": int(report.get("read", 0)),
                "accepted": int(report.get("accepted", 0)),
                "rejected": int(report.get("rejected", 0)),
                "sourceCount": int(report.get("sourceCount", 0)),
                "skippedSourceCount": int(report.get("skippedSourceCount", 0)),
                "writtenFileCount": len(report.get("writtenFiles", [])),
                "idle": bool(is_idle),
            }
        )

        if args.watch_interval_seconds <= 0:
            break
        if args.watch_max_iterations > 0 and iteration >= args.watch_max_iterations:
            break
        if args.watch_idle_exit_count > 0 and idle_streak >= args.watch_idle_exit_count:
            break

        time.sleep(args.watch_interval_seconds)

    report_path = Path(args.report) if args.report else output_dir / "last_prepare_report.json"

    if args.watch_interval_seconds > 0:
        final_output = {
            "mode": "continuous",
            "watchIntervalSeconds": args.watch_interval_seconds,
            "watchMaxIterations": args.watch_max_iterations,
            "watchIdleExitCount": args.watch_idle_exit_count,
            "iterations": iteration_summaries,
            "lastReport": final_report,
        }
        report_path.parent.mkdir(parents=True, exist_ok=True)
        report_path.write_text(json.dumps(final_output, ensure_ascii=False, indent=2), encoding="utf-8")
        print(json.dumps(final_output, ensure_ascii=False, indent=2))
        return 0

    report_path.parent.mkdir(parents=True, exist_ok=True)
    report_path.write_text(json.dumps(final_report, ensure_ascii=False, indent=2), encoding="utf-8")
    print(json.dumps(final_report, ensure_ascii=False, indent=2))
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
