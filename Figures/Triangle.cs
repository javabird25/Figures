namespace Figures;

public class Triangle : Figure
{
    public double SideA { get; }
    public double SideB { get; }
    public double SideC { get; }

    /// <exception cref="InvalidFigurePropertyValueException">any of new triangle's sides are negative.</exception>
    /// <exception cref="InvalidTriangleException">
    ///     if sum of any of its two sides is less than or equal than the third side.
    /// </exception>
    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
        Validate();
    }

    /// <summary>
    ///     Creates a copy of this triangle with optionally modified side lengths.
    /// </summary>
    /// <exception cref="InvalidFigurePropertyValueException">any of new triangle's sides are negative.</exception>
    /// <exception cref="InvalidTriangleException">
    ///     if sum of any of its two sides is less than or equal than the third side.
    /// </exception>
    /// <example>
    /// <code>
    ///     var triangle = new Triangle(3, 4, 5);
    ///     var copy = triangle.With(b: 5);
    /// </code>
    /// </example>
    public Triangle With(double? a = null, double? b = null, double? c = null)
    {
        var newA = a ?? SideA;
        var newB = b ?? SideB;
        var newC = c ?? SideC;
        return new Triangle(newA, newB, newC);
    }

    public override double GetArea()
    {
        var s = (SideA + SideB + SideC) / 2;
        return double.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
    }

    /// <summary>
    ///     Indicates if this triangle is right (one of the angles is 90°).
    /// </summary>
    public bool IsRight()
    {
        var sortedSideLengths = new[] { SideA, SideB, SideC }.Order().ToArray();
        var other1 = sortedSideLengths[0];
        var other2 = sortedSideLengths[1];
        var longest = sortedSideLengths.Last();
        return double.Pow(other1, 2) + double.Pow(other2, 2) == double.Pow(longest, 2);
    }

    public override void Validate()
    {
        if (SideA < 0 || SideB < 0 || SideC < 0)
            throw new InvalidFigurePropertyValueException(
                $"Triangle sides cannot be negative, have: {SideA} {SideB} {SideC}");

        if (SideA + SideB <= SideC || SideA + SideC <= SideB ||
            SideB + SideC <= SideA)
            throw new InvalidTriangleException(SideA, SideB, SideC);
    }
}
