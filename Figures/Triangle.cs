namespace Figures;

public class Triangle : Figure
{
    public double SideALength { get; set; }

    public double SideBLength { get; set; }

    public double SideCLength { get; set; }

    public Triangle(double sideALength, double sideBLength, double sideCLength)
    {
        SideALength = sideALength;
        SideBLength = sideBLength;
        SideCLength = sideCLength;
    }

    public override double Area()
    {
        Validate();
        var s = (SideALength + SideBLength + SideCLength) / 2;
        return double.Sqrt(s * (s - SideALength) * (s - SideBLength) * (s - SideCLength));
    }

    /// <summary>
    ///     Indicates if this triangle is right (one of the angles is 90°).
    /// </summary>
    /// <exception cref="GeometryException">triangle is invalid.</exception>
    public bool IsRight()
    {
        Validate();
        var sortedSideLengths = new[] { SideALength, SideBLength, SideCLength }.Order().ToArray();
        var other1 = sortedSideLengths[0];
        var other2 = sortedSideLengths[1];
        var longest = sortedSideLengths.Last();
        return double.Pow(other1, 2) + double.Pow(other2, 2) == double.Pow(longest, 2);
    }

    public override void Validate()
    {
        if (SideALength < 0 || SideBLength < 0 || SideCLength < 0)
            throw new InvalidFigurePropertyValueException(
                $"Triangle sides cannot be negative, have: {SideALength} {SideBLength} {SideCLength}");

        if (SideALength + SideBLength <= SideCLength || SideALength + SideCLength <= SideBLength ||
            SideBLength + SideCLength <= SideALength)
            throw new InvalidTriangleSideCombinationException(SideALength, SideBLength, SideCLength);
    }
}
