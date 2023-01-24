namespace Tests;

using Figures;

public sealed class TriangleTest
{
    [Fact]
    public void TriangleWithSides_3_4_5_HasAreaOf_6()
    {
        var triangle = new Triangle(3, 4, 5);
        var area = triangle.GetArea();
        area.Should().Be(6);
    }

    [Fact]
    public void TriangleWithNegativeSidesCannotBeCreated()
    {
        var action = () => new Triangle(-1, 1, 1);
        action.Should().Throw<InvalidFigurePropertyValueException>();
    }

    [Fact]
    public void TriangleWithInvalidSidesIsInvalid()
    {
        var action = () => new Triangle(2, 3, 100);
        action.Should().Throw<InvalidTriangleException>();
    }

    [Fact]
    public void TriangleWithSides_3_4_5_IsRight()
    {
        var triangle = new Triangle(3, 4, 5);
        triangle.IsRight().Should().BeTrue();
    }

    [Fact]
    public void TriangleCanBeCopiedWithValidation()
    {
        var triangle = new Triangle(3, 4, 5);
        var action = () => triangle.With(b: 100);
        action.Should().Throw<InvalidTriangleException>();
    }
}
