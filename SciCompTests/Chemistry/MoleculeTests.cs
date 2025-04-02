using SciComp.Chemistry;

namespace SciCompTests.Chemistry;

[TestClass]
public class MoleculeTests
{
    [TestMethod]
    public void ConstructMolecule()
    {
        var molecule = new Molecule("H2O");
        Assert.AreEqual(molecule.ToString(), "H2O");

        molecule = new Molecule("CH4");
        Assert.AreEqual(molecule.ToString(), "CH4");

        molecule = new Molecule("NaOH");
        Assert.AreEqual(molecule.ToString(), "NaOH");
    }
}
