namespace Figures;

public class Circle : IFigure
{
    private double _radius;

    public double Radius
    {
        get => _radius;
        set
        {
            if (value < 0)
                throw new InvalidFigurePropertyValueException($"Circle radius cannot be negative: {value}");

            _radius = value;
        }
    }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Area => double.Pi * double.Pow(Radius, 2);
}
