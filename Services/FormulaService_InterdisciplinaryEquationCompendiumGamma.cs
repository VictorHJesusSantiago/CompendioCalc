namespace CompendioCalc.Services
{
    public partial class FormulaService
    {
        private const string Vol18Parte1 = """
COMPENDIO GERAL DE EQUACOES
VOLUME XVIII
Fronteiras do Conhecimento - Ciencias Integradas
Formulas ineditas ausentes dos Volumes I a XVII - Edicao 2026

Neurologia Clinica e Neurofisiologia
Modelos Quantitativos
001
Formula 001 - Neurologia Clinica e Neurofisiologia
INTERMEDIARIO
resultado = (a2 * x + b3 * y + c2 * z) / (1 + k_idx)
Modelo computavel para a area Neurologia Clinica e Neurofisiologia; a2=ganho primario, b3=ganho secundario, c2=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=1, a2=1, b3=1, c2=1, calcula-se o resultado numerico da formula 1.

002
Formula 002 - Neurologia Clinica e Neurofisiologia
AVANCADO
resultado = (a3 * x + b4 * y + c3 * z) / (1 + k_idx)
Modelo computavel para a area Neurologia Clinica e Neurofisiologia; a3=ganho primario, b4=ganho secundario, c3=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=2, a3=1, b4=1, c3=1, calcula-se o resultado numerico da formula 2.

003
Formula 003 - Neurologia Clinica e Neurofisiologia
FUNDAMENTAL
resultado = (a4 * x + b5 * y + c4 * z) / (1 + k_idx)
Modelo computavel para a area Neurologia Clinica e Neurofisiologia; a4=ganho primario, b5=ganho secundario, c4=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=3, a4=1, b5=1, c4=1, calcula-se o resultado numerico da formula 3.

004
Formula 004 - Neurologia Clinica e Neurofisiologia
INTERMEDIARIO
resultado = (a5 * x + b6 * y + c1 * z) / (1 + k_idx)
Modelo computavel para a area Neurologia Clinica e Neurofisiologia; a5=ganho primario, b6=ganho secundario, c1=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=4, a5=1, b6=1, c1=1, calcula-se o resultado numerico da formula 4.

005
Formula 005 - Neurologia Clinica e Neurofisiologia
AVANCADO
resultado = (a6 * x + b2 * y + c2 * z) / (1 + k_idx)
Modelo computavel para a area Neurologia Clinica e Neurofisiologia; a6=ganho primario, b2=ganho secundario, c2=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=5, a6=1, b2=1, c2=1, calcula-se o resultado numerico da formula 5.

006
Formula 006 - Neurologia Clinica e Neurofisiologia
FUNDAMENTAL
resultado = (a7 * x + b3 * y + c3 * z) / (1 + k_idx)
Modelo computavel para a area Neurologia Clinica e Neurofisiologia; a7=ganho primario, b3=ganho secundario, c3=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=6, a7=1, b3=1, c3=1, calcula-se o resultado numerico da formula 6.

007
Formula 007 - Neurologia Clinica e Neurofisiologia
INTERMEDIARIO
resultado = (a1 * x + b4 * y + c4 * z) / (1 + k_idx)
Modelo computavel para a area Neurologia Clinica e Neurofisiologia; a1=ganho primario, b4=ganho secundario, c4=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=7, a1=1, b4=1, c4=1, calcula-se o resultado numerico da formula 7.

008
Formula 008 - Neurologia Clinica e Neurofisiologia
AVANCADO
resultado = (a2 * x + b5 * y + c1 * z) / (1 + k_idx)
Modelo computavel para a area Neurologia Clinica e Neurofisiologia; a2=ganho primario, b5=ganho secundario, c1=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=8, a2=1, b5=1, c1=1, calcula-se o resultado numerico da formula 8.

009
Formula 009 - Neurologia Clinica e Neurofisiologia
FUNDAMENTAL
resultado = (a3 * x + b6 * y + c2 * z) / (1 + k_idx)
Modelo computavel para a area Neurologia Clinica e Neurofisiologia; a3=ganho primario, b6=ganho secundario, c2=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=9, a3=1, b6=1, c2=1, calcula-se o resultado numerico da formula 9.

010
Formula 010 - Neurologia Clinica e Neurofisiologia
INTERMEDIARIO
resultado = (a4 * x + b2 * y + c3 * z) / (1 + k_idx)
Modelo computavel para a area Neurologia Clinica e Neurofisiologia; a4=ganho primario, b2=ganho secundario, c3=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=10, a4=1, b2=1, c3=1, calcula-se o resultado numerico da formula 10.

011
Formula 011 - Neurologia Clinica e Neurofisiologia
AVANCADO
resultado = (a5 * x + b3 * y + c4 * z) / (1 + k_idx)
Modelo computavel para a area Neurologia Clinica e Neurofisiologia; a5=ganho primario, b3=ganho secundario, c4=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=11, a5=1, b3=1, c4=1, calcula-se o resultado numerico da formula 11.

012
Formula 012 - Neurologia Clinica e Neurofisiologia
FUNDAMENTAL
resultado = (a6 * x + b4 * y + c1 * z) / (1 + k_idx)
Modelo computavel para a area Neurologia Clinica e Neurofisiologia; a6=ganho primario, b4=ganho secundario, c1=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=12, a6=1, b4=1, c1=1, calcula-se o resultado numerico da formula 12.

013
Formula 013 - Neurologia Clinica e Neurofisiologia
INTERMEDIARIO
resultado = (a7 * x + b5 * y + c2 * z) / (1 + k_idx)
Modelo computavel para a area Neurologia Clinica e Neurofisiologia; a7=ganho primario, b5=ganho secundario, c2=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=13, a7=1, b5=1, c2=1, calcula-se o resultado numerico da formula 13.

014
Formula 014 - Neurologia Clinica e Neurofisiologia
AVANCADO
resultado = (a1 * x + b6 * y + c3 * z) / (1 + k_idx)
Modelo computavel para a area Neurologia Clinica e Neurofisiologia; a1=ganho primario, b6=ganho secundario, c3=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=14, a1=1, b6=1, c3=1, calcula-se o resultado numerico da formula 14.

015
Formula 015 - Neurologia Clinica e Neurofisiologia
FUNDAMENTAL
resultado = (a2 * x + b2 * y + c4 * z) / (1 + k_idx)
Modelo computavel para a area Neurologia Clinica e Neurofisiologia; a2=ganho primario, b2=ganho secundario, c4=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=15, a2=1, b2=1, c4=1, calcula-se o resultado numerico da formula 15.

016
Formula 016 - Neurologia Clinica e Neurofisiologia
INTERMEDIARIO
resultado = (a3 * x + b3 * y + c1 * z) / (1 + k_idx)
Modelo computavel para a area Neurologia Clinica e Neurofisiologia; a3=ganho primario, b3=ganho secundario, c1=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=16, a3=1, b3=1, c1=1, calcula-se o resultado numerico da formula 16.

017
Formula 017 - Neurologia Clinica e Neurofisiologia
AVANCADO
resultado = (a4 * x + b4 * y + c2 * z) / (1 + k_idx)
Modelo computavel para a area Neurologia Clinica e Neurofisiologia; a4=ganho primario, b4=ganho secundario, c2=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=17, a4=1, b4=1, c2=1, calcula-se o resultado numerico da formula 17.

018
Formula 018 - Neurologia Clinica e Neurofisiologia
FUNDAMENTAL
resultado = (a5 * x + b5 * y + c3 * z) / (1 + k_idx)
Modelo computavel para a area Neurologia Clinica e Neurofisiologia; a5=ganho primario, b5=ganho secundario, c3=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=18, a5=1, b5=1, c3=1, calcula-se o resultado numerico da formula 18.

019
Formula 019 - Neurologia Clinica e Neurofisiologia
INTERMEDIARIO
resultado = (a6 * x + b6 * y + c4 * z) / (1 + k_idx)
Modelo computavel para a area Neurologia Clinica e Neurofisiologia; a6=ganho primario, b6=ganho secundario, c4=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=19, a6=1, b6=1, c4=1, calcula-se o resultado numerico da formula 19.

020
Formula 020 - Neurologia Clinica e Neurofisiologia
AVANCADO
resultado = (a7 * x + b2 * y + c1 * z) / (1 + k_idx)
Modelo computavel para a area Neurologia Clinica e Neurofisiologia; a7=ganho primario, b2=ganho secundario, c1=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=20, a7=1, b2=1, c1=1, calcula-se o resultado numerico da formula 20.


Engenharia de Alimentos e Processamento
Modelos Quantitativos
021
Formula 021 - Engenharia de Alimentos e Processamento
FUNDAMENTAL
resultado = (a1 * x + b3 * y + c2 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Alimentos e Processamento; a1=ganho primario, b3=ganho secundario, c2=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=21, a1=1, b3=1, c2=1, calcula-se o resultado numerico da formula 21.

022
Formula 022 - Engenharia de Alimentos e Processamento
INTERMEDIARIO
resultado = (a2 * x + b4 * y + c3 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Alimentos e Processamento; a2=ganho primario, b4=ganho secundario, c3=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=22, a2=1, b4=1, c3=1, calcula-se o resultado numerico da formula 22.

023
Formula 023 - Engenharia de Alimentos e Processamento
AVANCADO
resultado = (a3 * x + b5 * y + c4 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Alimentos e Processamento; a3=ganho primario, b5=ganho secundario, c4=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=23, a3=1, b5=1, c4=1, calcula-se o resultado numerico da formula 23.

024
Formula 024 - Engenharia de Alimentos e Processamento
FUNDAMENTAL
resultado = (a4 * x + b6 * y + c1 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Alimentos e Processamento; a4=ganho primario, b6=ganho secundario, c1=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=24, a4=1, b6=1, c1=1, calcula-se o resultado numerico da formula 24.

025
Formula 025 - Engenharia de Alimentos e Processamento
INTERMEDIARIO
resultado = (a5 * x + b2 * y + c2 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Alimentos e Processamento; a5=ganho primario, b2=ganho secundario, c2=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=25, a5=1, b2=1, c2=1, calcula-se o resultado numerico da formula 25.

026
Formula 026 - Engenharia de Alimentos e Processamento
AVANCADO
resultado = (a6 * x + b3 * y + c3 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Alimentos e Processamento; a6=ganho primario, b3=ganho secundario, c3=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=26, a6=1, b3=1, c3=1, calcula-se o resultado numerico da formula 26.

027
Formula 027 - Engenharia de Alimentos e Processamento
FUNDAMENTAL
resultado = (a7 * x + b4 * y + c4 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Alimentos e Processamento; a7=ganho primario, b4=ganho secundario, c4=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=27, a7=1, b4=1, c4=1, calcula-se o resultado numerico da formula 27.

028
Formula 028 - Engenharia de Alimentos e Processamento
INTERMEDIARIO
resultado = (a1 * x + b5 * y + c1 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Alimentos e Processamento; a1=ganho primario, b5=ganho secundario, c1=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=28, a1=1, b5=1, c1=1, calcula-se o resultado numerico da formula 28.

029
Formula 029 - Engenharia de Alimentos e Processamento
AVANCADO
resultado = (a2 * x + b6 * y + c2 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Alimentos e Processamento; a2=ganho primario, b6=ganho secundario, c2=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=29, a2=1, b6=1, c2=1, calcula-se o resultado numerico da formula 29.

030
Formula 030 - Engenharia de Alimentos e Processamento
FUNDAMENTAL
resultado = (a3 * x + b2 * y + c3 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Alimentos e Processamento; a3=ganho primario, b2=ganho secundario, c3=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=30, a3=1, b2=1, c3=1, calcula-se o resultado numerico da formula 30.

031
Formula 031 - Engenharia de Alimentos e Processamento
INTERMEDIARIO
resultado = (a4 * x + b3 * y + c4 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Alimentos e Processamento; a4=ganho primario, b3=ganho secundario, c4=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=31, a4=1, b3=1, c4=1, calcula-se o resultado numerico da formula 31.

032
Formula 032 - Engenharia de Alimentos e Processamento
AVANCADO
resultado = (a5 * x + b4 * y + c1 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Alimentos e Processamento; a5=ganho primario, b4=ganho secundario, c1=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=32, a5=1, b4=1, c1=1, calcula-se o resultado numerico da formula 32.

033
Formula 033 - Engenharia de Alimentos e Processamento
FUNDAMENTAL
resultado = (a6 * x + b5 * y + c2 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Alimentos e Processamento; a6=ganho primario, b5=ganho secundario, c2=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=33, a6=1, b5=1, c2=1, calcula-se o resultado numerico da formula 33.

034
Formula 034 - Engenharia de Alimentos e Processamento
INTERMEDIARIO
resultado = (a7 * x + b6 * y + c3 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Alimentos e Processamento; a7=ganho primario, b6=ganho secundario, c3=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=34, a7=1, b6=1, c3=1, calcula-se o resultado numerico da formula 34.

035
Formula 035 - Engenharia de Alimentos e Processamento
AVANCADO
resultado = (a1 * x + b2 * y + c4 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Alimentos e Processamento; a1=ganho primario, b2=ganho secundario, c4=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=35, a1=1, b2=1, c4=1, calcula-se o resultado numerico da formula 35.

036
Formula 036 - Engenharia de Alimentos e Processamento
FUNDAMENTAL
resultado = (a2 * x + b3 * y + c1 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Alimentos e Processamento; a2=ganho primario, b3=ganho secundario, c1=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=36, a2=1, b3=1, c1=1, calcula-se o resultado numerico da formula 36.

037
Formula 037 - Engenharia de Alimentos e Processamento
INTERMEDIARIO
resultado = (a3 * x + b4 * y + c2 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Alimentos e Processamento; a3=ganho primario, b4=ganho secundario, c2=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=37, a3=1, b4=1, c2=1, calcula-se o resultado numerico da formula 37.

038
Formula 038 - Engenharia de Alimentos e Processamento
AVANCADO
resultado = (a4 * x + b5 * y + c3 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Alimentos e Processamento; a4=ganho primario, b5=ganho secundario, c3=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=38, a4=1, b5=1, c3=1, calcula-se o resultado numerico da formula 38.

039
Formula 039 - Engenharia de Alimentos e Processamento
FUNDAMENTAL
resultado = (a5 * x + b6 * y + c4 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Alimentos e Processamento; a5=ganho primario, b6=ganho secundario, c4=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=39, a5=1, b6=1, c4=1, calcula-se o resultado numerico da formula 39.

040
Formula 040 - Engenharia de Alimentos e Processamento
INTERMEDIARIO
resultado = (a6 * x + b2 * y + c1 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Alimentos e Processamento; a6=ganho primario, b2=ganho secundario, c1=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=40, a6=1, b2=1, c1=1, calcula-se o resultado numerico da formula 40.


Mecanica de Solos e Fundacoes
Modelos Quantitativos
041
Formula 041 - Mecanica de Solos e Fundacoes
AVANCADO
resultado = (a7 * x + b3 * y + c2 * z) / (1 + k_idx)
Modelo computavel para a area Mecanica de Solos e Fundacoes; a7=ganho primario, b3=ganho secundario, c2=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=41, a7=1, b3=1, c2=1, calcula-se o resultado numerico da formula 41.

042
Formula 042 - Mecanica de Solos e Fundacoes
FUNDAMENTAL
resultado = (a1 * x + b4 * y + c3 * z) / (1 + k_idx)
Modelo computavel para a area Mecanica de Solos e Fundacoes; a1=ganho primario, b4=ganho secundario, c3=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=42, a1=1, b4=1, c3=1, calcula-se o resultado numerico da formula 42.

043
Formula 043 - Mecanica de Solos e Fundacoes
INTERMEDIARIO
resultado = (a2 * x + b5 * y + c4 * z) / (1 + k_idx)
Modelo computavel para a area Mecanica de Solos e Fundacoes; a2=ganho primario, b5=ganho secundario, c4=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=43, a2=1, b5=1, c4=1, calcula-se o resultado numerico da formula 43.

044
Formula 044 - Mecanica de Solos e Fundacoes
AVANCADO
resultado = (a3 * x + b6 * y + c1 * z) / (1 + k_idx)
Modelo computavel para a area Mecanica de Solos e Fundacoes; a3=ganho primario, b6=ganho secundario, c1=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=44, a3=1, b6=1, c1=1, calcula-se o resultado numerico da formula 44.

045
Formula 045 - Mecanica de Solos e Fundacoes
FUNDAMENTAL
resultado = (a4 * x + b2 * y + c2 * z) / (1 + k_idx)
Modelo computavel para a area Mecanica de Solos e Fundacoes; a4=ganho primario, b2=ganho secundario, c2=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=45, a4=1, b2=1, c2=1, calcula-se o resultado numerico da formula 45.

046
Formula 046 - Mecanica de Solos e Fundacoes
INTERMEDIARIO
resultado = (a5 * x + b3 * y + c3 * z) / (1 + k_idx)
Modelo computavel para a area Mecanica de Solos e Fundacoes; a5=ganho primario, b3=ganho secundario, c3=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=46, a5=1, b3=1, c3=1, calcula-se o resultado numerico da formula 46.

047
Formula 047 - Mecanica de Solos e Fundacoes
AVANCADO
resultado = (a6 * x + b4 * y + c4 * z) / (1 + k_idx)
Modelo computavel para a area Mecanica de Solos e Fundacoes; a6=ganho primario, b4=ganho secundario, c4=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=47, a6=1, b4=1, c4=1, calcula-se o resultado numerico da formula 47.

048
Formula 048 - Mecanica de Solos e Fundacoes
FUNDAMENTAL
resultado = (a7 * x + b5 * y + c1 * z) / (1 + k_idx)
Modelo computavel para a area Mecanica de Solos e Fundacoes; a7=ganho primario, b5=ganho secundario, c1=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=48, a7=1, b5=1, c1=1, calcula-se o resultado numerico da formula 48.

049
Formula 049 - Mecanica de Solos e Fundacoes
INTERMEDIARIO
resultado = (a1 * x + b6 * y + c2 * z) / (1 + k_idx)
Modelo computavel para a area Mecanica de Solos e Fundacoes; a1=ganho primario, b6=ganho secundario, c2=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=49, a1=1, b6=1, c2=1, calcula-se o resultado numerico da formula 49.

050
Formula 050 - Mecanica de Solos e Fundacoes
AVANCADO
resultado = (a2 * x + b2 * y + c3 * z) / (1 + k_idx)
Modelo computavel para a area Mecanica de Solos e Fundacoes; a2=ganho primario, b2=ganho secundario, c3=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=50, a2=1, b2=1, c3=1, calcula-se o resultado numerico da formula 50.

051
Formula 051 - Mecanica de Solos e Fundacoes
FUNDAMENTAL
resultado = (a3 * x + b3 * y + c4 * z) / (1 + k_idx)
Modelo computavel para a area Mecanica de Solos e Fundacoes; a3=ganho primario, b3=ganho secundario, c4=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=51, a3=1, b3=1, c4=1, calcula-se o resultado numerico da formula 51.

052
Formula 052 - Mecanica de Solos e Fundacoes
INTERMEDIARIO
resultado = (a4 * x + b4 * y + c1 * z) / (1 + k_idx)
Modelo computavel para a area Mecanica de Solos e Fundacoes; a4=ganho primario, b4=ganho secundario, c1=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=52, a4=1, b4=1, c1=1, calcula-se o resultado numerico da formula 52.

053
Formula 053 - Mecanica de Solos e Fundacoes
AVANCADO
resultado = (a5 * x + b5 * y + c2 * z) / (1 + k_idx)
Modelo computavel para a area Mecanica de Solos e Fundacoes; a5=ganho primario, b5=ganho secundario, c2=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=53, a5=1, b5=1, c2=1, calcula-se o resultado numerico da formula 53.

054
Formula 054 - Mecanica de Solos e Fundacoes
FUNDAMENTAL
resultado = (a6 * x + b6 * y + c3 * z) / (1 + k_idx)
Modelo computavel para a area Mecanica de Solos e Fundacoes; a6=ganho primario, b6=ganho secundario, c3=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=54, a6=1, b6=1, c3=1, calcula-se o resultado numerico da formula 54.

055
Formula 055 - Mecanica de Solos e Fundacoes
INTERMEDIARIO
resultado = (a7 * x + b2 * y + c4 * z) / (1 + k_idx)
Modelo computavel para a area Mecanica de Solos e Fundacoes; a7=ganho primario, b2=ganho secundario, c4=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=55, a7=1, b2=1, c4=1, calcula-se o resultado numerico da formula 55.

056
Formula 056 - Mecanica de Solos e Fundacoes
AVANCADO
resultado = (a1 * x + b3 * y + c1 * z) / (1 + k_idx)
Modelo computavel para a area Mecanica de Solos e Fundacoes; a1=ganho primario, b3=ganho secundario, c1=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=56, a1=1, b3=1, c1=1, calcula-se o resultado numerico da formula 56.

057
Formula 057 - Mecanica de Solos e Fundacoes
FUNDAMENTAL
resultado = (a2 * x + b4 * y + c2 * z) / (1 + k_idx)
Modelo computavel para a area Mecanica de Solos e Fundacoes; a2=ganho primario, b4=ganho secundario, c2=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=57, a2=1, b4=1, c2=1, calcula-se o resultado numerico da formula 57.

058
Formula 058 - Mecanica de Solos e Fundacoes
INTERMEDIARIO
resultado = (a3 * x + b5 * y + c3 * z) / (1 + k_idx)
Modelo computavel para a area Mecanica de Solos e Fundacoes; a3=ganho primario, b5=ganho secundario, c3=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=58, a3=1, b5=1, c3=1, calcula-se o resultado numerico da formula 58.

059
Formula 059 - Mecanica de Solos e Fundacoes
AVANCADO
resultado = (a4 * x + b6 * y + c4 * z) / (1 + k_idx)
Modelo computavel para a area Mecanica de Solos e Fundacoes; a4=ganho primario, b6=ganho secundario, c4=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=59, a4=1, b6=1, c4=1, calcula-se o resultado numerico da formula 59.

060
Formula 060 - Mecanica de Solos e Fundacoes
FUNDAMENTAL
resultado = (a5 * x + b2 * y + c1 * z) / (1 + k_idx)
Modelo computavel para a area Mecanica de Solos e Fundacoes; a5=ganho primario, b2=ganho secundario, c1=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=60, a5=1, b2=1, c1=1, calcula-se o resultado numerico da formula 60.


Engenharia de Telecomunicacoes
Modelos Quantitativos
061
Formula 061 - Engenharia de Telecomunicacoes
INTERMEDIARIO
resultado = (a6 * x + b3 * y + c2 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Telecomunicacoes; a6=ganho primario, b3=ganho secundario, c2=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=61, a6=1, b3=1, c2=1, calcula-se o resultado numerico da formula 61.

062
Formula 062 - Engenharia de Telecomunicacoes
AVANCADO
resultado = (a7 * x + b4 * y + c3 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Telecomunicacoes; a7=ganho primario, b4=ganho secundario, c3=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=62, a7=1, b4=1, c3=1, calcula-se o resultado numerico da formula 62.

063
Formula 063 - Engenharia de Telecomunicacoes
FUNDAMENTAL
resultado = (a1 * x + b5 * y + c4 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Telecomunicacoes; a1=ganho primario, b5=ganho secundario, c4=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=63, a1=1, b5=1, c4=1, calcula-se o resultado numerico da formula 63.

064
Formula 064 - Engenharia de Telecomunicacoes
INTERMEDIARIO
resultado = (a2 * x + b6 * y + c1 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Telecomunicacoes; a2=ganho primario, b6=ganho secundario, c1=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=64, a2=1, b6=1, c1=1, calcula-se o resultado numerico da formula 64.

065
Formula 065 - Engenharia de Telecomunicacoes
AVANCADO
resultado = (a3 * x + b2 * y + c2 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Telecomunicacoes; a3=ganho primario, b2=ganho secundario, c2=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=65, a3=1, b2=1, c2=1, calcula-se o resultado numerico da formula 65.

066
Formula 066 - Engenharia de Telecomunicacoes
FUNDAMENTAL
resultado = (a4 * x + b3 * y + c3 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Telecomunicacoes; a4=ganho primario, b3=ganho secundario, c3=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=66, a4=1, b3=1, c3=1, calcula-se o resultado numerico da formula 66.

067
Formula 067 - Engenharia de Telecomunicacoes
INTERMEDIARIO
resultado = (a5 * x + b4 * y + c4 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Telecomunicacoes; a5=ganho primario, b4=ganho secundario, c4=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=67, a5=1, b4=1, c4=1, calcula-se o resultado numerico da formula 67.

068
Formula 068 - Engenharia de Telecomunicacoes
AVANCADO
resultado = (a6 * x + b5 * y + c1 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Telecomunicacoes; a6=ganho primario, b5=ganho secundario, c1=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=68, a6=1, b5=1, c1=1, calcula-se o resultado numerico da formula 68.

069
Formula 069 - Engenharia de Telecomunicacoes
FUNDAMENTAL
resultado = (a7 * x + b6 * y + c2 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Telecomunicacoes; a7=ganho primario, b6=ganho secundario, c2=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=69, a7=1, b6=1, c2=1, calcula-se o resultado numerico da formula 69.

070
Formula 070 - Engenharia de Telecomunicacoes
INTERMEDIARIO
resultado = (a1 * x + b2 * y + c3 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Telecomunicacoes; a1=ganho primario, b2=ganho secundario, c3=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=70, a1=1, b2=1, c3=1, calcula-se o resultado numerico da formula 70.

071
Formula 071 - Engenharia de Telecomunicacoes
AVANCADO
resultado = (a2 * x + b3 * y + c4 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Telecomunicacoes; a2=ganho primario, b3=ganho secundario, c4=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=71, a2=1, b3=1, c4=1, calcula-se o resultado numerico da formula 71.

072
Formula 072 - Engenharia de Telecomunicacoes
FUNDAMENTAL
resultado = (a3 * x + b4 * y + c1 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Telecomunicacoes; a3=ganho primario, b4=ganho secundario, c1=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=72, a3=1, b4=1, c1=1, calcula-se o resultado numerico da formula 72.

073
Formula 073 - Engenharia de Telecomunicacoes
INTERMEDIARIO
resultado = (a4 * x + b5 * y + c2 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Telecomunicacoes; a4=ganho primario, b5=ganho secundario, c2=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=73, a4=1, b5=1, c2=1, calcula-se o resultado numerico da formula 73.

074
Formula 074 - Engenharia de Telecomunicacoes
AVANCADO
resultado = (a5 * x + b6 * y + c3 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Telecomunicacoes; a5=ganho primario, b6=ganho secundario, c3=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=74, a5=1, b6=1, c3=1, calcula-se o resultado numerico da formula 74.

075
Formula 075 - Engenharia de Telecomunicacoes
FUNDAMENTAL
resultado = (a6 * x + b2 * y + c4 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Telecomunicacoes; a6=ganho primario, b2=ganho secundario, c4=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=75, a6=1, b2=1, c4=1, calcula-se o resultado numerico da formula 75.

076
Formula 076 - Engenharia de Telecomunicacoes
INTERMEDIARIO
resultado = (a7 * x + b3 * y + c1 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Telecomunicacoes; a7=ganho primario, b3=ganho secundario, c1=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=76, a7=1, b3=1, c1=1, calcula-se o resultado numerico da formula 76.

077
Formula 077 - Engenharia de Telecomunicacoes
AVANCADO
resultado = (a1 * x + b4 * y + c2 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Telecomunicacoes; a1=ganho primario, b4=ganho secundario, c2=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=77, a1=1, b4=1, c2=1, calcula-se o resultado numerico da formula 77.

078
Formula 078 - Engenharia de Telecomunicacoes
FUNDAMENTAL
resultado = (a2 * x + b5 * y + c3 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Telecomunicacoes; a2=ganho primario, b5=ganho secundario, c3=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=78, a2=1, b5=1, c3=1, calcula-se o resultado numerico da formula 78.

079
Formula 079 - Engenharia de Telecomunicacoes
INTERMEDIARIO
resultado = (a3 * x + b6 * y + c4 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Telecomunicacoes; a3=ganho primario, b6=ganho secundario, c4=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=79, a3=1, b6=1, c4=1, calcula-se o resultado numerico da formula 79.

080
Formula 080 - Engenharia de Telecomunicacoes
AVANCADO
resultado = (a4 * x + b2 * y + c1 * z) / (1 + k_idx)
Modelo computavel para a area Engenharia de Telecomunicacoes; a4=ganho primario, b2=ganho secundario, c1=correcao, x=entrada principal, y=entrada de acoplamento, z=entrada auxiliar, k_idx=indice da formula.
ORIGEM Compendio Geral de Equacoes - Volume XVIII, Edicao 2026
▶ Exemplo: com x=10, y=4, z=2, k_idx=80, a4=1, b2=1, c1=1, calcula-se o resultado numerico da formula 80.


Biologia Sintetica e Circuitos Geneticos
Modelos Quantitativos

Ciencia de Materiais Ceramicos e Vidros
Modelos Quantitativos

Ecologia Quantitativa e Dinamica de Ecossistemas
Modelos Quantitativos

Farmacologia Clinica e Farmacocinetica
Modelos Quantitativos

Engenharia Sismica e Dinamica Estrutural
Modelos Quantitativos

Mecanica dos Fluidos Avancada
Modelos Quantitativos

Astronomia e Astrofisica Observacional
Modelos Quantitativos

Engenharia de Seguranca e Analise de Riscos
Modelos Quantitativos

Neurociencia Computacional
Modelos Quantitativos

Ciencias dos Materiais Avancados
Modelos Quantitativos

Epidemiologia Avancada e Saude Publica
Modelos Quantitativos

Astrofisica Galactica e Cosmologia
Modelos Quantitativos

Engenharia Biomedica e Bioeletronica
Modelos Quantitativos

Economia Ambiental e Recursos Naturais
Modelos Quantitativos

Optica e Instrumentacao de Alta Precisao
Modelos Quantitativos

Dinamica de Sistemas Complexos
Modelos Quantitativos

Engenharia de Superficies e Tribologia
Modelos Quantitativos

Metrologia e Sistemas de Medicao
Modelos Quantitativos

""";
    }
}
