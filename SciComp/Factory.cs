namespace SciComp;

public static class Factory
{
    public static T Create<T>(string str)
        where T : IFactoryParsable<T>
    {
        if (typeof(T) == typeof(SIUnit))
        {
            if (SIUnit.Constants.Symbols.TryGetValue(str, out var value))
            {
                return (T)(object)value;
            }
        }

        return T.Parse(str);
    }
}
