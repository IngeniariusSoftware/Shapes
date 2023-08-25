namespace Tests;

using Core;

public class CircleTests
{
    // https://en.wikipedia.org/wiki/Area_of_a_circle
    private static double CircleArea(double radius) => radius * radius * Math.PI;

    [Fact]
    public void TestAreaSimple()
    {
        double radius = 5.0;
        var circle = new Circle(radius);

        double expected = CircleArea(radius);
        double actual = circle.Area;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestAreaWithOneRadius()
    {
        double radius = 1.0;
        var circle = new Circle(radius);

        double expected = Math.PI;
        double actual = circle.Area;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestNegativeInitialization()
    {
        double radius = -10.0;

        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(radius));
    }

    [Fact]
    public void TestZeroArea()
    {
        double radius = 0.0;
        var circle = new Circle(radius);

        double expected = 0.0;
        double actual = circle.Area;

        Assert.Equal(expected, actual);
    }
}