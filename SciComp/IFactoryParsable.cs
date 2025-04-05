namespace SciComp;

public interface IFactoryParsable<T>
{
    /// <summary>
    /// Parses a string to create an instance of the type.
    /// </summary>
    /// <param name="str">The string to parse.</param>
    /// <returns>An instance of the type.</returns>
    internal static abstract T Parse(string str);
}
