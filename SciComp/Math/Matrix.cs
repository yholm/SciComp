using System.Collections;

namespace SciComp.Math;

public class Matrix : IEnumerable<Vector>, IEnumerable, IEquatable<Matrix>
{
    private readonly Vector[] columns;

    public int Rank { get => columns[0].Dimension; }

    public Matrix(IEnumerable<Vector> columns)
    {
        if (columns.Any(c => c != columns.ElementAt(0)))
            throw new ArgumentException("");

        this.columns = columns.ToArray();
    }

    public static Vector operator *(Matrix transformation, Vector vector)
    {
        if (vector.Dimension != transformation.columns.Length)
            throw new ArgumentException("");

        var result = transformation.columns.Select(c => c.Dot(vector));
        return new Vector(result);
    }
    public static Matrix operator *(Matrix lhs, Matrix rhs)
    {
        var newBasisVectors = lhs.columns.ToList().Select(c => rhs * c);
        return new Matrix(newBasisVectors);
    }

    public IEnumerator<Vector> GetEnumerator()
    {
        return (IEnumerator<Vector>)columns.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public bool Equals(Matrix? other)
    {
        return other is not null && columns.Equals(other.columns);
    }
    public override bool Equals(object? obj)
    {
        return obj is not null && Equals(obj as Matrix);
    }

    public override int GetHashCode()
    {
        return columns.GetHashCode();
    }
}
