using Equations.Enum;

namespace Equations.Interfaces
{
    public interface IQuadraticEquation
    {
        (QuadraticEquationRootStatus RootsStatus, double? X1, double? X2) Solve();
    }
}