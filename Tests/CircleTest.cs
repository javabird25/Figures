namespace Tests;

using Figures;

public sealed class CircleTest
{
    [Fact]
    public void AreaOfCircleWithRadius10HasAreaOf_314_159()
    {
        var circle = new Circle(10);
        var area = circle.Area;
        area.Should().BeApproximately(314.159, 0.1);
    }

    [Fact]
    public void CircleWithNegativeRadiusCannotBeCreated()
    {
        var action = () => new Circle(-1);
        action.Should().Throw<InvalidFigurePropertyValueException>();
    }

    [Fact]
    public void NegativeRadiusCannotBeSet()
    {
        var circle = new Circle(10);
        var action = () => { circle.Radius = -1; };
        action.Should().Throw<InvalidFigurePropertyValueException>();
    }
}
