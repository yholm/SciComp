namespace SciComp;

public enum DimensionType
{
    Length,
    Mass,
    Time,
    ElectricCurrent,
    Temperature,
    AmountOfSubstance,
    LuminousIntensity
}

public class Dimension : IEquatable<Dimension>
{
    public Dimension(int exponent, Prefix prefix)
    {
        Exponent = exponent;
        Prefix = prefix;
    }

    public Dimension(int exponent)
    {
        Exponent = exponent;
        Prefix = Prefix.None;
    }

    public int Exponent { get; }
    public Prefix Prefix { get; internal set; }

    public double GetFactor() => System.Math.Pow(10, Exponent * (int)Prefix);

    public static Dimension operator *(Dimension lhs, Dimension rhs)
    {
        return new Dimension(lhs.Exponent + rhs.Exponent);
    }

    public static Dimension operator /(Dimension lhs, Dimension rhs)
    {
        return new Dimension(lhs.Exponent - rhs.Exponent);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Dimension dimension) return false;
        return Equals(dimension);
    }

    public bool Equals(Dimension? other)
    {
        if (other is null) return false;
        return Exponent == other.Exponent;
    }

    public override int GetHashCode()
    {
        return Exponent.GetHashCode();
    }
}
