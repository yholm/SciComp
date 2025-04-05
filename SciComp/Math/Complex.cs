namespace SciComp.Math;

public class Complex : IEquatable<Complex>, IEquatable<double>, IFactoryParsable<Complex>
{
    public double Real { get; }
    public double Imaginary { get; }

    public Complex(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (obj is Complex complex) return Equals(complex);
        if (obj is double other) return Equals(other); 
        return false;
    }

    public bool Equals(Complex? other)
    {
        return other is not null && Real == other.Real && Imaginary == other.Imaginary;
    }

    public bool Equals(double other)
    {
        return Imaginary == 0 && Real == other;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Real, Imaginary);
    }

    public Complex Conjugate()
    {
        return new Complex(Real, -Imaginary);
    }

    public double Magnitude()
    {
        return System.Math.Sqrt(Real * Real + Imaginary * Imaginary);
    }

    public static Complex operator +(Complex lhs, Complex rhs)
    {
        return new Complex(lhs.Real + rhs.Real, lhs.Imaginary + rhs.Imaginary);
    }
    public static Complex operator -(Complex lhs, Complex rhs)
    {
        return new Complex(lhs.Real - rhs.Real, lhs.Imaginary - rhs.Imaginary);
    }
    public static Complex operator +(Complex lhs, double rhs)
    {
        return new Complex(lhs.Real + rhs, lhs.Imaginary);
    }
    public static Complex operator +(double lhs, Complex rhs)
    {
        return rhs + lhs;
    }
    public static Complex operator -(Complex lhs, double rhs)
    {
        return new Complex(lhs.Real - rhs, lhs.Imaginary);
    }
    public static Complex operator -(double lhs, Complex rhs)
    {
        return new Complex(lhs - rhs.Real, -rhs.Imaginary);
    }
    public static Complex operator *(Complex lhs, Complex rhs)
    {
        return new Complex(lhs.Real * rhs.Real - lhs.Imaginary * rhs.Imaginary,
                           lhs.Real * rhs.Imaginary + lhs.Imaginary * rhs.Real);
    }
    public static Complex operator *(Complex lhs, double rhs)
    {
        return new Complex(lhs.Real * rhs, lhs.Imaginary * rhs);
    }
    public static Complex operator *(double lhs, Complex rhs)
    {
        return rhs * lhs;
    }
    public static Complex operator /(double lhs, Complex rhs)
    {
        return lhs * new Complex(rhs.Real / (rhs.Real * rhs.Real + rhs.Imaginary * rhs.Imaginary),
                           -rhs.Imaginary / (rhs.Real * rhs.Real + rhs.Imaginary * rhs.Imaginary));
    }
    public static Complex operator /(Complex lhs, Complex rhs)
    {
        return new Complex((lhs.Real * rhs.Real + lhs.Imaginary * rhs.Imaginary) 
                         / (rhs.Real * rhs.Real + rhs.Imaginary * rhs.Imaginary), 
                           (lhs.Imaginary * rhs.Real - lhs.Real * rhs.Imaginary) 
                         / (rhs.Real * lhs.Real + lhs.Imaginary * lhs.Imaginary));
    }

    public static Complex Parse(string str)
    {
        var parts = str.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(static s => s.Trim());
        var realPart = 0.0;
        var imaginaryPart = 0.0;

        var isNegative = false;

        foreach (var part in parts)
        {
            if (part == "+") continue;
            if (part == "-")
            {
                isNegative = true;
                continue;
            }

            if (part.Contains('i'))
            {
                var imaginaryStr = part.Replace("i", "");
                if (imaginaryStr == "")
                    imaginaryPart = 1;
                else if (double.TryParse(imaginaryStr, out var c))
                    imaginaryPart = isNegative ? -c : c;
            }
            else
            {
                if (double.TryParse(part, out var c))
                {
                    realPart += isNegative ? -c : c;
                }
            }

            isNegative = false;
        }

        return new Complex(realPart, imaginaryPart);
    }

    public override string ToString()
    {
        if (Imaginary == 0)
            return Real.ToString();
        if (Real == 0)
            return $"{Imaginary}i";
        if (Imaginary < 0)
            return $"{Real} - {-Imaginary}i";
        return $"{Real} + {Imaginary}i";
    }
}
