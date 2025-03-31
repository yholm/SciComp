using System.Text;

namespace SciComp;

public class SIUnit : IEquatable<SIUnit>, IComparable<SIUnit>
{
    public double Value { get; private set; }
    readonly Dictionary<DimensionType, Dimension> dimensions;

    private SIUnit(double value, Dictionary<DimensionType, Dimension> dimensions)
    {
        Value = value;
        this.dimensions = dimensions;
    }

    public static SIUnit Meter(double value)
    {
        return new SIUnit(value, new Dictionary<DimensionType, Dimension>()
        {
            [DimensionType.Length] = new Dimension(1),
            [DimensionType.Mass] = new Dimension(0),
            [DimensionType.Time] = new Dimension(0),
            [DimensionType.ElectricCurrent] = new Dimension(0),
            [DimensionType.Temperature] = new Dimension(0),
            [DimensionType.AmountOfSubstance] = new Dimension(0),
            [DimensionType.LuminousIntensity] = new Dimension(0)
        });
    }
    public static SIUnit Kilogram(double value)
    {
        return new SIUnit(value, new Dictionary<DimensionType, Dimension>()
        {
            [DimensionType.Length] = new Dimension(0),
            [DimensionType.Mass] = new Dimension(1, Prefix.Kilo),
            [DimensionType.Time] = new Dimension(0),
            [DimensionType.ElectricCurrent] = new Dimension(0),
            [DimensionType.Temperature] = new Dimension(0),
            [DimensionType.AmountOfSubstance] = new Dimension(0),
            [DimensionType.LuminousIntensity] = new Dimension(0)
        });
    }
    public static SIUnit Gram(double value)
    {
        return new SIUnit(value, new Dictionary<DimensionType, Dimension>()
        {
            [DimensionType.Length] = new Dimension(0),
            [DimensionType.Mass] = new Dimension(1),
            [DimensionType.Time] = new Dimension(0),
            [DimensionType.ElectricCurrent] = new Dimension(0),
            [DimensionType.Temperature] = new Dimension(0),
            [DimensionType.AmountOfSubstance] = new Dimension(0),
            [DimensionType.LuminousIntensity] = new Dimension(0)
        });
    }
    public static SIUnit Second(double value)
    {
        return new SIUnit(value, new Dictionary<DimensionType, Dimension>()
        {
            [DimensionType.Length] = new Dimension(0),
            [DimensionType.Mass] = new Dimension(0),
            [DimensionType.Time] = new Dimension(1),
            [DimensionType.ElectricCurrent] = new Dimension(0),
            [DimensionType.Temperature] = new Dimension(0),
            [DimensionType.AmountOfSubstance] = new Dimension(0),
            [DimensionType.LuminousIntensity] = new Dimension(0)
        });
    }
    public static SIUnit Ampere(double value)
    {
        return new SIUnit(value, new Dictionary<DimensionType, Dimension>()
        {
            [DimensionType.Length] = new Dimension(0),
            [DimensionType.Mass] = new Dimension(0),
            [DimensionType.Time] = new Dimension(0),
            [DimensionType.ElectricCurrent] = new Dimension(1),
            [DimensionType.Temperature] = new Dimension(0),
            [DimensionType.AmountOfSubstance] = new Dimension(0),
            [DimensionType.LuminousIntensity] = new Dimension(0)
        });
    }
    public static SIUnit Kelvin(double value)
    {
        return new SIUnit(value, new Dictionary<DimensionType, Dimension>()
        {
            [DimensionType.Length] = new Dimension(0),
            [DimensionType.Mass] = new Dimension(0),
            [DimensionType.Time] = new Dimension(0),
            [DimensionType.ElectricCurrent] = new Dimension(0),
            [DimensionType.Temperature] = new Dimension(1),
            [DimensionType.AmountOfSubstance] = new Dimension(0),
            [DimensionType.LuminousIntensity] = new Dimension(0)
        });
    }
    public static SIUnit Mole(double value)
    {
        return new SIUnit(value, new Dictionary<DimensionType, Dimension>()
        {
            [DimensionType.Length] = new Dimension(0),
            [DimensionType.Mass] = new Dimension(0),
            [DimensionType.Time] = new Dimension(0),
            [DimensionType.ElectricCurrent] = new Dimension(0),
            [DimensionType.Temperature] = new Dimension(0),
            [DimensionType.AmountOfSubstance] = new Dimension(1),
            [DimensionType.LuminousIntensity] = new Dimension(0)
        });
    }
    public static SIUnit Candela(double value)
    {
        return new SIUnit(value, new Dictionary<DimensionType, Dimension>()
        {
            [DimensionType.Length] = new Dimension(0),
            [DimensionType.Mass] = new Dimension(0),
            [DimensionType.Time] = new Dimension(0),
            [DimensionType.ElectricCurrent] = new Dimension(0),
            [DimensionType.Temperature] = new Dimension(0),
            [DimensionType.AmountOfSubstance] = new Dimension(0),
            [DimensionType.LuminousIntensity] = new Dimension(1)
        });
    }
    
    public static SIUnit Hertz(double value)
    {
        return value * Second(1).Pow(-1);
    }
    public static SIUnit Newton(double value)
    {
        return Kilogram(value) * Meter(1).Pow(2) * Second(1).Pow(-2);
    }
    public static SIUnit Pascal(double value)
    {
        return Newton(value) * Meter(1).Pow(-2);
    }
    public static SIUnit Joule(double value)
    {
        return Newton(value) * Meter(1);
    }
    public static SIUnit Watt(double value)
    {
        return Joule(value) * Second(1).Pow(-1);
    }
    public static SIUnit Coulomb(double value)
    {
        return Ampere(value) * Second(1);
    }
    public static SIUnit Volt(double value)
    {
        return Watt(value) * Ampere(1).Pow(-1);
    }
    public static SIUnit Ohm(double value)
    {
        return Volt(value) * Ampere(1).Pow(-1);
    }

    public void SetPrefix(DimensionType dimension, Prefix prefix)
    {
        var oldFactor = this[dimension].GetFactor();
        this[dimension].Prefix = prefix;
        var newFactor = this[dimension].GetFactor();
        Value = newFactor * Value / oldFactor;
    }

    public SIUnit Pow(int exponent)
    {
        var dimensions = new Dictionary<DimensionType, Dimension>();

        foreach (var (type, dimension) in this.dimensions)
        {
            dimensions[type] = new Dimension(dimension.Exponent * exponent, dimension.Prefix);
        }

        return new SIUnit(System.Math.Pow(Value, exponent), dimensions);
    }

    public void Round(int digits)
    {
        Value = System.Math.Round(Value, digits);
    }

    private double GetFactor()
    {
        return dimensions.Values.Select(static d => d.GetFactor()).ToList().Aggregate(1.0, static (a, b) => a * b);
    }

    public Dimension this[DimensionType dimensionType] => dimensions[dimensionType];

    public void Deconstruct(out double value, out SIUnit dimensions)
    {
        value = Value;
        dimensions = new SIUnit(1, this.dimensions);
    }

    private bool DimensionsEqual(SIUnit other)
    {
        foreach (var (type, dimension) in dimensions)
        {
            if (!dimension.Equals(other[type])) return false;
        }
        return true;
    }

    public bool IsDimensionless()
    {
        var (_, dimensions) = this;
        return Pow(0) == dimensions;
    }

    public override bool Equals(object? obj)
    {
        return obj is SIUnit unit && Equals(unit);
    }

    public bool Equals(SIUnit? other)
    {
        return other is not null 
            && DimensionsEqual(other) 
            && (Value * GetFactor()) == (other.Value * other.GetFactor());
    }

    public int CompareTo(SIUnit? other)
    {
        if (other is null) return 1;
        if (!DimensionsEqual(other)) 
            throw new DimensionalMismatchException("Cannot compare units with different dimensions");
        return (Value * GetFactor()).CompareTo(other.Value * other.GetFactor());

    }

    public static explicit operator double(SIUnit unit)
    {
        if (!unit.IsDimensionless())
            throw new DimensionalMismatchException("Can only cast dimensionless quantities");
        return unit.Value;
    }
    public static explicit operator SIUnit(double value)
    {
        return new SIUnit(value, new Dictionary<DimensionType, Dimension>()
        {
            [DimensionType.Length] = new Dimension(1),
            [DimensionType.Mass] = new Dimension(0),
            [DimensionType.Time] = new Dimension(0),
            [DimensionType.ElectricCurrent] = new Dimension(0),
            [DimensionType.Temperature] = new Dimension(0),
            [DimensionType.AmountOfSubstance] = new Dimension(0),
            [DimensionType.LuminousIntensity] = new Dimension(0)
        });
    }

    public static bool operator >(SIUnit lhs, SIUnit rhs)
    {
        return lhs.CompareTo(rhs) > 0;
    }
    public static bool operator <(SIUnit lhs, SIUnit rhs)
    {
        return lhs.CompareTo(rhs) < 0;
    }
    public static bool operator >=(SIUnit lhs, SIUnit rhs)
    {
        return !(lhs < rhs);
    }
    public static bool operator <=(SIUnit lhs, SIUnit rhs)
    {
        return !(lhs > rhs);
    }
    public static bool operator ==(SIUnit lhs, SIUnit rhs)
    {
        return lhs.Equals(rhs);
    }
    public static bool operator !=(SIUnit lhs, SIUnit rhs)
    {
        return !lhs.Equals(rhs);
    }

    public static SIUnit operator +(SIUnit lhs, SIUnit rhs)
    {
        if (!lhs.DimensionsEqual(rhs))
            throw new DimensionalMismatchException("Cannot add units of different dimensions");
        return new SIUnit((lhs.Value * lhs.GetFactor() + rhs.Value * rhs.GetFactor()) / lhs.GetFactor(),
            lhs.dimensions);
    }
    public static SIUnit operator -(SIUnit lhs, SIUnit rhs)
    {
        if (!lhs.DimensionsEqual(rhs))
            throw new DimensionalMismatchException("Cannot subtract units of different dimensions");
        return new SIUnit((lhs.Value * lhs.GetFactor() - rhs.Value * rhs.GetFactor()) / lhs.GetFactor(),
            lhs.dimensions);
    }
    public static SIUnit operator *(SIUnit lhs, SIUnit rhs)
    {
        var dimensions = new Dictionary<DimensionType, Dimension>();
        foreach (var (type, dimension) in lhs.dimensions)
        {
            dimensions[type] = dimension * rhs[type];
        }

        var result = new SIUnit(lhs.Value * lhs.GetFactor() * rhs.Value * rhs.GetFactor(),
            dimensions);

        foreach (var (type, dimension) in lhs.dimensions) 
        {
            result.SetPrefix(type, dimension.Prefix);
        }

        return result;
    }
    public static SIUnit operator /(SIUnit lhs, SIUnit rhs)
    {
        if (rhs.Value == 0) throw new DivideByZeroException("Cannot divide by zero");
        return lhs * rhs.Pow(-1);
    }
    public static SIUnit operator *(SIUnit lhs, double rhs)
    {
        return new SIUnit(lhs.Value * rhs, lhs.dimensions);
    }
    public static SIUnit operator *(double lhs, SIUnit rhs)
    {
        return rhs * lhs;
    }
    public static SIUnit operator /(SIUnit lhs, double rhs)
    {
        if (rhs == 0) throw new DivideByZeroException("Cannot divide by zero");
        return new SIUnit(lhs.Value / rhs, lhs.dimensions);
    }
    public static SIUnit operator /(double lhs, SIUnit rhs)
    {
        if (rhs.Value == 0) throw new DivideByZeroException("Cannot divide by zero");
        return lhs * rhs.Pow(-1);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, dimensions);
    }

    public override string ToString()
    {
        var baseSymbols = new Dictionary<DimensionType, string>()
        {
            [DimensionType.Length] = "m",
            [DimensionType.Mass] = "g",
            [DimensionType.Time] = "s",
            [DimensionType.ElectricCurrent] = "A",
            [DimensionType.Temperature] = "K",
            [DimensionType.AmountOfSubstance] = "mol",
            [DimensionType.LuminousIntensity] = "cd"
        };

        var prefixSymbols = new Dictionary<Prefix, string>
        {
            [Prefix.Yocto] = "y",
            [Prefix.Zepto] = "z",
            [Prefix.Atto] = "a",
            [Prefix.Femto] = "f",
            [Prefix.Pico] = "p",
            [Prefix.Nano] = "n",
            [Prefix.Micro] = "μ",
            [Prefix.Milli] = "m",
            [Prefix.Centi] = "c",
            [Prefix.Deci] = "d",
            [Prefix.None] = "",
            [Prefix.Deca] = "da",
            [Prefix.Hecto] = "h",
            [Prefix.Kilo] = "k",
            [Prefix.Mega] = "M",
            [Prefix.Giga] = "G",
            [Prefix.Tera] = "T",
            [Prefix.Peta] = "P",
            [Prefix.Exa] = "E",
            [Prefix.Zetta] = "Z",
            [Prefix.Yotta] = "Y"
        };

        var derivedSymbols = new Dictionary<string, string>()
        {
            ["s^-1"] = "Hz",
            ["m kg s^-2"] = "N",
            ["kg s^-2 m^-1"] = "Pa",
            ["m^2 kg s^-2"] = "J",
            ["m^2 kg s^-3"] = "W",
            ["s A"] = "C",
            ["m^2 kg s^-3 A^-1"] = "V",
            ["s^4 A^2 m^-1 kg^-1"] = "F",
            ["m^2 kg s^-3 A^-2"] = "Ω",
            ["s^3 A^2 m^-2 kg^-1"] = "S",
            ["m^2 kg s^-2 A^-1"] = "Wb",
            ["kg s^-2 A^-1"] = "T",
            ["m^2 kg s^-2 A^-2"] = "H",
            ["cd m^-2"] = "lx",
        };

        var units = new StringBuilder();

        foreach (var (type, dimension) in dimensions)
        {
            if (dimension.Exponent == 0) continue;
            if (units.Length != 0) units.Append(' ');
            units.Append(prefixSymbols[dimension.Prefix]);
            units.Append(baseSymbols[type]);
            if (dimension.Exponent != 1)
            {
                units.Append($"^{dimension.Exponent}");
            }
        }

        if (derivedSymbols.ContainsKey(units.ToString()))
        {
            var key = units.ToString();
            units.Clear();
            units.Append(derivedSymbols[key]);
        }

        return $"{Value} [{units}]";
    }
}
