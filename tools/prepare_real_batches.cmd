@echo off
setlocal

if "%~1"=="" (
  echo Uso:
  echo   tools\prepare_real_batches.cmd ^<input_file_ou_dir^> [prefixo] [chunk_size] [--dry-run] [glob] [--recursive] [--resume-checkpoint] [--write-checkpoint] [--reset-checkpoint]
  echo Exemplo:
  echo   tools\prepare_real_batches.cmd C:\dados\base_real.jsonl real 10000 --dry-run
  echo   tools\prepare_real_batches.cmd C:\dados\lotes real 10000 --dry-run "*.jsonl,*.csv" --recursive
  echo   tools\prepare_real_batches.cmd C:\dados\lotes real 10000 --dry-run "*.jsonl,*.csv" --recursive --resume-checkpoint
  exit /b 1
)

set INPUT=%~1
set INPUT_ABS=%~f1
set INPUT_ATTR=%~a1
set PREFIX=%~2
set CHUNK=%~3
set DRY=%~4
set GLOB=%~5
set RECURSIVE=%~6
set CHECKPOINT_RESUME=%~7
set CHECKPOINT_WRITE=%~8
set CHECKPOINT_RESET=%~9

if "%PREFIX%"=="" set PREFIX=real
if "%CHUNK%"=="" set CHUNK=10000
if "%GLOB%"=="" set GLOB=*.jsonl,*.ndjson,*.json,*.csv

if /I "%INPUT_ATTR:~0,1%"=="d" (
  set CMD=python tools/prepare_bibliographic_batches.py --input-dir "%INPUT_ABS%" --glob "%GLOB%" --output-dir Data/BibliographicBatches --chunk-size %CHUNK% --prefix %PREFIX%
) else (
  set CMD=python tools/prepare_bibliographic_batches.py --input "%INPUT_ABS%" --output-dir Data/BibliographicBatches --chunk-size %CHUNK% --prefix %PREFIX%
)

if /I "%DRY%"=="--dry-run" (
  set CMD=%CMD% --dry-run
)

if /I "%RECURSIVE%"=="--recursive" (
  set CMD=%CMD% --recursive
)

if /I "%CHECKPOINT_RESUME%"=="--resume-checkpoint" (
  set CMD=%CMD% --resume-checkpoint
)

if /I "%CHECKPOINT_WRITE%"=="--write-checkpoint" (
  set CMD=%CMD% --write-checkpoint
)

if /I "%CHECKPOINT_RESET%"=="--reset-checkpoint" (
  set CMD=%CMD% --reset-checkpoint
)

echo Executando:
 echo %CMD%
%CMD%

endlocal
