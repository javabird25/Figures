namespace Figures;

public sealed class InvalidTriangleSideCombinationException : GeometryException
{
    public InvalidTriangleSideCombinationException(double sideA, double sideB, double sideC) : base(
        $"Invalid combination of triangle sides: {sideA}, {sideB} and {sideC}.")
    {
    }
}
