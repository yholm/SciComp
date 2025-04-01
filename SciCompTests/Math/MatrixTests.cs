using SciComp.Math;

namespace SciCompTests.Math;

[TestClass]
public class MatrixTests
{
    [TestMethod]
    public void LinearTransformationTest()
    {
        var matrix = new Matrix(
        [
            new([-1, 1]),
            new([-2, -1])
        ]);
        var vector = new Vector([-3, 1]);
        var result = new Vector([1, -4]);

        Assert.AreEqual(result, matrix * vector);

        var matrix2 = new Matrix(
        [
            new([-1, 1]),
            new([-2, -1]),
            new([4, 2])
        ]);
        var vector2 = new Vector([-3, 1, 2]);

        Assert.AreEqual(new Vector([9, 0]), matrix2 * vector2);
    }

    [TestMethod]
    public void MatrixMultiplicationTest()
    {
        var matrix = new Matrix(
        [
            new([1, 4, 7]),
            new([2, 5, 8]),
            new([3, 6, 9])
        ]);
        var id = new Matrix(
        [
            new([1, 0, 0]),
            new([0, 1, 0]),
            new([0, 0, 1])
        ]);

        Assert.AreEqual(matrix, matrix * id);

        var matrix2 = new Matrix(
        [
            new([1, 4]),
            new([2, 5]),
            new([3, 6])
        ]);
        var matrix3 = new Matrix(
        [
            new([7, 9, 11]),
            new([8, 10, 12]),
        ]);
        var result = new Matrix(
        [
            new([58, 139]),
            new([64, 154])
        ]);

        Assert.AreEqual(result, matrix2 * matrix3);
    }
}
