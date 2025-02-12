using Equations.Enum;
using Equations.Implementations;

namespace Equations.Interfaces
{
    public interface IQuadraticEquation
    {
        double A { get; }
        double B { get; }
        double C { get; }

        bool Equals(object obj);
        bool Equals(QuadraticEquation other);
        int GetHashCode();
        (QuadraticEquationRootStatus RootsStatus, double? X1, double? X2) Solve();
    }
}