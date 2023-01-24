namespace Figures;

public class Triangle : IFigure
{
    private double _sideALenght;
    private double _sideBLength;
    private double _sideCLength;
    private readonly bool _shouldValidateSideCombination;

    public double SideALenght
    {
        get => _sideALenght;
        set => SetSideLength('A', ref _sideALenght, value);
    }

    public double SideBLength
    {
        get => _sideBLength;
        set => SetSideLength('B', ref _sideBLength, value);
    }

    public double SideCLength
    {
        get => _sideCLength;
        set => SetSideLength('C', ref _sideCLength, value);
    }

    public double Area
    {
        get
        {
            var s = (SideALenght + SideBLength + SideCLength) / 2;
            return double.Sqrt(s * (s - SideALenght) * (s - SideBLength) * (s - SideCLength));
        }
    }

    /// <summary>
    ///     Indicates if this triangle is right (one of the angles is 90°).
    /// </summary>
    public bool IsRight
    {
        get
        {
            var sortedSideLengths = new[] { SideALenght, SideBLength, SideCLength }.Order().ToArray();
            var other1 = sortedSideLengths[0];
            var other2 = sortedSideLengths[1];
            var longest = sortedSideLengths.Last();
            return double.Pow(other1, 2) + double.Pow(other2, 2) == double.Pow(longest, 2);
        }
    }

    public Triangle(double sideALenght, double sideBLength, double sideCLength)
    {
        SideALenght = sideALenght;
        SideBLength = sideBLength;
        SideCLength = sideCLength;
        _shouldValidateSideCombination = true;
    }

    private void SetSideLength(char side, ref double length, double newLength)
    {
        ValidateSideLengthToBePositive(side, newLength);
        var oldLength = length;
        try
        {
            length = newLength;
            if (_shouldValidateSideCombination)
                ValidateSideCombination();
        }
        catch (InvalidTriangleSideCombinationException)
        {
            length = oldLength;
            throw;
        }
    }

    private void ValidateSideLengthToBePositive(char side, double length)
    {
        if (length < 0)
            throw new InvalidFigurePropertyValueException(
                $"Triangle side {side} cannot be negative, received: {length}");
    }

    private void ValidateSideCombination()
    {
        if (SideALenght + SideBLength <= SideCLength || SideALenght + SideCLength <= SideBLength ||
            SideBLength + SideCLength <= SideALenght)
            throw new InvalidTriangleSideCombinationException(SideALenght, SideBLength, SideCLength);
    }
}
