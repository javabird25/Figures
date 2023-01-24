namespace Tests;

using Figures;

public sealed class CircleTest
{
    [Fact]
    public void AreaOfCircleWithRadius10HasAreaOf_314_159()
    {
        var circle = new Circle(10);
        var area = circle.Area();
        area.Should().BeApproximately(314.159, 0.1);
    }

    [Fact]
    public void CircleWithNegativeRadiusCannotBeCreated()
    {
        var circle = new Circle(-1);
        circle.IsValid().Should().BeFalse();
    }

    [Fact]
    public void AreaMethodThrowsIfCircleIsInvalid()
    {
        var circle = new Circle(-1);
        var action = () => circle.Area();
        action.Should().Throw<GeometryException>();
    }
}
