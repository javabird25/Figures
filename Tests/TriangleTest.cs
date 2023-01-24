namespace Tests;

using Figures;

public sealed class TriangleTest
{
    [Fact]
    public void TriangleWithSides_3_4_5_HasAreaOf_6()
    {
        var triangle = new Triangle(3, 4, 5);
        var area = triangle.Area();
        area.Should().Be(6);
    }

    [Fact]
    public void TriangleWithNegativeSidesIsInvalid()
    {
        var triangle = new Triangle(-1, 1, 1);
        triangle.IsValid().Should().BeFalse();
    }

    [Fact]
    public void TriangleWithInvalidSideCombinationIsInvalid()
    {
        var triangle = new Triangle(2, 3, 100);
        triangle.IsValid().Should().BeFalse();
    }

    [Fact]
    public void AreaMethodThrowsIfTriangleIsInvalid()
    {
        var triangle = new Triangle(-1, -1, -1);
        var action = () => triangle.Area();
        action.Should().Throw<GeometryException>();
    }

    [Fact]
    public void IsRightMethodThrowsIfTriangleIsInvalid()
    {
        var triangle = new Triangle(-1, -1, -1);
        var action = () => triangle.IsRight();
        action.Should().Throw<GeometryException>();
    }

    [Fact]
    public void TriangleWithSides_3_4_5_IsRight()
    {
        var triangle = new Triangle(3, 4, 5);
        triangle.IsRight().Should().BeTrue();
    }
}
