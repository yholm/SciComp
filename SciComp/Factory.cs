using SciComp.Chemistry;
using SciComp.Math;

namespace SciComp;

public static class Factory
{
    static readonly Dictionary<Type, Func<string, object>> factories = new()
    {
        { typeof (Molecule), static str => new Molecule(str) },
        { typeof (Polynomial), Polynomial.Parse }
    };

    public static T Create<T>(string str)
    {
        var type = typeof(T);

        if (!factories.TryGetValue(type, out var factory))
            throw new NotSupportedException($"Type {type.Name} is not supported.\n"
                + $"Supported types: {string.Join(", ", factories.Keys.Select(static t => t.Name))}");

        return (T)factory(str);
    }
}
