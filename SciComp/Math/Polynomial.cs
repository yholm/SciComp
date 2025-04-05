using System.Security;

namespace SciComp.Math;

public class Polynomial : IMathFunc
{
    private readonly double[] coefficients;
    public int Degree => coefficients.Length - 1;

    public Polynomial(double[] coefficients)
    {
        this.coefficients = [.. coefficients.Reverse()];
    }

    public double Evaluate(double x)
    {
        return coefficients.
            Select((c, n) => Monomial(n, c)(x)).
            Sum();
    }
    private static Func<double, double> Monomial(int n, double c)
    {
        return x => c * System.Math.Pow(x, n);
    }

    public IMathFunc Derivative()
    {
        return new Polynomial([.. coefficients.Select(static (c, n) => c * n).Skip(1)]);
    }
    public IMathFunc Integral(double c)
    {
        return new Polynomial([c, .. coefficients.Select(static (c, n) => c / (n + 1))]);
    }

    public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
    {
        return new Polynomial([.. lhs.coefficients.Zip(rhs.coefficients, static (x, y) => x + y)]);
    }
    public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
    {
        return new Polynomial([.. lhs.coefficients.Zip(rhs.coefficients, static (x, y) => x - y)]);
    }

    public static Polynomial Parse(string str)
    {
        var parts = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var coefficients = new double[parts.Where(static s => !(s == "+") && !(s == "-")).Count()];

        var isNegative = false;

        foreach (var part in parts)
        {
            if (part == "+") continue;
            if (part == "-")
            {
                isNegative = true;
                continue;
            }

            if (!part.Contains('x'))
            {
                if (double.TryParse(part, out var c))
                {
                    if (isNegative) c *= -1;
                    coefficients[0] += c;
                }
                else
                {
                    throw new FormatException($"Invalid coefficient: {part}");
                }
                continue;
            }

            var monomial = part.Split(['x', '^'], StringSplitOptions.RemoveEmptyEntries);
            if (monomial.Length == 0) continue;

            if (part[0] == 'x')
            {
                var degree = monomial.Length == 1 ? int.Parse(monomial[0]) : 1;
                var coefficient = isNegative ? -1 : 1;
                coefficients[degree] += coefficient;
            }
            else
            {
                var coefficient = double.Parse(monomial[0]);
                if (isNegative) coefficient *= -1;
                var degree = monomial.Length > 1 ? int.Parse(monomial[1]) : 1;
                coefficients[degree] += coefficient;
            }

            isNegative = false;
        }

        return new Polynomial([.. coefficients.Reverse()]);
    }

    public override string ToString()
    {
        return coefficients.
            Select(static (c, n) => MonomialStr(n, c)).
            Where(static s => s != "").
            Reverse().
            Aggregate("", static (acc, s) => acc == "" ? s : $"{acc} + {s}");
    }
    private static string MonomialStr(int n, double c)
    {
        if (c == 0) return "";
        if (n == 0) return c.ToString();
        if (c == 1) return n == 1 ? "x" : $"x^{n}";
        if (c == -1) return n == 1 ? "(-x)" : $"(-x^{n})";
        if (n == 1) return $"{c}x";
        return $"{c}x^{n}";
    }
}
