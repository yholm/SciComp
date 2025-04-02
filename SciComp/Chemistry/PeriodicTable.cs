using System.Collections;

namespace SciComp.Chemistry;

public class PeriodicTable : IReadOnlyDictionary<AtomSymbol, Atom>
{
    private readonly List<Atom> atoms;

    public PeriodicTable()
    {
        atoms =
        [
            new Atom("Hydrogen", AtomSymbol.H, SIUnit.Gram(1.007) / SIUnit.Mole(1)),
            new Atom("Helium", AtomSymbol.He, SIUnit.Gram(4.002) / SIUnit.Mole(1)),
            new Atom("Lithium", AtomSymbol.Li, SIUnit.Gram(6.94) / SIUnit.Mole(1)),
            new Atom("Beryllium", AtomSymbol.Be, SIUnit.Gram(9.0122) / SIUnit.Mole(1)),
            new Atom("Boron", AtomSymbol.B, SIUnit.Gram(10.81) / SIUnit.Mole(1)),
            new Atom("Carbon", AtomSymbol.C, SIUnit.Gram(12.011) / SIUnit.Mole(1)),
            new Atom("Nitrogen", AtomSymbol.N, SIUnit.Gram(14.007) / SIUnit.Mole(1)),
            new Atom("Oxygen", AtomSymbol.O, SIUnit.Gram(15.999) / SIUnit.Mole(1)),
            new Atom("Fluorine", AtomSymbol.F, SIUnit.Gram(18.998) / SIUnit.Mole(1)),
            new Atom("Neon", AtomSymbol.Ne, SIUnit.Gram(20.180) / SIUnit.Mole(1)),
            new Atom("Sodium", AtomSymbol.Na, SIUnit.Gram(22.990) / SIUnit.Mole(1)),
            new Atom("Magnesium", AtomSymbol.Mg, SIUnit.Gram(24.305) / SIUnit.Mole(1)),
            new Atom("Aluminum", AtomSymbol.Al, SIUnit.Gram(26.982) / SIUnit.Mole(1)),
            new Atom("Silicon", AtomSymbol.Si, SIUnit.Gram(28.085) / SIUnit.Mole(1)),
            new Atom("Phosphorus", AtomSymbol.P, SIUnit.Gram(30.974) / SIUnit.Mole(1)),
            new Atom("Sulfur", AtomSymbol.S, SIUnit.Gram(32.06) / SIUnit.Mole(1)),
            new Atom("Chlorine", AtomSymbol.Cl, SIUnit.Gram(35.45) / SIUnit.Mole(1)),
            new Atom("Argon", AtomSymbol.Ar, SIUnit.Gram(39.948) / SIUnit.Mole(1)),
            new Atom("Potassium", AtomSymbol.K, SIUnit.Gram(39.098) / SIUnit.Mole(1)),
            new Atom("Calcium", AtomSymbol.Ca, SIUnit.Gram(40.078) / SIUnit.Mole(1)),
            new Atom("Scandium", AtomSymbol.Sc, SIUnit.Gram(44.956) / SIUnit.Mole(1)),
            new Atom("Titanium", AtomSymbol.Ti, SIUnit.Gram(47.867) / SIUnit.Mole(1)),
            new Atom("Vanadium", AtomSymbol.V, SIUnit.Gram(50.942) / SIUnit.Mole(1)),
            new Atom("Chromium", AtomSymbol.Cr, SIUnit.Gram(51.996) / SIUnit.Mole(1)),
            new Atom("Manganese", AtomSymbol.Mn, SIUnit.Gram(54.938) / SIUnit.Mole(1)),
            new Atom("Iron", AtomSymbol.Fe, SIUnit.Gram(55.845) / SIUnit.Mole(1)),
            new Atom("Cobalt", AtomSymbol.Co, SIUnit.Gram(58.933) / SIUnit.Mole(1)),
            new Atom("Nickel", AtomSymbol.Ni, SIUnit.Gram(58.693) / SIUnit.Mole(1)),
            new Atom("Copper", AtomSymbol.Cu, SIUnit.Gram(63.546) / SIUnit.Mole(1)),
            new Atom("Zinc", AtomSymbol.Zn, SIUnit.Gram(65.38) / SIUnit.Mole(1)),
            new Atom("Gallium", AtomSymbol.Ga, SIUnit.Gram(69.723) / SIUnit.Mole(1)),
            new Atom("Germanium", AtomSymbol.Ge, SIUnit.Gram(72.63) / SIUnit.Mole(1)),
            new Atom("Arsenic", AtomSymbol.As, SIUnit.Gram(74.922) / SIUnit.Mole(1)),
            new Atom("Selenium", AtomSymbol.Se, SIUnit.Gram(78.96) / SIUnit.Mole(1)),
            new Atom("Bromine", AtomSymbol.Br, SIUnit.Gram(79.904) / SIUnit.Mole(1)),
            new Atom("Krypton", AtomSymbol.Kr, SIUnit.Gram(83.798) / SIUnit.Mole(1)),
            new Atom("Rubidium", AtomSymbol.Rb, SIUnit.Gram(85.468) / SIUnit.Mole(1)),
            new Atom("Strontium", AtomSymbol.Sr, SIUnit.Gram(87.62) / SIUnit.Mole(1)),
            new Atom("Yttrium", AtomSymbol.Y, SIUnit.Gram(88.906) / SIUnit.Mole(1)),
            new Atom("Zirconium", AtomSymbol.Zr, SIUnit.Gram(91.224) / SIUnit.Mole(1)),
            new Atom("Niobium", AtomSymbol.Nb, SIUnit.Gram(92.906) / SIUnit.Mole(1)),
            new Atom("Molybdenum", AtomSymbol.Mo, SIUnit.Gram(95.95) / SIUnit.Mole(1)),
            new Atom("Technetium", AtomSymbol.Tc, SIUnit.Gram(98.0) / SIUnit.Mole(1)),
            new Atom("Ruthenium", AtomSymbol.Ru, SIUnit.Gram(101.07) / SIUnit.Mole(1)),
            new Atom("Rhodium", AtomSymbol.Rh, SIUnit.Gram(102.91) / SIUnit.Mole(1)),
            new Atom("Palladium", AtomSymbol.Pd, SIUnit.Gram(106.42) / SIUnit.Mole(1)),
            new Atom("Silver", AtomSymbol.Ag, SIUnit.Gram(107.87) / SIUnit.Mole(1)),
            new Atom("Cadmium", AtomSymbol.Cd, SIUnit.Gram(112.41) / SIUnit.Mole(1)),
            new Atom("Indium", AtomSymbol.In, SIUnit.Gram(114.82) / SIUnit.Mole(1)),
            new Atom("Tin", AtomSymbol.Sn, SIUnit.Gram(118.71) / SIUnit.Mole(1)),
            new Atom("Antimony", AtomSymbol.Sb, SIUnit.Gram(121.76) / SIUnit.Mole(1)),
            new Atom("Tellurium", AtomSymbol.Te, SIUnit.Gram(127.60) / SIUnit.Mole(1)),
            new Atom("Iodine", AtomSymbol.I, SIUnit.Gram(126.90) / SIUnit.Mole(1)),
            new Atom("Xenon", AtomSymbol.Xe, SIUnit.Gram(131.29) / SIUnit.Mole(1)),
            new Atom("Cesium", AtomSymbol.Cs, SIUnit.Gram(132.91) / SIUnit.Mole(1)),
            new Atom("Barium", AtomSymbol.Ba, SIUnit.Gram(137.33) / SIUnit.Mole(1)),
            new Atom("Lanthanum", AtomSymbol.La, SIUnit.Gram(138.91) / SIUnit.Mole(1)),
            new Atom("Cerium", AtomSymbol.Ce, SIUnit.Gram(140.12) / SIUnit.Mole(1)),
            new Atom("Praseodymium", AtomSymbol.Pr, SIUnit.Gram(140.91) / SIUnit.Mole(1)),
            new Atom("Neodymium", AtomSymbol.Nd, SIUnit.Gram(144.24) / SIUnit.Mole(1)),
            new Atom("Promethium", AtomSymbol.Pm, SIUnit.Gram(145.0) / SIUnit.Mole(1)),
            new Atom("Samarium", AtomSymbol.Sm, SIUnit.Gram(150.36) / SIUnit.Mole(1)),
            new Atom("Europium", AtomSymbol.Eu, SIUnit.Gram(151.96) / SIUnit.Mole(1)),
            new Atom("Gadolinium", AtomSymbol.Gd, SIUnit.Gram(157.25) / SIUnit.Mole(1)),
            new Atom("Terbium", AtomSymbol.Tb, SIUnit.Gram(158.93) / SIUnit.Mole(1)),
            new Atom("Dysprosium", AtomSymbol.Dy, SIUnit.Gram(162.50) / SIUnit.Mole(1)),
            new Atom("Holmium", AtomSymbol.Ho, SIUnit.Gram(164.93) / SIUnit.Mole(1)),
            new Atom("Erbium", AtomSymbol.Er, SIUnit.Gram(167.26) / SIUnit.Mole(1)),
            new Atom("Thulium", AtomSymbol.Tm, SIUnit.Gram(168.93) / SIUnit.Mole(1)),
            new Atom("Ytterbium", AtomSymbol.Yb, SIUnit.Gram(173.04) / SIUnit.Mole(1)),
            new Atom("Lutetium", AtomSymbol.Lu, SIUnit.Gram(174.97) / SIUnit.Mole(1)),
            new Atom("Hafnium", AtomSymbol.Hf, SIUnit.Gram(178.49) / SIUnit.Mole(1)),
            new Atom("Tantalum", AtomSymbol.Ta, SIUnit.Gram(180.95) / SIUnit.Mole(1)),
            new Atom("Tungsten", AtomSymbol.W, SIUnit.Gram(183.84) / SIUnit.Mole(1)),
            new Atom("Rhenium", AtomSymbol.Re, SIUnit.Gram(186.21) / SIUnit.Mole(1)),
            new Atom("Osmium", AtomSymbol.Os, SIUnit.Gram(190.23) / SIUnit.Mole(1)),
            new Atom("Iridium", AtomSymbol.Ir, SIUnit.Gram(192.22) / SIUnit.Mole(1)),
            new Atom("Platinum", AtomSymbol.Pt, SIUnit.Gram(195.08) / SIUnit.Mole(1)),
            new Atom("Gold", AtomSymbol.Au, SIUnit.Gram(196.97) / SIUnit.Mole(1)),
            new Atom("Mercury", AtomSymbol.Hg, SIUnit.Gram(200.59) / SIUnit.Mole(1)),
            new Atom("Thallium", AtomSymbol.Tl, SIUnit.Gram(204.38) / SIUnit.Mole(1)),
            new Atom("Lead", AtomSymbol.Pb, SIUnit.Gram(207.2) / SIUnit.Mole(1)),
            new Atom("Bismuth", AtomSymbol.Bi, SIUnit.Gram(208.98) / SIUnit.Mole(1)),
            new Atom("Polonium", AtomSymbol.Po, SIUnit.Gram(209.0) / SIUnit.Mole(1)),
            new Atom("Astatine", AtomSymbol.At, SIUnit.Gram(210.0) / SIUnit.Mole(1)),
            new Atom("Radon", AtomSymbol.Rn, SIUnit.Gram(222.0) / SIUnit.Mole(1)),
            new Atom("Francium", AtomSymbol.Fr, SIUnit.Gram(223.0) / SIUnit.Mole(1)),
            new Atom("Radium", AtomSymbol.Ra, SIUnit.Gram(226.0) / SIUnit.Mole(1)),
            new Atom("Actinium", AtomSymbol.Ac, SIUnit.Gram(227.0) / SIUnit.Mole(1)),
            new Atom("Thorium", AtomSymbol.Th, SIUnit.Gram(232.04) / SIUnit.Mole(1)),
            new Atom("Protactinium", AtomSymbol.Pa, SIUnit.Gram(231.04) / SIUnit.Mole(1)),
            new Atom("Uranium", AtomSymbol.U, SIUnit.Gram(238.03) / SIUnit.Mole(1)),
            new Atom("Neptunium", AtomSymbol.Np, SIUnit.Gram(237.0) / SIUnit.Mole(1)),
            new Atom("Plutonium", AtomSymbol.Pu, SIUnit.Gram(244.0) / SIUnit.Mole(1)),
            new Atom("Americium", AtomSymbol.Am, SIUnit.Gram(243.0) / SIUnit.Mole(1)),
            new Atom("Curium", AtomSymbol.Cm, SIUnit.Gram(247.0) / SIUnit.Mole(1)),
            new Atom("Berkelium", AtomSymbol.Bk, SIUnit.Gram(247.0) / SIUnit.Mole(1)),
            new Atom("Californium", AtomSymbol.Cf, SIUnit.Gram(251.0) / SIUnit.Mole(1)),
            new Atom("Einsteinium", AtomSymbol.Es, SIUnit.Gram(252.0) / SIUnit.Mole(1)),
            new Atom("Fermium", AtomSymbol.Fm, SIUnit.Gram(257.0) / SIUnit.Mole(1)),
            new Atom("Mendelevium", AtomSymbol.Md, SIUnit.Gram(258.0) / SIUnit.Mole(1)),
            new Atom("Nobelium", AtomSymbol.No, SIUnit.Gram(259.0) / SIUnit.Mole(1)),
            new Atom("Lawrencium", AtomSymbol.Lr, SIUnit.Gram(262.0) / SIUnit.Mole(1)),
            new Atom("Rutherfordium", AtomSymbol.Rf, SIUnit.Gram(267.0) / SIUnit.Mole(1)),
            new Atom("Dubnium", AtomSymbol.Db, SIUnit.Gram(270.0) / SIUnit.Mole(1)),
            new Atom("Seaborgium", AtomSymbol.Sg, SIUnit.Gram(271.0) / SIUnit.Mole(1)),
            new Atom("Bohrium", AtomSymbol.Bh, SIUnit.Gram(270.0) / SIUnit.Mole(1)),
            new Atom("Hassium", AtomSymbol.Hs, SIUnit.Gram(277.0) / SIUnit.Mole(1)),
            new Atom("Meitnerium", AtomSymbol.Mt, SIUnit.Gram(276.0) / SIUnit.Mole(1)),
            new Atom("Darmstadtium", AtomSymbol.Ds, SIUnit.Gram(281.0) / SIUnit.Mole(1)),
            new Atom("Roentgenium", AtomSymbol.Rg, SIUnit.Gram(282.0) / SIUnit.Mole(1)),
            new Atom("Copernicium", AtomSymbol.Cn, SIUnit.Gram(285.0) / SIUnit.Mole(1)),
            new Atom("Nihonium", AtomSymbol.Nh, SIUnit.Gram(286.0) / SIUnit.Mole(1)),
            new Atom("Flerovium", AtomSymbol.Fl, SIUnit.Gram(289.0) / SIUnit.Mole(1)),
            new Atom("Moscovium", AtomSymbol.Mc, SIUnit.Gram(290.0) / SIUnit.Mole(1)),
            new Atom("Livermorium", AtomSymbol.Lv, SIUnit.Gram(293.0) / SIUnit.Mole(1)),
            new Atom("Tennessine", AtomSymbol.Ts, SIUnit.Gram(294.0) / SIUnit.Mole(1)),
            new Atom("Oganesson", AtomSymbol.Og, SIUnit.Gram(294.0) / SIUnit.Mole(1))
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
