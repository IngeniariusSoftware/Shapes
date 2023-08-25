namespace Core;

public sealed class Circle : IArea
{
    public readonly double Radius;

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Area => throw new NotImplementedException();
}