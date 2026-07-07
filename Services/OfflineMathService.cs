using System.Globalization;

namespace CompendioCalc.Services;

public sealed record NumericResult(
    bool Success,
    double Value,
    string Method,
    double Residual = 0,
    int Iterations = 0,
    string Error = "");

public sealed record RegressionResult(
    double Intercept,
    double Slope,
    double RSquared,
    double StandardError);

public sealed record UncertaintyResult(
    double Value,
    double StandardUncertainty,
    IReadOnlyDictionary<string, double> Contributions);

/// <summary>
/// Motor matemático determinístico e totalmente offline. Expressões são
/// interpretadas por um parser próprio com allowlist; nenhum código é executado.
/// </summary>
public sealed class OfflineMathService
{
    public double Evaluate(string expression, IReadOnlyDictionary<string, double>? variables = null) =>
        new ExpressionParser(expression, variables ?? new Dictionary<string, double>()).Parse();

    public (bool Valid, string Error) ValidateExpression(string expression)
    {
        try
        {
            _ = Evaluate(expression);
            return (true, "");
        }
        catch (Exception ex) when (ex is FormatException or ArithmeticException)
        {
            return (false, ex.Message);
        }
    }

    public NumericResult FindRootBisection(
        Func<double, double> function,
        double lower,
        double upper,
        double tolerance = 1e-10,
        int maxIterations = 200)
    {
        ValidateTolerance(tolerance, maxIterations);
        var leftValue = function(lower);
        var rightValue = function(upper);
        EnsureFinite(leftValue, nameof(lower));
        EnsureFinite(rightValue, nameof(upper));
        if (leftValue == 0) return new(true, lower, "Bisseção", 0);
        if (rightValue == 0) return new(true, upper, "Bisseção", 0);
        if (Math.Sign(leftValue) == Math.Sign(rightValue))
            return new(false, double.NaN, "Bisseção", Error: "O intervalo não contém mudança de sinal.");

        for (var iteration = 1; iteration <= maxIterations; iteration++)
        {
            var middle = lower + (upper - lower) / 2;
            var value = function(middle);
            EnsureFinite(value, "função");
            if (Math.Abs(value) <= tolerance || Math.Abs(upper - lower) / 2 <= tolerance)
                return new(true, middle, "Bisseção", Math.Abs(value), iteration);

            if (Math.Sign(value) == Math.Sign(leftValue))
            {
                lower = middle;
                leftValue = value;
            }
            else
            {
                upper = middle;
            }
        }

        var estimate = lower + (upper - lower) / 2;
        return new(false, estimate, "Bisseção", Math.Abs(function(estimate)), maxIterations,
            "Número máximo de iterações atingido.");
    }

    public NumericResult FindRootNewton(
        Func<double, double> function,
        double initial,
        double tolerance = 1e-10,
        int maxIterations = 100)
    {
        ValidateTolerance(tolerance, maxIterations);
        var x = initial;
        for (var iteration = 1; iteration <= maxIterations; iteration++)
        {
            var value = function(x);
            EnsureFinite(value, "função");
            if (Math.Abs(value) <= tolerance)
                return new(true, x, "Newton-Raphson", Math.Abs(value), iteration);

            var step = Math.Max(1e-7, Math.Abs(x) * 1e-7);
            var derivative = (function(x + step) - function(x - step)) / (2 * step);
            if (!double.IsFinite(derivative) || Math.Abs(derivative) < 1e-15)
                return new(false, x, "Newton-Raphson", Math.Abs(value), iteration,
                    "Derivada nula ou numericamente instável.");

            var next = x - value / derivative;
            if (!double.IsFinite(next))
                return new(false, x, "Newton-Raphson", Math.Abs(value), iteration,
                    "A iteração produziu valor não finito.");
            if (Math.Abs(next - x) <= tolerance)
                return new(true, next, "Newton-Raphson", Math.Abs(function(next)), iteration);
            x = next;
        }

        return new(false, x, "Newton-Raphson", Math.Abs(function(x)), maxIterations,
            "Número máximo de iterações atingido.");
    }

    public NumericResult IntegrateSimpson(
        Func<double, double> function,
        double lower,
        double upper,
        int subdivisions = 1000)
    {
        if (subdivisions < 2) throw new ArgumentOutOfRangeException(nameof(subdivisions));
        if (subdivisions % 2 != 0) subdivisions++;
        var width = (upper - lower) / subdivisions;
        var sum = function(lower) + function(upper);
        EnsureFinite(sum, "integrando");
        for (var i = 1; i < subdivisions; i++)
        {
            var value = function(lower + i * width);
            EnsureFinite(value, "integrando");
            sum += (i % 2 == 0 ? 2 : 4) * value;
        }
        var result = sum * width / 3;
        return new(true, result, "Simpson", Iterations: subdivisions);
    }

    public IReadOnlyList<(double X, double Y)> SolveOdeRungeKutta4(
        Func<double, double, double> derivative,
        double x0,
        double y0,
        double xEnd,
        double step)
    {
        if (step == 0 || Math.Sign(step) != Math.Sign(xEnd - x0))
            throw new ArgumentException("O passo deve avançar de x0 até xEnd.", nameof(step));
        var count = (int)Math.Ceiling(Math.Abs((xEnd - x0) / step));
        if (count > 1_000_000) throw new ArgumentOutOfRangeException(nameof(step), "Passos demais.");

        var points = new List<(double, double)>(count + 1) { (x0, y0) };
        var x = x0;
        var y = y0;
        for (var i = 0; i < count; i++)
        {
            var h = Math.Abs(xEnd - x) < Math.Abs(step) ? xEnd - x : step;
            var k1 = derivative(x, y);
            var k2 = derivative(x + h / 2, y + h * k1 / 2);
            var k3 = derivative(x + h / 2, y + h * k2 / 2);
            var k4 = derivative(x + h, y + h * k3);
            y += h * (k1 + 2 * k2 + 2 * k3 + k4) / 6;
            x += h;
            EnsureFinite(y, "solução da EDO");
            points.Add((x, y));
        }
        return points;
    }

    public RegressionResult LinearRegression(IReadOnlyList<double> x, IReadOnlyList<double> y)
    {
        if (x.Count != y.Count || x.Count < 2)
            throw new ArgumentException("As séries devem ter o mesmo tamanho e ao menos dois pontos.");
        var meanX = x.Average();
        var meanY = y.Average();
        var sxx = x.Sum(value => Math.Pow(value - meanX, 2));
        if (sxx == 0) throw new ArithmeticException("Todos os valores de X são iguais.");
        var slope = x.Select((value, index) => (value - meanX) * (y[index] - meanY)).Sum() / sxx;
        var intercept = meanY - slope * meanX;
        var residual = x.Select((value, index) => y[index] - (intercept + slope * value)).ToArray();
        var ssResidual = residual.Sum(value => value * value);
        var ssTotal = y.Sum(value => Math.Pow(value - meanY, 2));
        var rSquared = ssTotal == 0 ? 1 : 1 - ssResidual / ssTotal;
        var standardError = x.Count > 2 ? Math.Sqrt(ssResidual / (x.Count - 2)) : 0;
        return new(intercept, slope, rSquared, standardError);
    }

    public UncertaintyResult PropagateUncertainty(
        Func<IReadOnlyDictionary<string, double>, double> function,
        IReadOnlyDictionary<string, double> values,
        IReadOnlyDictionary<string, double> standardUncertainties)
    {
        var nominal = function(values);
        EnsureFinite(nominal, "resultado nominal");
        var contributions = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);
        var variance = 0d;
        foreach (var (name, uncertainty) in standardUncertainties)
        {
            if (!values.TryGetValue(name, out var value) || uncertainty < 0)
                throw new ArgumentException($"Incerteza inválida para '{name}'.");
            var h = Math.Max(1e-8, Math.Abs(value) * 1e-7);
            var plus = new Dictionary<string, double>(values, StringComparer.OrdinalIgnoreCase) { [name] = value + h };
            var minus = new Dictionary<string, double>(values, StringComparer.OrdinalIgnoreCase) { [name] = value - h };
            var derivative = (function(plus) - function(minus)) / (2 * h);
            var contribution = Math.Abs(derivative * uncertainty);
            contributions[name] = contribution;
            variance += contribution * contribution;
        }
        return new(nominal, Math.Sqrt(variance), contributions);
    }

    public IReadOnlyDictionary<string, double> Sensitivity(
        Func<IReadOnlyDictionary<string, double>, double> function,
        IReadOnlyDictionary<string, double> values)
    {
        var output = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);
        foreach (var (name, value) in values)
        {
            var h = Math.Max(1e-8, Math.Abs(value) * 1e-6);
            var plus = new Dictionary<string, double>(values) { [name] = value + h };
            var minus = new Dictionary<string, double>(values) { [name] = value - h };
            output[name] = (function(plus) - function(minus)) / (2 * h);
        }
        return output;
    }

    private static void ValidateTolerance(double tolerance, int iterations)
    {
        if (!(tolerance > 0) || !double.IsFinite(tolerance))
            throw new ArgumentOutOfRangeException(nameof(tolerance));
        if (iterations < 1 || iterations > 1_000_000)
            throw new ArgumentOutOfRangeException(nameof(iterations));
    }

    private static void EnsureFinite(double value, string context)
    {
        if (!double.IsFinite(value))
            throw new ArithmeticException($"{context} produziu NaN ou infinito.");
    }

    private sealed class ExpressionParser
    {
        private readonly string _text;
        private readonly IReadOnlyDictionary<string, double> _variables;
        private int _position;

        public ExpressionParser(string text, IReadOnlyDictionary<string, double> variables)
        {
            _text = text ?? throw new ArgumentNullException(nameof(text));
            _variables = variables;
        }

        public double Parse()
        {
            var value = ParseExpression();
            SkipWhitespace();
            if (_position != _text.Length) throw Error("Token inesperado");
            EnsureFinite(value, "expressão");
            return value;
        }

        private double ParseExpression()
        {
            var value = ParseTerm();
            while (true)
            {
                SkipWhitespace();
                if (Match('+')) value += ParseTerm();
                else if (Match('-')) value -= ParseTerm();
                else return value;
            }
        }

        private double ParseTerm()
        {
            var value = ParsePower();
            while (true)
            {
                SkipWhitespace();
                if (Match('*')) value *= ParsePower();
                else if (Match('/'))
                {
                    var divisor = ParsePower();
                    if (divisor == 0) throw new ArithmeticException("Divisão por zero.");
                    value /= divisor;
                }
                else return value;
            }
        }

        private double ParsePower()
        {
            var value = ParseUnary();
            SkipWhitespace();
            return Match('^') ? Math.Pow(value, ParsePower()) : value;
        }

        private double ParseUnary()
        {
            SkipWhitespace();
            if (Match('+')) return ParseUnary();
            if (Match('-')) return -ParseUnary();
            return ParsePrimary();
        }

        private double ParsePrimary()
        {
            SkipWhitespace();
            if (Match('('))
            {
                var value = ParseExpression();
                SkipWhitespace();
                if (!Match(')')) throw Error("Parêntese ')' ausente");
                return value;
            }
            if (_position < _text.Length && (char.IsDigit(_text[_position]) || _text[_position] is '.' or ','))
                return ParseNumber();
            if (_position < _text.Length && (char.IsLetter(_text[_position]) || _text[_position] == '_'))
            {
                var name = ParseIdentifier();
                SkipWhitespace();
                if (Match('('))
                {
                    var arguments = new List<double>();
                    SkipWhitespace();
                    if (!Match(')'))
                    {
                        do arguments.Add(ParseExpression()); while (Match(';') || Match(','));
                        if (!Match(')')) throw Error("Parêntese ')' ausente na função");
                    }
                    return ApplyFunction(name, arguments);
                }
                if (name.Equals("pi", StringComparison.OrdinalIgnoreCase)) return Math.PI;
                if (name.Equals("e", StringComparison.OrdinalIgnoreCase)) return Math.E;
                if (_variables.TryGetValue(name, out var value)) return value;
                throw Error($"Variável desconhecida: {name}");
            }
            throw Error("Número, variável ou '(' esperado");
        }

        private double ParseNumber()
        {
            var start = _position;
            while (_position < _text.Length && (char.IsDigit(_text[_position]) || _text[_position] is '.' or ',' or 'e' or 'E' or '+' or '-'))
            {
                if ((_text[_position] is '+' or '-') && _position > start && _text[_position - 1] is not ('e' or 'E')) break;
                _position++;
            }
            var token = _text[start.._position].Replace(',', '.');
            if (!double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out var value))
                throw Error($"Número inválido: {token}");
            return value;
        }

        private string ParseIdentifier()
        {
            var start = _position++;
            while (_position < _text.Length && (char.IsLetterOrDigit(_text[_position]) || _text[_position] == '_')) _position++;
            return _text[start.._position];
        }

        private static double ApplyFunction(string name, IReadOnlyList<double> args)
        {
            static double One(IReadOnlyList<double> a, Func<double, double> fn) =>
                a.Count == 1 ? fn(a[0]) : throw new FormatException("A função requer um argumento.");
            return name.ToLowerInvariant() switch
            {
                "sin" or "sen" => One(args, Math.Sin),
                "cos" => One(args, Math.Cos),
                "tan" or "tg" => One(args, Math.Tan),
                "asin" => One(args, Math.Asin),
                "acos" => One(args, Math.Acos),
                "atan" => One(args, Math.Atan),
                "sqrt" or "raiz" => One(args, Math.Sqrt),
                "abs" => One(args, Math.Abs),
                "exp" => One(args, Math.Exp),
                "ln" => One(args, Math.Log),
                "log" or "log10" => One(args, Math.Log10),
                "floor" => One(args, Math.Floor),
                "ceil" => One(args, Math.Ceiling),
                "round" => One(args, Math.Round),
                "min" when args.Count > 0 => args.Min(),
                "max" when args.Count > 0 => args.Max(),
                "pow" when args.Count == 2 => Math.Pow(args[0], args[1]),
                "atan2" when args.Count == 2 => Math.Atan2(args[0], args[1]),
                _ => throw new FormatException($"Função não permitida ou argumentos inválidos: {name}")
            };
        }

        private void SkipWhitespace()
        {
            while (_position < _text.Length && char.IsWhiteSpace(_text[_position])) _position++;
        }

        private bool Match(char value)
        {
            SkipWhitespace();
            if (_position >= _text.Length || _text[_position] != value) return false;
            _position++;
            return true;
        }

        private FormatException Error(string message) =>
            new($"{message} na posição {_position + 1}.");
    }
}
