namespace Figures;

public abstract class Figure
{
    /// <summary>
    ///     Computes the area of this figure.
    /// </summary>
    /// <exception cref="GeometryException">figure is invalid.</exception>
    public abstract double Area();

    /// <summary>
    ///     Checks if this figure has correct property values, for example circle's radius being positive.
    /// </summary>
    /// <exception cref="GeometryException">figure turns out to be invalid.</exception>
    public abstract void Validate();

    /// <summary>
    ///     Non-throwing version of <see cref="Validate"/>.
    /// </summary>
    /// <returns><c>true</c> if this figure is valid, <c>false</c> otherwise.</returns>
    public bool IsValid()
    {
        try
        {
            Validate();
            return true;
        }
        catch (GeometryException)
        {
            return false;
        }
    }
}
