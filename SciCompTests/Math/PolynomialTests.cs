using SciComp.Math;

namespace SciCompTests.Math;

[TestClass]
public class PolynomialTests
{
    [TestMethod]
    public void TestParse()
    {
        var p = Polynomial.Parse("x^2 - 2x + 3");
        Assert.AreEqual(2, p.Degree);
        Assert.AreEqual("x^2 + -2x + 3", p.ToString());
    }
}
