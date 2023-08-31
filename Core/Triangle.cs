namespace Core;

public sealed class Triangle : IArea
{
    public readonly double A, B, C;

    private double? _area;

    private bool? _isRight;

    public Triangle(double a, double b, double c)
    {
        ValidateNonNegativeSides(a, b, c);
        ValidateTriangleInequality(a, b, c);

        A = a;
        B = b;
        C = c;
    }

    public double Area => _area ??= CalculateArea();

    public bool IsRight => _isRight ??= CheckRightness();

    private static void ValidateNonNegativeSides(double a, double b, double c)
    {
        const string message = "The side of the triangle cannot have a negative value";

        if (a < 0.0) throw new ArgumentOutOfRangeException(nameof(a), a, message);
        if (b < 0.0) throw new ArgumentOutOfRangeException(nameof(b), b, message);
        if (c < 0.0) throw new ArgumentOutOfRangeException(nameof(c), c, message);
    }

    // https://en.wikipedia.org/wiki/Triangle_inequality
    private static void ValidateTriangleInequality(double a, double b, double c)
    {
        const string message = "The sum of the two sides of a triangle is always greater than or equal to the third side";

        if ((b + c) < a) throw new ArgumentException(message, nameof(a));
        if ((a + c) < b) throw new ArgumentException(message, nameof(b));
        if ((a + b) < c) throw new ArgumentException(message, nameof(c));
    }

    // https://en.wikipedia.org/wiki/Heron%27s_formula
    private double CalculateArea()
    {
        double s = (A + B + C) / 2.0; // semiperimeter
        return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
    }

    // https://en.wikipedia.org/wiki/Right_triangle
    private bool CheckRightness()
    {
        double[] sides = { A, B, C };
        Array.Sort(sides);
        return ((sides[0] * sides[0]) + (sides[1] * sides[1])).NearlyEqual(sides[2] * sides[2]);
    }
}