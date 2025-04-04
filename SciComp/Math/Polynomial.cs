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
        if (n == 1) return $"{c}x";
        return $"{c}x^{n}";
    }
}
