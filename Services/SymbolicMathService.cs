using System.Globalization;
using System.Text;

namespace CompendioCalc.Services;

public sealed record SymbolicResult(
    bool Success,
    string Expression,
    IReadOnlyList<string> Steps,
    string Limitation = "");

public sealed record EquationSolution(
    bool Success,
    IReadOnlyList<double> Roots,
    string Explanation,
    string Limitation = "");

/// <summary>
/// Álgebra simbólica exata para polinômios univariados. O serviço declara
/// explicitamente seu domínio em vez de produzir respostas aproximadas fingindo
/// suportar expressões gerais.
/// </summary>
public sealed class SymbolicMathService
{
    public SymbolicResult Simplify(string expression, string variable = "x")
    {
        try
        {
            var polynomial = Parse(expression, variable);
            return new(true, Format(polynomial, variable),
                ["Analisar a expressão", "Aplicar distributividade", "Combinar termos de mesmo grau"]);
        }
        catch (NotSupportedException ex)
        {
            return new(false, expression, [], ex.Message);
        }
    }

    public SymbolicResult Expand(string expression, string variable = "x") => Simplify(expression, variable);

    public SymbolicResult Differentiate(string expression, string variable = "x")
    {
        try
        {
            var source = Parse(expression, variable);
            var derivative = new Polynomial();
            foreach (var (power, coefficient) in source.Terms)
                if (power > 0) derivative.Add(power - 1, coefficient * power);
            return new(true, Format(derivative, variable),
                source.Terms.Where(term => term.Key > 0)
                    .Select(term => $"d/d{variable} ({term.Value:G6}{variable}^{term.Key}) = {(term.Value * term.Key):G6}{variable}^{term.Key - 1}")
                    .Append("Combinar os termos derivados").ToArray());
        }
        catch (NotSupportedException ex)
        {
            return new(false, expression, [], ex.Message);
        }
    }

    public SymbolicResult Integrate(string expression, string variable = "x", string constant = "C")
    {
        try
        {
            var source = Parse(expression, variable);
            var integral = new Polynomial();
            foreach (var (power, coefficient) in source.Terms)
                integral.Add(power + 1, coefficient / (power + 1));
            return new(true, $"{Format(integral, variable)} + {constant}",
                source.Terms.Select(term =>
                    $"∫ {term.Value:G6}{variable}^{term.Key} d{variable} = {(term.Value / (term.Key + 1)):G6}{variable}^{term.Key + 1}")
                    .Append($"Adicionar a constante de integração {constant}").ToArray());
        }
        catch (NotSupportedException ex)
        {
            return new(false, expression, [], ex.Message);
        }
    }

    public EquationSolution Solve(string equation, string variable = "x")
    {
        try
        {
            var pieces = equation.Split('=', 2);
            var left = Parse(pieces[0], variable);
            var polynomial = pieces.Length == 2 ? left.Subtract(Parse(pieces[1], variable)) : left;
            var degree = polynomial.Degree;
            if (degree < 0) return new(false, [], "Identidade 0 = 0: infinitas soluções.");
            if (degree == 0) return new(false, [], "Equação constante não nula: nenhuma solução.");
            if (degree == 1)
            {
                var root = -polynomial[0] / polynomial[1];
                return new(true, [root], $"{polynomial[1]:G8}{variable} + {polynomial[0]:G8} = 0; {variable} = {root:G15}");
            }
            if (degree == 2)
            {
                var a = polynomial[2];
                var b = polynomial[1];
                var c = polynomial[0];
                var delta = b * b - 4 * a * c;
                if (delta < 0) return new(false, [], $"Δ = {delta:G15}; não existem raízes reais.",
                    "Raízes complexas ainda não são retornadas por este solucionador.");
                var sqrt = Math.Sqrt(delta);
                var q = -.5 * (b + Math.CopySign(sqrt, b));
                var roots = Math.Abs(q) < 1e-15
                    ? new[] { -b / (2 * a) }
                    : new[] { q / a, c / q }.DistinctBy(value => Math.Round(value, 12)).Order().ToArray();
                return new(true, roots, $"Δ = b² − 4ac = {delta:G15}; raízes: {string.Join(", ", roots.Select(value => value.ToString("G15")))}");
            }
            return new(false, [], "", "Solução simbólica fechada disponível apenas para graus 1 e 2; use o solucionador numérico para graus maiores.");
        }
        catch (NotSupportedException ex)
        {
            return new(false, [], "", ex.Message);
        }
    }

    public double Evaluate(string expression, double value, string variable = "x") =>
        Parse(expression, variable).Evaluate(value);

    public bool AreEquivalent(string first, string second, string variable = "x", double tolerance = 1e-10)
    {
        var difference = Parse(first, variable).Subtract(Parse(second, variable));
        return difference.Terms.Values.All(value => Math.Abs(value) <= tolerance);
    }

    private static Polynomial Parse(string expression, string variable) =>
        new Parser(expression, variable).Parse();

    private static string Format(Polynomial polynomial, string variable)
    {
        if (polynomial.Terms.Count == 0) return "0";
        var builder = new StringBuilder();
        foreach (var (power, coefficient) in polynomial.Terms.Reverse())
        {
            if (Math.Abs(coefficient) < 1e-14) continue;
            var negative = coefficient < 0;
            var absolute = Math.Abs(coefficient);
            if (builder.Length > 0) builder.Append(negative ? " - " : " + ");
            else if (negative) builder.Append('-');
            var showCoefficient = power == 0 || Math.Abs(absolute - 1) > 1e-14;
            if (showCoefficient) builder.Append(absolute.ToString("G15", CultureInfo.InvariantCulture));
            if (power > 0)
            {
                if (showCoefficient) builder.Append('*');
                builder.Append(variable);
                if (power != 1) builder.Append('^').Append(power);
            }
        }
        return builder.Length == 0 ? "0" : builder.ToString();
    }

    private sealed class Polynomial
    {
        public SortedDictionary<int, double> Terms { get; } = [];
        public int Degree => Terms.Count == 0 ? -1 : Terms.Keys.Max();
        public double this[int power] => Terms.GetValueOrDefault(power);

        public static Polynomial Constant(double value)
        {
            var result = new Polynomial();
            result.Add(0, value);
            return result;
        }

        public static Polynomial Variable()
        {
            var result = new Polynomial();
            result.Add(1, 1);
            return result;
        }

        public void Add(int power, double coefficient)
        {
            var value = Terms.GetValueOrDefault(power) + coefficient;
            if (Math.Abs(value) < 1e-14) Terms.Remove(power);
            else Terms[power] = value;
        }

        public Polynomial Add(Polynomial other)
        {
            var result = Clone();
            foreach (var term in other.Terms) result.Add(term.Key, term.Value);
            return result;
        }

        public Polynomial Subtract(Polynomial other) => Add(other.Scale(-1));

        public Polynomial Scale(double value)
        {
            var result = new Polynomial();
            foreach (var term in Terms) result.Add(term.Key, term.Value * value);
            return result;
        }

        public Polynomial Multiply(Polynomial other)
        {
            var result = new Polynomial();
            foreach (var a in Terms)
            foreach (var b in other.Terms)
                result.Add(a.Key + b.Key, a.Value * b.Value);
            return result;
        }

        public Polynomial Power(int exponent)
        {
            if (exponent < 0 || exponent > 100) throw new NotSupportedException("O expoente deve ser inteiro entre 0 e 100.");
            var result = Constant(1d);
            var factor = Clone();
            while (exponent > 0)
            {
                if ((exponent & 1) == 1) result = result.Multiply(factor);
                exponent >>= 1;
                if (exponent > 0) factor = factor.Multiply(factor);
            }
            return result;
        }

        public double Evaluate(double value) =>
            Terms.Reverse().Aggregate(0d, (sum, term) => sum + term.Value * Math.Pow(value, term.Key));

        private Polynomial Clone()
        {
            var result = new Polynomial();
            foreach (var term in Terms) result.Terms[term.Key] = term.Value;
            return result;
        }
    }

    private sealed class Parser
    {
        private readonly string _text;
        private readonly string _variable;
        private int _position;

        public Parser(string text, string variable)
        {
            _text = text ?? "";
            _variable = variable;
        }

        public Polynomial Parse()
        {
            var result = Expression();
            Skip();
            if (_position != _text.Length) throw Unsupported("token inesperado");
            return result;
        }

        private Polynomial Expression()
        {
            var value = Term();
            while (true)
            {
                Skip();
                if (Take('+')) value = value.Add(Term());
                else if (Take('-')) value = value.Subtract(Term());
                else return value;
            }
        }

        private Polynomial Term()
        {
            var value = Power();
            while (true)
            {
                Skip();
                if (Take('*')) value = value.Multiply(Power());
                else if (Take('/'))
                {
                    var divisor = Power();
                    if (divisor.Degree > 0 || Math.Abs(divisor[0]) < 1e-14)
                        throw Unsupported("divisão por polinômio não constante");
                    value = value.Scale(1 / divisor[0]);
                }
                else if (StartsPrimary()) value = value.Multiply(Power());
                else return value;
            }
        }

        private Polynomial Power()
        {
            var value = Unary();
            Skip();
            if (!Take('^')) return value;
            var exponentValue = Number();
            if (exponentValue != Math.Truncate(exponentValue))
                throw Unsupported("expoente não inteiro");
            return value.Power((int)exponentValue);
        }

        private Polynomial Unary()
        {
            Skip();
            if (Take('+')) return Unary();
            if (Take('-')) return Unary().Scale(-1);
            if (Take('('))
            {
                var value = Expression();
                if (!Take(')')) throw Unsupported("parêntese não fechado");
                return value;
            }
            if (StartsVariable())
            {
                _position += _variable.Length;
                return Polynomial.Variable();
            }
            return Polynomial.Constant(Number());
        }

        private double Number()
        {
            Skip();
            var start = _position;
            while (_position < _text.Length && (char.IsDigit(_text[_position]) || _text[_position] is '.' or ','))
                _position++;
            if (start == _position || !double.TryParse(_text[start.._position].Replace(',', '.'),
                    NumberStyles.Float, CultureInfo.InvariantCulture, out var value))
                throw Unsupported("número esperado");
            return value;
        }

        private bool StartsVariable() =>
            _position + _variable.Length <= _text.Length &&
            _text.AsSpan(_position, _variable.Length).Equals(_variable, StringComparison.OrdinalIgnoreCase);

        private bool StartsPrimary()
        {
            Skip();
            return _position < _text.Length &&
                   (_text[_position] == '(' || char.IsDigit(_text[_position]) || StartsVariable());
        }

        private bool Take(char character)
        {
            Skip();
            if (_position >= _text.Length || _text[_position] != character) return false;
            _position++;
            return true;
        }

        private void Skip()
        {
            while (_position < _text.Length && char.IsWhiteSpace(_text[_position])) _position++;
        }

        private NotSupportedException Unsupported(string reason) =>
            new($"Expressão fora do domínio polinomial na posição {_position + 1}: {reason}.");
    }
}
