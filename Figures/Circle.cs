namespace Figures;

public sealed class Circle : Figure
{
    public double Radius { get; }

    /// <exception cref="InvalidFigurePropertyValueException">radius is negative.</exception>
    public Circle(double radius)
    {
        Radius = radius;
        Validate();
    }

    public override double GetArea() => double.Pi * double.Pow(Radius, 2);

    public override void Validate()
    {
        if (Radius < 0)
            throw new InvalidFigurePropertyValueException($"Circle radius cannot be negative: {Radius}");
    }
}
