#!/bin/bash

echo "Corrigindo arquivos Volume X..."

for file in FormulaServiceVol10_*.cs; do
    # Pular Orchestrator e QuantumComputing (já corrigidos)
    if [[ "$file" == *"Orchestrator"* ]] || [[ "$file" == *"QuantumComputing"* ]]; then
        continue
    fi
    
    echo "Processando $file..."
    
    # Backup
    cp "$file" "${file}.bak"
    
    # 1. Corrigir Id de int para string: Id = 3610, → Id = "3610",
    sed -i -E 's/Id = ([0-9]+),/Id = "\1",/g' "$file"
    
    # 2. Remover linhas com Nivel
    sed -i '/Nivel = /d' "$file"
    
    # 3. ExemploUso → ExemploPratico
    sed -i 's/ExemploUso = /ExemploPratico = /g' "$file"
    
    # 4. Origem → Criador
    sed -i 's/Origem = /Criador = /g' "$file"
    
    # 5. AnoOrigem → AnoOrigin  
    sed -i 's/AnoOrigem = /AnoOrigin = /g' "$file"
    
    # 6. Valor → ValorPadrao em Variavel
    sed -i 's/Unidade = "", Valor = /Unidade = "", ValorPadrao = /g' "$file"
    sed -i 's/Unidade = ".*", Valor = /&/g; s/Valor = /ValorPadrao = /g' "$file"
    
    echo "  ✓ $file corrigido"
done

echo "Correções concluídas!"
