using System.Text;

namespace SciComp;

public class SIUnit : IEquatable<SIUnit>, IComparable<SIUnit>, IFactoryParsable<SIUnit>
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
        return dimensions.Values
            .Select(static d => d.GetFactor())
            .Aggregate(1.0, static (a, b) => a * b);
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

    public static SIUnit Parse(string str)
    {
        var parts = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (!double.TryParse(parts[0], out var value)) throw new ArgumentException("Invalid SIUnit value");
        var result = (SIUnit)value;

        var symbols = new Dictionary<string, DimensionType>()
        {
            ["m"] = DimensionType.Length,
            ["g"] = DimensionType.Mass,
            ["s"] = DimensionType.Time,
            ["A"] = DimensionType.ElectricCurrent,
            ["K"] = DimensionType.Temperature,
            ["mol"] = DimensionType.AmountOfSubstance,
            ["cd"] = DimensionType.LuminousIntensity
        };
        var prefixes = new Dictionary<string, Prefix>()
        {
            ["y"] = Prefix.Yocto,
            ["z"] = Prefix.Zepto,
            ["a"] = Prefix.Atto,
            ["f"] = Prefix.Femto,
            ["p"] = Prefix.Pico,
            ["n"] = Prefix.Nano,
            ["μ"] = Prefix.Micro,
            ["m"] = Prefix.Milli,
            ["c"] = Prefix.Centi,
            ["d"] = Prefix.Deci,
            ["da"] = Prefix.Deca,
            ["h"] = Prefix.Hecto,
            ["k"] = Prefix.Kilo,
            ["M"] = Prefix.Mega,
            ["G"] = Prefix.Giga,
            ["T"] = Prefix.Tera,
            ["P"] = Prefix.Peta,
            ["E"] = Prefix.Exa,
            ["Z"] = Prefix.Zetta,
            ["Y"] = Prefix.Yotta
        };

        foreach (var part in parts)
        {
            if (part == parts[0]) continue;
            var prefix = Prefix.None;
            var dimension = DimensionType.Length;
            var symbol = part;
            var power = 1;

            for (var i = part.Length - 1; i >= 0; i--)
            {
                var start = i;

                if (part.Contains('^'))
                {
                    if (part[i] == '^')
                    {
                        if (i == 0) throw new ArgumentException("Invalid SIUnit format");
                        if (!int.TryParse(part[(i + 1)..], out power))
                            throw new ArgumentException("Invalid SIUnit format");
                        symbol = part[..i];
                    }
                    else continue;
                }
                

                while (i > 0 && !symbols.ContainsKey(symbol[i..])) i--;
                if (!symbols.TryGetValue(symbol[i..], out dimension))
                    throw new ArgumentException("Invalid SIUnit format");
                symbol = symbol[..i];

                if (!prefixes.TryGetValue(symbol, out prefix))
                {
                    prefix = Prefix.None;
                }
            }

            var temp = (SIUnit)1;
            temp.dimensions[dimension] = new Dimension(power, prefix);

            result *= temp;
        }

        return result;
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
            [DimensionType.Length] = new Dimension(0),
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

    public static class Constants
    {
        public static SIUnit SpeedOfLight => Meter(299_792_458) / Second(1);
        public static SIUnit Planck => Joule(6.62607015e-34) / Hertz(1);
        public static SIUnit ReducedPlanck => Planck / (2 * System.Math.PI);
        public static SIUnit Boltzmann => Joule(1.380649e-23) / Kelvin(1);
        public static SIUnit Gravitational => 6.67430e-11 * Meter(1).Pow(3) / Kilogram(1) / Second(1).Pow(2);
        public static SIUnit Cosmological => 1.089e-52 / Meter(1).Pow(2);
        public static SIUnit Avogadros => 6.02214076e23 / Mole(1);

        public static Dictionary<string, SIUnit> Symbols => new()
        {
            ["c"] = SpeedOfLight,
            ["h"] = Planck,
            ["ħ"] = ReducedPlanck,
            ["k"] = Boltzmann,
            ["k_b"] = Boltzmann,
            ["G"] = Gravitational,
            ["Λ"] = Cosmological,
            ["N_A"] = Avogadros,

        };
    }
}
