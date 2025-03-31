namespace SciComp;

public class DimensionalMismatchException : Exception
{
    public DimensionalMismatchException() 
        : base() { }
    public DimensionalMismatchException(string message) 
        : base(message) { }
    public DimensionalMismatchException(string message, Exception innerException) 
        : base(message, innerException) { }
}
