namespace SciComp.Chemistry;

public class Atom
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
}
