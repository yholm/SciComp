using SciComp.Math;

namespace SciCompTests.Math;

[TestClass]
public class MatrixTests
{
    [TestMethod]
    public void LinearTransformationTest()
    {
        var matrix = new Matrix([new([-1, 1]), new([-2, -1])]);
        var vector = new Vector([-3, 1]);

        Assert
    }
}
