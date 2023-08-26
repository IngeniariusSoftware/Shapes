namespace Tests;

using Core;

public class TriangleTests
{
    // https://en.wikipedia.org/wiki/Heron%27s_formula
    private static double TriangleArea(double a, double b, double c)
    {
        double s = (a + b + c) / 2.0; // semiperimeter
        double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        return area;
    }

    [Fact]
    public void TestZeroArea()
    {
        double a = 0.0, b = 0.0, c = 0.0;
        var triangle = new Triangle(a, b, c);

        double expected = 0.0;
        double actual = triangle.Area;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestAreaDegenerated()
    {
        double a = 2.0, b = 5.0, c = 7.0;
        var triangle = new Triangle(a, b, c);

        double expected = 0.0;
        double actual = triangle.Area;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestAreaRight()
    {
        double a = 3.0, b = 4.0, c = 5.0;
        var triangle = new Triangle(a, b, c);

        double expected = 6.0;
        double actual = triangle.Area;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestAreaEquilateral()
    {
        double a = 3.0, b = 3.0, c = 3.0;
        var triangle = new Triangle(a, b, c);

        double expected = TriangleArea(a, b, c);
        double actual = triangle.Area;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestAreaIsosceles()
    {
        double a = 3.0, b = 3.0, c = 5.0;
        var triangle = new Triangle(a, b, c);

        double expected = TriangleArea(a, b, c);
        double actual = triangle.Area;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestAreaDifferentSidesInitializationOrder()
    {
        double a = 5.0, b = 6.0, c = 7.0;
        double[][] sides =
            { new[] { a, b, c }, new[] { a, c, b }, new[] { b, a, c }, new[] { b, c, a }, new[] { c, a, b }, new[] { c, b, a } };

        double expected = TriangleArea(a, b, c);

        foreach (double[] data in sides)
        {
            var triangle = new Triangle(data[0], data[1], data[2]);
            double actual = triangle.Area;
            Assert.Equal(expected, actual);
        }
    }

    [Fact]
    public void TestNegativeInitialization()
    {
        double a = -5.0, b = 6.0, c = -7.0;

        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(a, b, c));
    }

    [Fact] // https://en.wikipedia.org/wiki/Triangle_inequality
    public void TestInequality()
    {
        double a = 1.0, b = 2.0, c = 10.0;

        Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
    }

    [Fact]
    public void TestRightness()
    {
        double a = 3.0, b = 4.0, c = 5.0;
        double[][] sides =
            { new[] { a, b, c }, new[] { a, c, b }, new[] { b, a, c }, new[] { b, c, a }, new[] { c, a, b }, new[] { c, b, a } };

        bool expected = true;

        foreach (double[] data in sides)
        {
            var triangle = new Triangle(data[0], data[1], data[2]);
            bool actual = triangle.IsRight;
            Assert.Equal(expected, actual);
        }
    }

    [Fact]
    public void TestNonRightness()
    {
        double a = 5.0, b = 6.0, c = 7.0;
        double[][] sides =
            { new[] { a, b, c }, new[] { a, c, b }, new[] { b, a, c }, new[] { b, c, a }, new[] { c, a, b }, new[] { c, b, a } };

        bool expected = false;

        foreach (double[] data in sides)
        {
            var triangle = new Triangle(data[0], data[1], data[2]);
            bool actual = triangle.IsRight;
            Assert.Equal(expected, actual);
        }
    }
}