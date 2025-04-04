using System.Text;

namespace SciComp.Chemistry;

public class Molecule : IEquatable<Molecule>
{
    public Dictionary<Atom, int> Atoms { get; }

    public int Charge
    {
        get
        {
            static int delta((int Protons, int Electrons) x) => x.Protons - x.Electrons;

            return delta(Atoms.Keys
                .Select(static a => a.Protons)
                .Zip(Atoms.Keys.Select(static a => a.Electrons))
                .Aggregate(static (a, b) => (a.First + b.First, a.Second + b.Second)));
        }
    }
    public SIUnit MolarMass => Atoms.Keys.Select(static a => a.MolarMass).Aggregate(static (a, b) => a + b);

    public Molecule(string name)
    {
        var table = new PeriodicTable();
        Atoms = [];

        for (var i = 0; i < name.Length; i++)
        {
            var start = i;

            if (!char.IsUpper(name[i]))
                throw new ArgumentException("Invalid molecule");
                
            if (i + 1 < name.Length)
            {
                string? atomStr;
                if (char.IsLower(name[i + 1]))
                {
                    i++;
                    atomStr = name.Substring(start, i - start + 1);
                }
                else atomStr = name[i].ToString();

                if (!Enum.TryParse(atomStr, out AtomSymbol atom))
                    throw new ArgumentException("Invalid atom");

                if (i + 1 < name.Length && char.IsDigit(name[i + 1]))
                {
                    i++;
                    var count = (int)char.GetNumericValue(name[i]);
                    Atoms.Add(table[atom], count);
                }
                else Atoms.Add(table[atom], 1);
            }
            else
            {
                if (!Enum.TryParse(name[i].ToString(), out AtomSymbol atom))
                    throw new ArgumentException("Invalid atom");

                Atoms.Add(table[atom], 1);
            }
        }
    }

    public override bool Equals(object? obj)
    {
        return obj is Molecule molecule && Equals(molecule);
    }

    public bool Equals(Molecule? other)
    {
        return other is not null && Atoms.SequenceEqual(other.Atoms);
    }

    public override int GetHashCode()
    {
        return Atoms.GetHashCode();
    }

    public override string ToString()
    {
        var result = new StringBuilder();

        Atoms.ToList().ForEach(pair =>
        {
            result.Append(pair.Key.Symbol.ToString());
            if (pair.Value > 1) result.Append(pair.Value);
        });

        return result.ToString();
    }
}
