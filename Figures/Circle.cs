namespace Figures;

public class Circle : Figure
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double Area()
    {
        Validate();
        return double.Pi * double.Pow(Radius, 2);
    }

    public override void Validate()
    {
        if (Radius < 0)
            throw new InvalidFigurePropertyValueException($"Circle radius cannot be negative: {Radius}");
    }
}
