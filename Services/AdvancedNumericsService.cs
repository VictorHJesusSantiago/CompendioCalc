using System.Numerics;
using CompendioCalc.Models;

namespace CompendioCalc.Services;

public sealed record OptimizationResult(
    bool Success,
    double[] Point,
    double Value,
    int Iterations,
    double GradientNorm,
    string Method,
    string Error = "");

public sealed record MonteCarloResult(
    double Estimate,
    double StandardError,
    int Samples,
    int Seed);

public sealed class CubicSpline
{
    private readonly double[] _x, _a, _b, _c, _d;
    internal CubicSpline(double[] x, double[] a, double[] b, double[] c, double[] d) =>
        (_x, _a, _b, _c, _d) = (x, a, b, c, d);

    public double Evaluate(double value)
    {
        if (value < _x[0] || value > _x[^1]) throw new ArgumentOutOfRangeException(nameof(value), "Extrapolação não permitida.");
        var index = Array.BinarySearch(_x, value);
        if (index < 0) index = ~index - 1;
        index = Math.Clamp(index, 0, _a.Length - 1);
        var dx = value - _x[index];
        return _a[index] + _b[index] * dx + _c[index] * dx * dx + _d[index] * dx * dx * dx;
    }
}

public sealed class AdvancedNumericsService
{
    private static readonly double[] Lanczos =
    [
        676.5203681218851, -1259.1392167224028, 771.32342877765313,
        -176.61502916214059, 12.507343278686905, -0.13857109526572012,
        9.9843695780195716e-6, 1.5056327351493116e-7
    ];

    public BigInteger Factorial(int n)
    {
        if (n < 0) throw new ArgumentOutOfRangeException(nameof(n));
        BigInteger result = 1;
        for (var i = 2; i <= n; i++) result *= i;
        return result;
    }

    public BigInteger Combination(int n, int k)
    {
        if (n < 0 || k < 0 || k > n) throw new ArgumentOutOfRangeException();
        k = Math.Min(k, n - k);
        BigInteger result = 1;
        for (var i = 1; i <= k; i++) result = result * (n - k + i) / i;
        return result;
    }

    public IReadOnlyList<Complex> SolveQuadraticComplex(double a, double b, double c)
    {
        if (a == 0)
        {
            if (b == 0) return [];
            return [new Complex(-c / b, 0)];
        }
        var delta = new Complex(b * b - 4 * a * c, 0);
        var root = Complex.Sqrt(delta);
        return [(-b + root) / (2 * a), (-b - root) / (2 * a)];
    }

    public double Gamma(double z)
    {
        if (double.IsNaN(z) || double.IsInfinity(z)) return double.NaN;
        if (z < .5) return Math.PI / (Math.Sin(Math.PI * z) * Gamma(1 - z));
        z -= 1;
        var x = .99999999999980993;
        for (var i = 0; i < Lanczos.Length; i++) x += Lanczos[i] / (z + i + 1);
        var t = z + Lanczos.Length - .5;
        return Math.Sqrt(2 * Math.PI) * Math.Pow(t, z + .5) * Math.Exp(-t) * x;
    }

    public double Beta(double a, double b)
    {
        if (a <= 0 || b <= 0) throw new ArgumentOutOfRangeException();
        return Gamma(a) * Gamma(b) / Gamma(a + b);
    }

    public double BesselJ(int order, double x, int maxTerms = 100)
    {
        if (order < 0) return (order & 1) == 0 ? BesselJ(-order, x, maxTerms) : -BesselJ(-order, x, maxTerms);
        var half = x / 2;
        var term = Math.Pow(half, order) / (double)Factorial(order);
        var sum = term;
        for (var k = 1; k < maxTerms; k++)
        {
            term *= -(half * half) / (k * (order + k));
            sum += term;
            if (Math.Abs(term) <= Math.Abs(sum) * 1e-16) break;
        }
        return sum;
    }

    public double NormalPdf(double x, double mean = 0, double standardDeviation = 1)
    {
        if (!(standardDeviation > 0)) throw new ArgumentOutOfRangeException(nameof(standardDeviation));
        var z = (x - mean) / standardDeviation;
        return Math.Exp(-.5 * z * z) / (standardDeviation * Math.Sqrt(2 * Math.PI));
    }

    public double NormalCdf(double x, double mean = 0, double standardDeviation = 1)
    {
        if (!(standardDeviation > 0)) throw new ArgumentOutOfRangeException(nameof(standardDeviation));
        return .5 * (1 + Erf((x - mean) / (standardDeviation * Math.Sqrt(2))));
    }

    public double NormalQuantile(double probability, double mean = 0, double standardDeviation = 1)
    {
        if (probability is <= 0 or >= 1) throw new ArgumentOutOfRangeException(nameof(probability));
        if (!(standardDeviation > 0)) throw new ArgumentOutOfRangeException(nameof(standardDeviation));
        // Aproximação racional de Acklam.
        double[] a = [-39.6968302866538, 220.946098424521, -275.928510446969, 138.357751867269, -30.6647980661472, 2.50662827745924];
        double[] b = [-54.4760987982241, 161.585836858041, -155.698979859887, 66.8013118877197, -13.2806815528857];
        double[] c = [-.00778489400243029, -.322396458041136, -2.40075827716184, -2.54973253934373, 4.37466414146497, 2.93816398269878];
        double[] d = [.00778469570904146, .32246712907004, 2.445134137143, 3.75440866190742];
        const double low = .02425, high = 1 - low;
        double z;
        if (probability < low)
        {
            var q = Math.Sqrt(-2 * Math.Log(probability));
            z = (((((c[0] * q + c[1]) * q + c[2]) * q + c[3]) * q + c[4]) * q + c[5]) /
                ((((d[0] * q + d[1]) * q + d[2]) * q + d[3]) * q + 1);
        }
        else if (probability <= high)
        {
            var q = probability - .5;
            var r = q * q;
            z = (((((a[0] * r + a[1]) * r + a[2]) * r + a[3]) * r + a[4]) * r + a[5]) * q /
                (((((b[0] * r + b[1]) * r + b[2]) * r + b[3]) * r + b[4]) * r + 1);
        }
        else
        {
            var q = Math.Sqrt(-2 * Math.Log(1 - probability));
            z = -(((((c[0] * q + c[1]) * q + c[2]) * q + c[3]) * q + c[4]) * q + c[5]) /
                ((((d[0] * q + d[1]) * q + d[2]) * q + d[3]) * q + 1);
        }
        return mean + standardDeviation * z;
    }

    public double BinomialPmf(int successes, int trials, double probability)
    {
        if (trials < 0 || successes < 0 || successes > trials || probability is < 0 or > 1)
            throw new ArgumentOutOfRangeException();
        return (double)Combination(trials, successes) * Math.Pow(probability, successes) *
               Math.Pow(1 - probability, trials - successes);
    }

    public double PoissonPmf(int events, double lambda)
    {
        if (events < 0 || lambda < 0) throw new ArgumentOutOfRangeException();
        if (lambda == 0) return events == 0 ? 1 : 0;
        return Math.Exp(-lambda + events * Math.Log(lambda) - LogGamma(events + 1));
    }

    public MonteCarloResult IntegrateMonteCarlo(
        Func<double, double> function, double lower, double upper, int samples, int seed)
    {
        if (samples < 2 || samples > 10_000_000 || !(upper > lower)) throw new ArgumentOutOfRangeException();
        var random = new Random(seed);
        var mean = 0d;
        var m2 = 0d;
        for (var i = 1; i <= samples; i++)
        {
            var value = function(lower + random.NextDouble() * (upper - lower));
            if (!double.IsFinite(value)) throw new ArithmeticException("A função produziu valor não finito.");
            var delta = value - mean;
            mean += delta / i;
            m2 += delta * (value - mean);
        }
        var scale = upper - lower;
        return new(mean * scale, Math.Sqrt(m2 / (samples - 1) / samples) * scale, samples, seed);
    }

    public OptimizationResult GoldenSection(
        Func<double, double> function, double lower, double upper, double tolerance = 1e-9, int maxIterations = 500)
    {
        if (!(upper > lower) || !(tolerance > 0)) throw new ArgumentOutOfRangeException();
        var ratio = (Math.Sqrt(5) - 1) / 2;
        var c = upper - ratio * (upper - lower);
        var d = lower + ratio * (upper - lower);
        var fc = function(c);
        var fd = function(d);
        var iteration = 0;
        while (Math.Abs(upper - lower) > tolerance && iteration++ < maxIterations)
        {
            if (fc < fd) { upper = d; d = c; fd = fc; c = upper - ratio * (upper - lower); fc = function(c); }
            else { lower = c; c = d; fc = fd; d = lower + ratio * (upper - lower); fd = function(d); }
        }
        var point = (lower + upper) / 2;
        return new(iteration < maxIterations, [point], function(point), iteration, 0, "Seção áurea",
            iteration >= maxIterations ? "Máximo de iterações atingido." : "");
    }

    public OptimizationResult GradientDescent(
        Func<IReadOnlyList<double>, double> function,
        IReadOnlyList<double> initial,
        double learningRate = .05,
        double tolerance = 1e-7,
        int maxIterations = 10_000)
    {
        if (initial.Count == 0 || !(learningRate > 0) || !(tolerance > 0)) throw new ArgumentOutOfRangeException();
        var point = initial.ToArray();
        for (var iteration = 1; iteration <= maxIterations; iteration++)
        {
            var gradient = NumericalGradient(function, point);
            var norm = Math.Sqrt(gradient.Sum(value => value * value));
            if (norm <= tolerance) return new(true, point, function(point), iteration, norm, "Gradiente descendente");
            var current = function(point);
            var step = learningRate;
            double[] candidate;
            do
            {
                candidate = point.Select((value, index) => value - step * gradient[index]).ToArray();
                step *= .5;
            } while (function(candidate) > current && step > 1e-12);
            if (step <= 1e-12) return new(false, point, current, iteration, norm,
                "Gradiente descendente", "Não foi possível encontrar passo descendente.");
            point = candidate;
        }
        var finalGradient = NumericalGradient(function, point);
        return new(false, point, function(point), maxIterations,
            Math.Sqrt(finalGradient.Sum(value => value * value)), "Gradiente descendente", "Máximo de iterações atingido.");
    }

    public CubicSpline FitNaturalSpline(IReadOnlyList<double> x, IReadOnlyList<double> y)
    {
        if (x.Count != y.Count || x.Count < 2) throw new ArgumentException("Pontos inválidos.");
        if (x.Zip(x.Skip(1)).Any(pair => pair.First >= pair.Second)) throw new ArgumentException("X deve ser estritamente crescente.");
        var n = x.Count - 1;
        var h = Enumerable.Range(0, n).Select(i => x[i + 1] - x[i]).ToArray();
        var alpha = new double[n];
        for (var i = 1; i < n; i++)
            alpha[i] = 3 / h[i] * (y[i + 1] - y[i]) - 3 / h[i - 1] * (y[i] - y[i - 1]);
        var l = new double[n + 1];
        var mu = new double[n + 1];
        var z = new double[n + 1];
        var c = new double[n + 1];
        var b = new double[n];
        var d = new double[n];
        l[0] = 1;
        for (var i = 1; i < n; i++)
        {
            l[i] = 2 * (x[i + 1] - x[i - 1]) - h[i - 1] * mu[i - 1];
            mu[i] = h[i] / l[i];
            z[i] = (alpha[i] - h[i - 1] * z[i - 1]) / l[i];
        }
        l[n] = 1;
        for (var j = n - 1; j >= 0; j--)
        {
            c[j] = z[j] - mu[j] * c[j + 1];
            b[j] = (y[j + 1] - y[j]) / h[j] - h[j] * (c[j + 1] + 2 * c[j]) / 3;
            d[j] = (c[j + 1] - c[j]) / (3 * h[j]);
        }
        return new(x.ToArray(), y.Take(n).ToArray(), b, c.Take(n).ToArray(), d);
    }

    private double LogGamma(double value) => Math.Log(Gamma(value));

    private static double Erf(double value)
    {
        // Abramowitz-Stegun 7.1.26; erro máximo aproximado 1,5e-7.
        var sign = Math.Sign(value);
        var x = Math.Abs(value);
        var t = 1 / (1 + .3275911 * x);
        var polynomial = (((((1.061405429 * t - 1.453152027) * t) + 1.421413741) * t
                           - .284496736) * t + .254829592) * t;
        return sign * (1 - polynomial * Math.Exp(-x * x));
    }

    private static double[] NumericalGradient(Func<IReadOnlyList<double>, double> function, double[] point)
    {
        var gradient = new double[point.Length];
        for (var i = 0; i < point.Length; i++)
        {
            var h = Math.Max(1e-7, Math.Abs(point[i]) * 1e-7);
            var plus = (double[])point.Clone();
            var minus = (double[])point.Clone();
            plus[i] += h;
            minus[i] -= h;
            gradient[i] = (function(plus) - function(minus)) / (2 * h);
        }
        return gradient;
    }
}
