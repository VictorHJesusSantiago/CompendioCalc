using System.Globalization;
using System.Numerics;

namespace CompendioCalc.Models;

public readonly record struct ExactRational : IComparable<ExactRational>
{
    public BigInteger Numerator { get; }
    public BigInteger Denominator { get; }

    public ExactRational(BigInteger numerator, BigInteger denominator)
    {
        if (denominator.IsZero) throw new DivideByZeroException();
        if (denominator.Sign < 0) { numerator = -numerator; denominator = -denominator; }
        var gcd = BigInteger.GreatestCommonDivisor(BigInteger.Abs(numerator), denominator);
        Numerator = numerator / gcd;
        Denominator = denominator / gcd;
    }

    public ExactRational(BigInteger integer) : this(integer, BigInteger.One) { }

    public static ExactRational Parse(string value)
    {
        var text = value.Trim();
        if (text.Contains('/'))
        {
            var pieces = text.Split('/', 2);
            return new(BigInteger.Parse(pieces[0], CultureInfo.InvariantCulture),
                BigInteger.Parse(pieces[1], CultureInfo.InvariantCulture));
        }
        var separator = text.IndexOfAny(['.', ',']);
        if (separator < 0) return new(BigInteger.Parse(text, CultureInfo.InvariantCulture));
        var sign = text.StartsWith('-') ? -1 : 1;
        text = text.TrimStart('+', '-').Replace(',', '.');
        separator = text.IndexOf('.');
        var decimals = text.Length - separator - 1;
        var numerator = BigInteger.Parse(text.Remove(separator, 1), CultureInfo.InvariantCulture) * sign;
        return new(numerator, BigInteger.Pow(10, decimals));
    }

    public double ToDouble() => (double)Numerator / (double)Denominator;
    public int CompareTo(ExactRational other) =>
        (Numerator * other.Denominator).CompareTo(other.Numerator * Denominator);
    public override string ToString() => Denominator.IsOne ? Numerator.ToString() : $"{Numerator}/{Denominator}";

    public static ExactRational operator +(ExactRational a, ExactRational b) =>
        new(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
    public static ExactRational operator -(ExactRational a, ExactRational b) =>
        new(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);
    public static ExactRational operator *(ExactRational a, ExactRational b) =>
        new(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
    public static ExactRational operator /(ExactRational a, ExactRational b) =>
        b.Numerator.IsZero ? throw new DivideByZeroException() :
        new(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
    public static ExactRational operator -(ExactRational value) => new(-value.Numerator, value.Denominator);
}
