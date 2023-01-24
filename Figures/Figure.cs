namespace Figures;

public abstract class Figure
{
    /// <summary>
    ///     Computes the area of this figure.
    /// </summary>
    public abstract double GetArea();

    /// <summary>
    ///     Checks if this figure has correct property values, for example circle's radius being positive.
    /// </summary>
    public abstract void Validate();
}
