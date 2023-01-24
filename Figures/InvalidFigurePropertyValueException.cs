namespace Figures;

public sealed class InvalidFigurePropertyValueException : GeometryException
{
    public InvalidFigurePropertyValueException(string message) : base(message)
    {
    }
}
