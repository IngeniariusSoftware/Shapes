namespace Core;

public sealed class Triangle : IArea
{
    public readonly double A, B, C;

    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public double Area => throw new NotImplementedException();
}