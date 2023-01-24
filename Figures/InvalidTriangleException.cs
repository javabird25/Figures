namespace Figures;

public sealed class InvalidTriangleException : GeometryException
{
    public InvalidTriangleException(double sideA, double sideB, double sideC) : base(
        $"Invalid combination of triangle sides: {sideA}, {sideB} and {sideC}.")
    {
    }
}
