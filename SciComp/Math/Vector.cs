using System.Collections;

namespace SciComp.Math;

public class Vector : IEnumerable<double>, IEnumerable, IEquatable<Vector>
{
    private readonly double[] values;

    public Vector(IEnumerable<double> values)
    {
        this.values = [.. values];
    }

    public int Dimension => values.Length;
    public double this[int index]
    {
        get
        {
            if (index > Dimension) 
                throw new IndexOutOfRangeException("Index greater than vector's dimension");
            return values[index];
        }
    }

    public double Magnitude()
    {
        return System.Math.Sqrt(values.Sum(static v => System.Math.Pow(v, 2)));
    }

    public static double Dist(Vector first, Vector second)
    {
        return (first - second).Magnitude();
    }

    public double Dot(Vector other)
    {
        if (Dimension != other.Dimension)
            throw new ArgumentException("Cannot get the dot product of vectors of different dimensions");
        return values.Zip(other.values, static (x, y) => x * y).Sum();
    }

    public static Vector operator +(Vector lhs, Vector rhs)
    {
        if (lhs.Dimension != rhs.Dimension)
            throw new ArgumentException("Cannot add two vectors of different dimensions");
        return new Vector([.. lhs.values.Zip(rhs.values, static (x, y) => x + y)]);
    }
    public static Vector operator -(Vector lhs, Vector rhs)
    {
        if (lhs.Dimension != rhs.Dimension)
            throw new ArgumentException("Cannot subtract two vectors of different dimensions");
        return new Vector([.. lhs.values.Zip(rhs.values, static (x, y) => x - y)]);
    }
    public static Vector operator *(Vector vector, double scalar)
    {
        return new Vector([.. vector.values.Select(x => x * scalar)]);
    }
    public static Vector operator *(double scalar, Vector vector)
    {
        return vector * scalar;
    }
    public static Vector operator /(Vector vector, double scalar)
    {
        if (scalar == 0) throw new DivideByZeroException("Cannot divide vector by zero");
        return vector * System.Math.Pow(scalar, -1);
    }

    public IEnumerable<double> AsEnumerable()
    {
        return values.AsEnumerable();
    }

    public IEnumerator<double> GetEnumerator()
    {
        return (IEnumerator<double>)values.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public bool Equals(Vector? other)
    {
        return other is not null && values.SequenceEqual(other.values);
    }
    public override bool Equals(object? obj)
    {
        return obj is Vector vector && Equals(vector);
    }

    public override int GetHashCode()
    {
        return values.GetHashCode();
    }
}
