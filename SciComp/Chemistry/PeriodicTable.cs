namespace SciComp.Chemistry;

public enum AtomSymbol
{
    H, He
}

public class Atom
{
    public string Name { get; }
    public AtomSymbol Symbol { get; }
    public SIUnit AtomicMass { get => MolarMass / SIUnit.Constants.Avogadros; }
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

public class PeriodicTable : IReadOnlyDictionary<AtomSymbol, Atom>
{
    private List<Atom> atoms;

    public PeriodicTable()
    {
        atoms =
        [
            new Atom("Hydrogen", AtomSymbol.H, SIUnit.Gram(1.007) / SIUnit.Mole(1)),
            new Atom("Helium", AtomSymbol.He, SIUnit.Gram(4.002) / SIUnit.Mole(1)),
        ];
    }

    public bool ContainsKey(AtomSymbol symbol)
    {
        return atoms.Any(a => a.Symbol == symbol);
    }

    public bool TryGetValue(AtomSymbol symbol, out Atom atom)
    {
        if (!ContainsKey(symbol))
        {
            atom = Activator.CreateInstance<Atom>();
            return false;
        }

        atom = atoms.First(a => a.Symbol == symbol);
        return true;
    }

    public Atom this[AtomSymbol symbol] { get => atoms.First(a => a.Symbol == symbol); }

    public IEnumerable<AtomSymbol> Keys { get => atoms.Select(a => a.Symbol).ToArray(); }
    public IEnumerable<Atom> Values { get => atoms.AsEnumerable(); }

    public int Count { get => atoms.Count; }

    public IEnumerator<KeyValuePair<AtomSymbol, Atom>> GetEnumerator()
    {
        foreach (var atom in atoms)
        {
            yield return new KeyValuePair<AtomSymbol, Atom>(atom.Symbol, atom);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
