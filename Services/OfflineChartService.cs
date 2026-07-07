using System.Globalization;
using System.Net;
using System.Text;

namespace CompendioCalc.Services;

public sealed record ChartSeries(string Name, string Color, IReadOnlyList<(double X, double Y)> Points);
public sealed record ChartMarker(double X, double Y, string Label, string Color = "#f59e0b");

public sealed class OfflineChartService
{
    public string FunctionPlot(
        IEnumerable<(string Name, string Color, Func<double, double> Function)> functions,
        double xMin,
        double xMax,
        int samples = 500,
        int width = 900,
        int height = 520)
    {
        if (!(xMax > xMin)) throw new ArgumentException("O domínio X é inválido.");
        samples = Math.Clamp(samples, 20, 10_000);
        var series = new List<ChartSeries>();
        foreach (var function in functions)
        {
            var points = new List<(double, double)>();
            for (var i = 0; i < samples; i++)
            {
                var x = xMin + (xMax - xMin) * i / (samples - 1d);
                try
                {
                    var y = function.Function(x);
                    if (double.IsFinite(y)) points.Add((x, y));
                }
                catch { /* descontinuidade: ponto omitido */ }
            }
            series.Add(new(function.Name, function.Color, points));
        }
        return LineChart(series, width, height, "x", "y");
    }

    public string LineChart(
        IEnumerable<ChartSeries> input,
        int width = 900,
        int height = 520,
        string xLabel = "x",
        string yLabel = "y",
        IEnumerable<ChartMarker>? markers = null)
    {
        var series = input.Where(item => item.Points.Count > 0).ToArray();
        if (series.Length == 0) throw new ArgumentException("Não há pontos finitos para plotar.");
        var all = series.SelectMany(item => item.Points).ToArray();
        var xMin = all.Min(point => point.X);
        var xMax = all.Max(point => point.X);
        var yMin = all.Min(point => point.Y);
        var yMax = all.Max(point => point.Y);
        ExpandRange(ref xMin, ref xMax);
        ExpandRange(ref yMin, ref yMax);
        const double left = 70, top = 30, right = 25, bottom = 60;
        double X(double value) => left + (value - xMin) / (xMax - xMin) * (width - left - right);
        double Y(double value) => height - bottom - (value - yMin) / (yMax - yMin) * (height - top - bottom);
        var builder = StartSvg(width, height);
        builder.Append("<rect width=\"100%\" height=\"100%\" fill=\"#0f172a\"/>");
        AddGrid(builder, width, height, left, top, right, bottom, xMin, xMax, yMin, yMax, X, Y);
        foreach (var item in series)
        {
            var path = new StringBuilder();
            var started = false;
            (double X, double Y)? previous = null;
            foreach (var point in item.Points)
            {
                var px = X(point.X);
                var py = Y(point.Y);
                var discontinuity = previous.HasValue && Math.Abs(py - previous.Value.Y) > height * .8;
                path.Append(!started || discontinuity ? "M" : "L")
                    .Append(F(px)).Append(' ').Append(F(py)).Append(' ');
                started = true;
                previous = (px, py);
            }
            builder.Append("<path d=\"").Append(path).Append("\" fill=\"none\" stroke=\"")
                .Append(SafeColor(item.Color)).Append("\" stroke-width=\"2\"/>");
        }
        foreach (var marker in markers ?? [])
            builder.Append("<circle cx=\"").Append(F(X(marker.X))).Append("\" cy=\"").Append(F(Y(marker.Y)))
                .Append("\" r=\"5\" fill=\"").Append(SafeColor(marker.Color)).Append("\"><title>")
                .Append(WebUtility.HtmlEncode(marker.Label)).Append("</title></circle>");
        builder.Append("<text x=\"").Append(width / 2).Append("\" y=\"").Append(height - 12)
            .Append("\" text-anchor=\"middle\" fill=\"#e2e8f0\">").Append(WebUtility.HtmlEncode(xLabel)).Append("</text>")
            .Append("<text x=\"18\" y=\"").Append(height / 2)
            .Append("\" text-anchor=\"middle\" transform=\"rotate(-90 18 ").Append(height / 2)
            .Append(")\" fill=\"#e2e8f0\">").Append(WebUtility.HtmlEncode(yLabel)).Append("</text>");
        AddLegend(builder, series, width);
        return builder.Append("</svg>").ToString();
    }

    public string Scatter(IReadOnlyList<(double X, double Y)> points, int width = 900, int height = 520) =>
        LineChart([new("Dados", "#38bdf8", points)], width, height);

    public string Histogram(IReadOnlyList<double> values, int bins = 20, int width = 900, int height = 520)
    {
        if (values.Count == 0) throw new ArgumentException("A amostra está vazia.");
        bins = Math.Clamp(bins, 1, 200);
        var min = values.Min();
        var max = values.Max();
        ExpandRange(ref min, ref max);
        var counts = new int[bins];
        foreach (var value in values)
        {
            var index = Math.Min(bins - 1, (int)((value - min) / (max - min) * bins));
            counts[Math.Max(0, index)]++;
        }
        const double left = 65, top = 30, right = 25, bottom = 55;
        var plotWidth = width - left - right;
        var plotHeight = height - top - bottom;
        var maxCount = Math.Max(1, counts.Max());
        var builder = StartSvg(width, height).Append("<rect width=\"100%\" height=\"100%\" fill=\"#0f172a\"/>");
        for (var i = 0; i < bins; i++)
        {
            var x = left + i * plotWidth / bins;
            var barWidth = plotWidth / bins - 1;
            var barHeight = counts[i] * plotHeight / maxCount;
            builder.Append("<rect x=\"").Append(F(x)).Append("\" y=\"").Append(F(top + plotHeight - barHeight))
                .Append("\" width=\"").Append(F(barWidth)).Append("\" height=\"").Append(F(barHeight))
                .Append("\" fill=\"#38bdf8\"><title>").Append(counts[i]).Append("</title></rect>");
        }
        return builder.Append("</svg>").ToString();
    }

    public string AccessibleDescription(IEnumerable<ChartSeries> input)
    {
        var series = input.ToArray();
        return string.Join(" ", series.Select(item =>
        {
            if (item.Points.Count == 0) return $"Série {item.Name} sem pontos.";
            var minimum = item.Points.MinBy(point => point.Y);
            var maximum = item.Points.MaxBy(point => point.Y);
            return $"Série {item.Name}, {item.Points.Count} pontos; mínimo {minimum.Y:G6} em x={minimum.X:G6}; máximo {maximum.Y:G6} em x={maximum.X:G6}.";
        }));
    }

    private static StringBuilder StartSvg(int width, int height) =>
        new($"<svg xmlns=\"http://www.w3.org/2000/svg\" role=\"img\" width=\"{width}\" height=\"{height}\" viewBox=\"0 0 {width} {height}\">");

    private static void AddGrid(StringBuilder builder, int width, int height, double left, double top,
        double right, double bottom, double xMin, double xMax, double yMin, double yMax,
        Func<double, double> xMap, Func<double, double> yMap)
    {
        for (var i = 0; i <= 10; i++)
        {
            var xValue = xMin + (xMax - xMin) * i / 10;
            var x = xMap(xValue);
            builder.Append("<line x1=\"").Append(F(x)).Append("\" y1=\"").Append(F(top)).Append("\" x2=\"")
                .Append(F(x)).Append("\" y2=\"").Append(F(height - bottom)).Append("\" stroke=\"#334155\"/>")
                .Append("<text x=\"").Append(F(x)).Append("\" y=\"").Append(height - bottom + 20)
                .Append("\" text-anchor=\"middle\" fill=\"#94a3b8\" font-size=\"11\">").Append(F(xValue)).Append("</text>");
            var yValue = yMin + (yMax - yMin) * i / 10;
            var y = yMap(yValue);
            builder.Append("<line x1=\"").Append(F(left)).Append("\" y1=\"").Append(F(y)).Append("\" x2=\"")
                .Append(F(width - right)).Append("\" y2=\"").Append(F(y)).Append("\" stroke=\"#334155\"/>")
                .Append("<text x=\"").Append(left - 8).Append("\" y=\"").Append(F(y + 4))
                .Append("\" text-anchor=\"end\" fill=\"#94a3b8\" font-size=\"11\">").Append(F(yValue)).Append("</text>");
        }
    }

    private static void AddLegend(StringBuilder builder, IReadOnlyList<ChartSeries> series, int width)
    {
        var x = width - 180;
        for (var i = 0; i < series.Count; i++)
            builder.Append("<line x1=\"").Append(x).Append("\" y1=\"").Append(18 + i * 18).Append("\" x2=\"")
                .Append(x + 20).Append("\" y2=\"").Append(18 + i * 18).Append("\" stroke=\"")
                .Append(SafeColor(series[i].Color)).Append("\" stroke-width=\"3\"/><text x=\"").Append(x + 26)
                .Append("\" y=\"").Append(22 + i * 18).Append("\" fill=\"#e2e8f0\" font-size=\"12\">")
                .Append(WebUtility.HtmlEncode(series[i].Name)).Append("</text>");
    }

    private static string SafeColor(string value) =>
        System.Text.RegularExpressions.Regex.IsMatch(value ?? "", @"^#[0-9a-fA-F]{6}$") ? value! : "#38bdf8";
    private static string F(double value) => value.ToString("0.###", CultureInfo.InvariantCulture);
    private static void ExpandRange(ref double min, ref double max)
    {
        if (Math.Abs(max - min) > 1e-15) return;
        var padding = Math.Max(1, Math.Abs(min) * .1);
        min -= padding;
        max += padding;
    }
}
