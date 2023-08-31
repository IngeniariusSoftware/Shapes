﻿namespace Core;

public static class DoubleExtension
{
    // https://stackoverflow.com/a/3875619
    public static bool NearlyEqual(this double a, double b, double epsilon = 0.0001)
    {
        if (a.Equals(b)) return true;

        const double MinNormal = 2.2250738585072014E-308d;
        double modulesSum = Math.Abs(a) + Math.Abs(b);
        double moduloDiff = Math.Abs(a - b);

        if (a == 0.0 || b == 0.0 || modulesSum < MinNormal) return moduloDiff < (epsilon * MinNormal);

        return (moduloDiff / modulesSum) < epsilon;
    }
}