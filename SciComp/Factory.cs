namespace SciComp;

public static class Factory
{
    public static T Create<T>(string str)
        where T : IFactoryParsable<T>
    {
        return T.Parse(str);
    }
}
