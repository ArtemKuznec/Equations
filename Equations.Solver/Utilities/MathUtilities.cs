﻿namespace Equations.Solver.Utilities
{
    public static class MathUtilities
    {
        public static bool AreApproximatelyEqual(double? a, double? b, double epsilon) => a != null && b != null ? Math.Abs((double)a - (double)b) < epsilon : a == b;

    }
}
