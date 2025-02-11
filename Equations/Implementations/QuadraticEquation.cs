﻿using Equations.Enum;
using Equations.Interfaces;

namespace Equations.Implementations
{
    public class QuadraticEquation : IQuadraticEquation, IEquatable<QuadraticEquation>
    {
        public static double Epsilon = 1e-10;

        private double a = default;
        private double b = default;
        private double c = default;

        public double A { get => a; }
        public double B { get => b; }
        public double C { get => c; }

        public QuadraticEquation(double a, double b, double c)
        {
            if (a == 0)
            {
                throw new ArgumentException("При коэффициенте a = 0 уравнение не является квадратичным");
            }

            this.a = a;
            this.b = b;
            this.c = c;
        }

        public (QuadraticEquationRootStatus RootsStatus, double? X1, double? X2) Solve()
        {
            double discriminant = b * b - 4 * a * c;

            if (discriminant > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);

                return (QuadraticEquationRootStatus.TwoRoots, Math.Abs(x1) < Epsilon ? 0 : x1, Math.Abs(x2) < Epsilon ? 0 : x2);
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);

                return (QuadraticEquationRootStatus.OneRoot, x = Math.Abs(x) < Epsilon ? 0 : x, null);
            }
            else
            {
                return (QuadraticEquationRootStatus.NoRoots, null, null);
            }
        }

        public bool Equals(QuadraticEquation other)
        {
            if (other is null)
                return false;

            return Math.Abs(A - other.A) < Epsilon &&
                   Math.Abs(B - other.B) < Epsilon &&
                   Math.Abs(C - other.C) < Epsilon;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as QuadraticEquation);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(A, B, C);
        }

        public static bool operator ==(QuadraticEquation left, QuadraticEquation right)
        {
            if (left is null)
                return right is null;

            return left.Equals(right);
        }

        public static bool operator !=(QuadraticEquation left, QuadraticEquation right)
        {
            return !(left == right);
        }
    }
}
