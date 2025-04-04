using System.Collections;

namespace SciComp.Math;

public class Matrix : IEnumerable<Vector>, IEnumerable, IEquatable<Matrix>
{
    private readonly Vector[] columns;

    public int Rank => columns[0].Dimension;

    public Matrix(IEnumerable<Vector> columns)
    {
        if (columns.Any(c => c.Dimension != columns.ElementAt(0).Dimension))
            throw new ArgumentException("");

        this.columns = [.. columns];
    }

    public static Vector operator *(Matrix transformation, Vector vector)
    {
        if (vector.Dimension != transformation.columns.Length)
            throw new ArgumentException("");

        var rows = new List<Vector>();

        for (var i = 0; i < transformation.Rank; i++)
        {
            var row = new List<double>();
            transformation.columns.ToList().ForEach(c => row.Add(c[i]));
            rows.Add(new Vector(row));
        }

        var result = rows.Select(c => c.Dot(vector));
        return new Vector(result);
    }
    public static Matrix operator *(Matrix lhs, Matrix rhs)
    {
        var newBasisVectors = rhs.columns.ToList().Select(c => lhs * c);
        return new Matrix(newBasisVectors);
    }
    public static Matrix operator *(Matrix matrix, double scalar)
    {
        return new Matrix(matrix.columns.Select(c => c * scalar));
    }
    public static Matrix operator *(double scalar, Matrix matrix)
    {
        return matrix * scalar;
    }
    public IEnumerator<Vector> GetEnumerator()
    {
        return (IEnumerator<Vector>)columns.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public bool Equals(Matrix? other)
    {
        return other is not null && columns.SequenceEqual(other.columns);
    }
    public override bool Equals(object? obj)
    {
        return obj is Matrix matrix && Equals(matrix);
    }

    public override int GetHashCode()
    {
        return columns.GetHashCode();
    }
}
