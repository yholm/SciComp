namespace SciComp.Chemistry;

public class Atom : IEquatable<Atom>, IFactoryParsable<Atom>
{
    public string Name { get; }
    public AtomSymbol Symbol { get; }
    public SIUnit AtomicMass => MolarMass / SIUnit.Constants.Avogadros;
    public SIUnit MolarMass { get; }
    public int Protons { get; }
    public int Electrons { get; }
    public int Charge => Protons - Electrons;

    internal Atom(string name, AtomSymbol symbol, SIUnit molarMass)
    {
        Name = name;
        Symbol = symbol;
        MolarMass = molarMass;
        Protons = (int)Symbol;
        Electrons = (int)Symbol;
    }

    public static Atom Parse(string str)
    {
        if (!Enum.TryParse<AtomSymbol>(str, out var atom))
            throw new ArgumentException($"Invalid atom symbol: {str}");
        return new PeriodicTable()[atom];
    }

    public bool Equals(Atom? other)
    {
        return other is not null && Name == other.Name && Symbol == other.Symbol
            && MolarMass.Equals(other.MolarMass) && Protons == other.Protons && Electrons == other.Electrons;
    }

    public override bool Equals(object? obj)
    {
        return obj is Atom atom && Equals(atom);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Symbol, MolarMass, Protons, Electrons);
    }

    public static Molecule operator +(Atom lhs, Atom rhs)
    {
        return new Molecule(new Dictionary<Atom, int>
        {
            { lhs, 1 },
            { rhs, 1 }
        });
    }
}
