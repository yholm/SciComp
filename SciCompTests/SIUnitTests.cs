using SciComp;

namespace SciCompTests;

[TestClass]
public class SIUnitTests
{
    [TestMethod]
    public void SIUnitParseTest()
    {
        var unit = SIUnit.Parse("1 m s^-2");
        Assert.AreEqual(1.0, unit.Value);
        Assert.AreEqual("1 [m s^-2]", unit.ToString());
    }
}
