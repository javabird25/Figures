namespace Tests;

using Figures;

public sealed class TriangleTest
{
    [Fact]
    public void TriangleWithSides_3_4_5_HasAreaOf_6()
    {
        var triangle = new Triangle(3, 4, 5);
        var area = triangle.Area;
        area.Should().Be(6);
    }

    [Fact]
    public void TriangleWithNegativeSidesCannotBeCreated()
    {
        var action = () => new Triangle(-1, 1, 1);
        action.Should().Throw<InvalidFigurePropertyValueException>();
    }

    [Fact]
    public void NegativeSidesCannotBeSet()
    {
        var triangle = new Triangle(2, 3, 4);
        var action = () => { triangle.SideALenght = -1; };
        action.Should().Throw<InvalidFigurePropertyValueException>();
    }

    [Fact]
    public void TriangleWithInvalidSideCombinationCannotBeCreated()
    {
        var triangle = new Triangle(2, 3, 4);
        var action = () => { triangle.SideCLength = 100; };
        action.Should().Throw<InvalidTriangleSideCombinationException>();
    }
    
    [Fact]
    public void TriangleWithSides_3_4_5_IsRight()
    {
        var triangle = new Triangle(3, 4, 5);
        triangle.IsRight.Should().BeTrue();
    }
}
