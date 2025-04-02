namespace SciComp.Chemistry;

public class Atom
{
    public string Name { get; }
    public AtomSymbol Symbol { get; }
    public SIUnit AtomicMass => MolarMass / SIUnit.Constants.Avogadros;
    public SIUnit MolarMass { get; }
    private readonly int protons;
    private readonly int electrons;
    public int Charge { get => protons - electrons; }

    internal Atom(string name, AtomSymbol symbol, SIUnit molarMass)
    {
        Name = name;
        Symbol = symbol;
        MolarMass = molarMass;
        protons = (int)Symbol;
        electrons = (int)Symbol;
    }
}
