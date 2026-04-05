# Bibliographic Batch Ingestion

Place curated formula batches in this folder using `.jsonl`, `.ndjson`, `.json`, or `.csv`.

## Required fields per formula record

- `id`
- `nome`
- `categoria`
- `subCategoria`
- `expressao`
- `expressaoCalculo` (or an `expressao` with `=` so the right side can be used)
- `descricao`
- `exemploPratico`
- `criador`
- `anoOrigin`
- `referenciaBibliografica`
- `fonteUrlOuDoi`
- `variavelResultado`
- `unidadeResultado`
- `variaveis` (non-empty)

Each variable must include:

- `simbolo`
- `nome`
- `descricao`
- `unidade`
- `valorPadrao`

Optional:

- `codigoCompendio`
- `exprTexto`
- `procedencia`
- `statusCuradoria`
- `unidades`
- `icone`
- `variaveis[].valorMin`
- `variaveis[].valorMax`
- `variaveis[].obrigatoria`

## Uniqueness and quality rules

- No synthetic formulas are accepted.
- Bibliographic key must be unique globally: `referenciaBibliografica + fonteUrlOuDoi`.
- Formula `id` must be unique globally.
- Incomplete records are ignored.
- `calcular` is generated from `expressaoCalculo` by a safe math parser.

## Block execution

The service runs ingestion in blocks of 10,000 records and stops when reaching the total target.

## Preparing large real datasets before ingestion

Use the helper script to validate, deduplicate, and split external curated sources into ready-to-ingest files.

Script: `tools/prepare_bibliographic_batches.py`

Windows (PowerShell) - dry run:

```powershell
python tools/prepare_bibliographic_batches.py `
	--input C:/dados/base_real.jsonl `
	--output-dir Data/BibliographicBatches `
	--chunk-size 10000 `
	--prefix real `
	--dry-run
```

Windows (PowerShell) - generate files:

```powershell
python tools/prepare_bibliographic_batches.py `
	--input C:/dados/base_real.jsonl `
	--output-dir Data/BibliographicBatches `
	--chunk-size 10000 `
	--prefix real
```

Windows (PowerShell) - processar pasta inteira:

```powershell
python tools/prepare_bibliographic_batches.py `
	--input-dir C:/dados/lotes `
	--glob "*.jsonl,*.csv" `
	--recursive `
	--output-dir Data/BibliographicBatches `
	--chunk-size 10000 `
	--prefix real `
	--dry-run
```

Example dry run (validation only):

```bash
python tools/prepare_bibliographic_batches.py \
	--input caminho/para/base_real.jsonl \
	--output-dir Data/BibliographicBatches \
	--chunk-size 10000 \
	--prefix real \
	--dry-run
```

Generate files:

```bash
python tools/prepare_bibliographic_batches.py \
	--input caminho/para/base_real.jsonl \
	--output-dir Data/BibliographicBatches \
	--chunk-size 10000 \
	--prefix real
```

Generate files split by area (categoria):

```bash
python tools/prepare_bibliographic_batches.py \
	--input caminho/para/base_real.jsonl \
	--output-dir Data/BibliographicBatches \
	--chunk-size 10000 \
	--prefix real \
	--split-by-area
```

With `--split-by-area`, output structure is:

- `Data/BibliographicBatches/areas/<area-slug>/0001_real_001.jsonl`
- `Data/BibliographicBatches/areas/<area-slug>/0002_real_001.jsonl`

Generate files from a directory:

```bash
python tools/prepare_bibliographic_batches.py \
	--input-dir caminho/para/lotes \
	--glob "*.jsonl,*.ndjson,*.json,*.csv" \
	--recursive \
	--output-dir Data/BibliographicBatches \
	--chunk-size 10000 \
	--prefix real \
	--split-by-area
```

## Checkpoint mode (incremental runs)

Use checkpoint mode to skip files already processed in previous runs (same path + size + modification time).

Directory run with checkpoint resume:

```bash
python tools/prepare_bibliographic_batches.py \
	--input-dir caminho/para/lotes \
	--glob "*.jsonl,*.csv" \
	--recursive \
	--output-dir Data/BibliographicBatches \
	--chunk-size 10000 \
	--prefix real \
	--resume-checkpoint \
	--write-checkpoint
```

Reset checkpoint and start fresh:

```bash
python tools/prepare_bibliographic_batches.py \
	--input-dir caminho/para/lotes \
	--glob "*.jsonl,*.csv" \
	--recursive \
	--output-dir Data/BibliographicBatches \
	--chunk-size 10000 \
	--prefix real \
	--reset-checkpoint \
	--write-checkpoint
```

Custom checkpoint file:

```bash
python tools/prepare_bibliographic_batches.py \
	--input-dir caminho/para/lotes \
	--glob "*.jsonl,*.csv" \
	--output-dir Data/BibliographicBatches \
	--prefix real \
	--resume-checkpoint \
	--write-checkpoint \
	--checkpoint-file Data/BibliographicBatches/meu_checkpoint.json
```

Note: `tools/prepare_real_batches.cmd` supports checkpoint flags (`--resume-checkpoint`, `--write-checkpoint`, `--reset-checkpoint`) and uses the default checkpoint path. For a custom checkpoint file, use the Python command directly.

## Content hash in checkpoint (more robust)

To avoid relying only on `mtime`, enable SHA-256 content hash in the checkpoint fingerprint:

```bash
python tools/prepare_bibliographic_batches.py \
	--input-dir caminho/para/lotes \
	--glob "*.jsonl,*.csv" \
	--recursive \
	--output-dir Data/BibliographicBatches \
	--prefix real \
	--resume-checkpoint \
	--write-checkpoint \
	--content-hash-checkpoint
```

## Accumulated history report

By default, each run updates an accumulated history file at:

- `Data/BibliographicBatches/prepare_history.json`

History stores cumulative totals (`read`, `accepted`, `rejected`) and per-run summaries.

You can customize/disable it:

```bash
# Custom history file
python tools/prepare_bibliographic_batches.py \
	--input caminho/para/base_real.jsonl \
	--output-dir Data/BibliographicBatches \
	--prefix real \
	--history-file Data/BibliographicBatches/minha_historico.json

# Disable history updates
python tools/prepare_bibliographic_batches.py \
	--input caminho/para/base_real.jsonl \
	--output-dir Data/BibliographicBatches \
	--prefix real \
	--disable-history
```

## Continuous mode (new files by interval)

Continuous mode reruns automatically every N seconds and is ideal for incremental ingestion as new files arrive.

```bash
python tools/prepare_bibliographic_batches.py \
	--input-dir caminho/para/lotes \
	--glob "*.jsonl,*.csv" \
	--recursive \
	--output-dir Data/BibliographicBatches \
	--chunk-size 10000 \
	--prefix real \
	--watch-interval-seconds 30 \
	--watch-idle-exit-count 5 \
	--content-hash-checkpoint
```

Useful continuous mode controls:

- `--watch-max-iterations N`: stop after N loops
- `--watch-idle-exit-count N`: stop after N idle loops
- `--watch-interval-seconds N`: seconds between loops

## Important note about reaching 1,000,000

This pipeline does not generate synthetic/procedural formulas.
To reach 1,000,000, you must provide a real bibliographic corpus with unique `referenciaBibliografica + fonteUrlOuDoi` keys.

What this guarantees before files enter the app pipeline:

- required schema is present
- each `id` is unique
- each bibliographic key (`referenciaBibliografica + fonteUrlOuDoi`) is unique
- output is chunked as `.jsonl` files with sequential numeric prefixes
- a JSON report is generated with rejection reasons and accepted counts

## CSV input format

If your source is CSV, use these headers for required fields:

- `id`
- `nome`
- `categoria`
- `subCategoria`
- `expressao`
- `expressaoCalculo` (optional if `expressao` has `=`)
- `descricao`
- `exemploPratico`
- `criador`
- `anoOrigin`
- `referenciaBibliografica`
- `fonteUrlOuDoi`
- `variavelResultado`
- `unidadeResultado`
- `variaveis` (or `variaveisJson`)

For CSV, `variaveis` must be a JSON array string, for example:

```json
[{"simbolo":"x","nome":"Variavel x","descricao":"Entrada x","unidade":"adim","valorPadrao":1.0}]
```