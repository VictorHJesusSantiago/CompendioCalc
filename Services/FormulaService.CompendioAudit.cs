using System.Text;
using CompendioCalc.Models;

namespace CompendioCalc.Services;

public partial class FormulaService
{
    private const int CodigoCompendioMin = 1;
    private const int CodigoCompendioMax = 387;
    private bool _mapeamentoCompendioInicializado;

    // Mantem mapeamento canonico 001..387 estavel e completo.
    // Regras:
    // 1) Preserva codigos validos existentes quando possivel.
    // 2) Remove/normaliza codigos invalidos ou duplicados.
    // 3) Preenche lacunas restantes com formulas sem codigo, em ordem deterministica.
    public void InicializarCodigosCompendio(bool sobrescreverExistentes = false)
    {
        if (_mapeamentoCompendioInicializado && !sobrescreverExistentes)
        {
            return;
        }

        var formulasOrdenadas = _formulas
            .OrderBy(f => f.Id, StringComparer.OrdinalIgnoreCase)
            .ThenBy(f => f.Nome, StringComparer.OrdinalIgnoreCase)
            .ToList();

        var codigosUsados = new HashSet<int>();

        foreach (var formula in formulasOrdenadas)
        {
            if (sobrescreverExistentes)
            {
                formula.CodigoCompendio = string.Empty;
                continue;
            }

            if (string.IsNullOrWhiteSpace(formula.CodigoCompendio))
            {
                continue;
            }

            if (!TryParseCodigoCompendio(formula.CodigoCompendio, out var numero))
            {
                formula.CodigoCompendio = string.Empty;
                continue;
            }

            if (numero < CodigoCompendioMin || numero > CodigoCompendioMax)
            {
                formula.CodigoCompendio = string.Empty;
                continue;
            }

            if (codigosUsados.Contains(numero))
            {
                // Duplicidade: libera para remapeamento na etapa de preenchimento.
                formula.CodigoCompendio = string.Empty;
                continue;
            }

            formula.CodigoCompendio = numero.ToString("D3");
            codigosUsados.Add(numero);
        }

        var codigosDisponiveis = new Queue<int>(
            Enumerable.Range(CodigoCompendioMin, CodigoCompendioMax)
                .Where(c => !codigosUsados.Contains(c))
        );

        foreach (var formula in formulasOrdenadas)
        {
            if (!string.IsNullOrWhiteSpace(formula.CodigoCompendio))
            {
                continue;
            }

            if (codigosDisponiveis.Count == 0)
            {
                break;
            }

            formula.CodigoCompendio = codigosDisponiveis.Dequeue().ToString("D3");
        }

        _mapeamentoCompendioInicializado = true;
    }

    public bool DefinirCodigoCompendio(string formulaId, string codigo)
    {
        var formula = ObterPorId(formulaId);
        if (formula is null || !TryParseCodigoCompendio(codigo, out var codigoNumero))
        {
            return false;
        }

        formula.CodigoCompendio = codigoNumero.ToString("D3");
        return true;
    }

    public IReadOnlyList<CompendioIndiceItem> ObterIndiceCompendioOficial()
    {
        var itens = new List<CompendioIndiceItem>(CodigoCompendioMax);
        for (var codigo = CodigoCompendioMin; codigo <= CodigoCompendioMax; codigo++)
        {
            itens.Add(new CompendioIndiceItem
            {
                Codigo = codigo.ToString("D3"),
            });
        }

        return itens;
    }

    public CompendioRelatorio GerarRelatorioCompendio(bool aplicarMapeamentoAutomatico = true)
    {
        if (aplicarMapeamentoAutomatico)
        {
            InicializarCodigosCompendio();
        }

        var relatorio = new CompendioRelatorio();
        var indice = ObterIndiceCompendioOficial();
        relatorio.TotalIndices = indice.Count;

        var formulasPorCodigo = _formulas
            .Where(f => !string.IsNullOrWhiteSpace(f.CodigoCompendio))
            .GroupBy(f => f.CodigoCompendio.Trim())
            .ToDictionary(g => g.Key, g => g.ToList(), StringComparer.OrdinalIgnoreCase);

        var formulaIdsOficiais = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var itemIndice in indice)
        {
            formulasPorCodigo.TryGetValue(itemIndice.Codigo, out var formulasDoCodigo);
            formulasDoCodigo ??= [];

            var itemRelatorio = new CompendioRelatorioItem
            {
                Codigo = itemIndice.Codigo,
                NomeEsperado = itemIndice.NomeEsperado,
                FormulaIds = formulasDoCodigo.Select(f => f.Id).OrderBy(id => id).ToList(),
                FormulaNomes = formulasDoCodigo.Select(f => f.Nome).OrderBy(nome => nome).ToList(),
            };

            if (formulasDoCodigo.Count == 0)
            {
                itemRelatorio.Status = CompendioStatus.Faltante;
                itemRelatorio.Observacao = "Sem formula mapeada para este codigo.";
                relatorio.TotalFaltante++;
            }
            else if (formulasDoCodigo.Count == 1)
            {
                itemRelatorio.Status = CompendioStatus.Ok;
                itemRelatorio.Observacao = "Codigo mapeado com formula unica.";
                relatorio.TotalOk++;
            }
            else
            {
                itemRelatorio.Status = CompendioStatus.Divergente;
                itemRelatorio.Observacao = $"Codigo com {formulasDoCodigo.Count} formulas mapeadas (duplicidade).";
                relatorio.TotalDivergente++;
            }

            relatorio.Itens.Add(itemRelatorio);

            foreach (var formulaId in itemRelatorio.FormulaIds)
            {
                formulaIdsOficiais.Add(formulaId);
            }
        }

        var codigosForaDoIndice = _formulas
            .Where(f => !string.IsNullOrWhiteSpace(f.CodigoCompendio))
            .Select(f => new { FormulaId = f.Id, Codigo = f.CodigoCompendio.Trim() })
            .Where(x => !TryParseCodigoCompendio(x.Codigo, out var numero) || numero < CodigoCompendioMin || numero > CodigoCompendioMax)
            .OrderBy(x => x.Codigo)
            .ThenBy(x => x.FormulaId)
            .ToList();

        foreach (var extra in codigosForaDoIndice)
        {
            relatorio.AlertasGerais.Add($"Codigo fora do intervalo oficial: {extra.Codigo} (formula {extra.FormulaId}).");
        }

        relatorio.TotalDivergente += codigosForaDoIndice.Count;

        relatorio.FormulasForaCompendioOficial = _formulas
            .Where(f => !formulaIdsOficiais.Contains(f.Id))
            .OrderBy(f => f.Id, StringComparer.OrdinalIgnoreCase)
            .ThenBy(f => f.Nome, StringComparer.OrdinalIgnoreCase)
            .Select(f => new CompendioExtraItem
            {
                FormulaId = f.Id,
                FormulaNome = f.Nome,
                Categoria = f.Categoria,
                CodigoCompendioAtual = f.CodigoCompendio,
                Observacao = ClassificarFormulaForaCompendio(f.CodigoCompendio),
            })
            .ToList();

        relatorio.TotalFormulasForaCompendioOficial = relatorio.FormulasForaCompendioOficial.Count;

        return relatorio;
    }

    public string GerarRelatorioCompendioTexto(bool aplicarMapeamentoAutomatico = true)
    {
        var relatorio = GerarRelatorioCompendio(aplicarMapeamentoAutomatico);
        var sb = new StringBuilder();

        sb.AppendLine("Relatorio Compendio 001..387");
        sb.AppendLine($"Gerado (UTC): {relatorio.GeradoEmUtc:yyyy-MM-dd HH:mm:ss}");
        sb.AppendLine($"Total indices: {relatorio.TotalIndices}");
        sb.AppendLine($"OK: {relatorio.TotalOk}");
        sb.AppendLine($"FALTANTE: {relatorio.TotalFaltante}");
        sb.AppendLine($"DIVERGENTE: {relatorio.TotalDivergente}");
        sb.AppendLine($"FORA DO COMPENDIO OFICIAL: {relatorio.TotalFormulasForaCompendioOficial}");
        sb.AppendLine();

        foreach (var item in relatorio.Itens)
        {
            sb.Append(item.Codigo);
            sb.Append(" | ");
            sb.Append(item.Status);
            sb.Append(" | ");
            sb.Append(item.Observacao);

            if (item.FormulaIds.Count > 0)
            {
                sb.Append(" | IDs: ");
                sb.Append(string.Join(", ", item.FormulaIds));
            }

            sb.AppendLine();
        }

        if (relatorio.AlertasGerais.Count > 0)
        {
            sb.AppendLine();
            sb.AppendLine("Alertas gerais:");
            foreach (var alerta in relatorio.AlertasGerais)
            {
                sb.AppendLine($"- {alerta}");
            }
        }

        if (relatorio.FormulasForaCompendioOficial.Count > 0)
        {
            sb.AppendLine();
            sb.AppendLine("Formulas extras fora do compendio oficial (001..387):");
            foreach (var extra in relatorio.FormulasForaCompendioOficial)
            {
                var codigo = string.IsNullOrWhiteSpace(extra.CodigoCompendioAtual)
                    ? "(sem codigo)"
                    : extra.CodigoCompendioAtual;

                sb.AppendLine($"- {extra.FormulaId} | {extra.FormulaNome} | {extra.Categoria} | codigo: {codigo} | {extra.Observacao}");
            }
        }

        return sb.ToString();
    }

    private static string ClassificarFormulaForaCompendio(string? codigo)
    {
        if (string.IsNullOrWhiteSpace(codigo))
        {
            return "Sem codigo oficial 001..387.";
        }

        if (!TryParseCodigoCompendio(codigo, out var numero))
        {
            return "Codigo nao numerico/invalido para o compendio oficial.";
        }

        if (numero < CodigoCompendioMin || numero > CodigoCompendioMax)
        {
            return "Codigo fora do intervalo oficial 001..387.";
        }

        return "Formula sem vinculacao ao indice oficial apos auditoria.";
    }

    private static bool TryParseCodigoCompendio(string? codigo, out int numero)
    {
        numero = 0;
        if (string.IsNullOrWhiteSpace(codigo))
        {
            return false;
        }

        return int.TryParse(codigo.Trim(), out numero);
    }
}
