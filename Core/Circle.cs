namespace Core;

public sealed class Circle : IArea
{
    public readonly double Radius;

    private double? _area;

    public Circle(double radius)
    {
        ValidateRadius(radius);

        Radius = radius;
    }

    public double Area => _area ??= CalculateArea();

    // https://en.wikipedia.org/wiki/Area_of_a_circle
    private double CalculateArea() => Math.PI * Radius * Radius;

    private static void ValidateRadius(double radius)
    {
        const string message = "The radius of the circle cannot have a negative value";

        if (radius < 0.0) throw new ArgumentOutOfRangeException(nameof(radius), message);
    }
}