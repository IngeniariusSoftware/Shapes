namespace Core;

public sealed class Triangle : IArea
{
    public readonly double A, B, C;

    public readonly bool IsRight;

    public Triangle(double a, double b, double c)
    {
        ValidateNonNegativeSides(a, b, c);
        ValidateTriangleInequality(a, b, c);

        A = a;
        B = b;
        C = c;

        Area = CalculateArea();
        IsRight = CheckRightness();
    }

    public double Area { get; }

    private static void ValidateNonNegativeSides(double a, double b, double c)
    {
        string message = "The side of the triangle cannot have a negative value";

        if (a < 0.0) throw new ArgumentOutOfRangeException(nameof(a), message);
        if (b < 0.0) throw new ArgumentOutOfRangeException(nameof(b), message);
        if (c < 0.0) throw new ArgumentOutOfRangeException(nameof(c), message);
    }

    // https://en.wikipedia.org/wiki/Triangle_inequality
    private static void ValidateTriangleInequality(double a, double b, double c)
    {
        string message = "The sum of the two sides of a triangle is always greater than or equal to the third side";

        if ((b + c) < a) throw new ArgumentException(message, nameof(a));
        if ((a + c) < b) throw new ArgumentException(message, nameof(b));
        if ((a + b) < c) throw new ArgumentException(message, nameof(c));
    }

    // https://en.wikipedia.org/wiki/Heron%27s_formula
    private double CalculateArea()
    {
        double s = (A + B + C) / 2.0; // semiperimeter
        double area = Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        return area;
    }

    // https://en.wikipedia.org/wiki/Right_triangle
    private bool CheckRightness(double epsilon = 0.0001)
    {
        double[] sides = { A, B, C };
        Array.Sort(sides);
        return (C * C).NearlyEqual((A * A) + (B * B), epsilon);
    }
}