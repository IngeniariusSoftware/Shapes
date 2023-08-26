namespace Core;

public sealed class Circle : IArea
{
    public readonly double Radius;

    public Circle(double radius)
    {
        ValidateRadius(radius);

        Radius = radius;
        Area = CalculateArea();
    }

    public double Area { get; }

    private double CalculateArea() => Radius * Radius * Math.PI;

    private static void ValidateRadius(double radius)
    {
        const string message = "The radius of the circle cannot have a negative value";

        if (radius < 0.0) throw new ArgumentOutOfRangeException(nameof(radius), message);
    }
}