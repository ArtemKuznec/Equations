using Equations.Enum;
using Equations.Exceptions;
using Equations.Implementations;
using Equations.Solver.Utilities;

namespace Equations.Tests
{
    public class QuadraticEquationsTests
    {

        [Theory]
        [InlineData(1, 0, 0, 0.0, null)]
        [InlineData(1, -3, 2, 2.0, 1.0)]
        [InlineData(1, -2, 1, 1.0, null)]
        [InlineData(1, 0, -4, 2.0, -2.0)]
        [InlineData(1, 2, 5, null, null)]
        [InlineData(2, 4, 2, -1.0, null)]
        [InlineData(2, -4, 2, 1.0, null)]
        [InlineData(1, 1, 1, null, null)]
        [InlineData(1, -4, 4, 2.0, null)]
        [InlineData(-1, 2, -3, null, null)]
        [InlineData(1, 5, 6, -2.0, -3.0)]
        [InlineData(1, -1, -6, 3.0, -2.0)]
        [InlineData(4, 4, 1, -0.5, null)]
        [InlineData(1, 2, 3, null, null)]
        [InlineData(1, 3, 2, -1.0, -2.0)]
        [InlineData(2, 1, -3, 1.0, -1.5)]
        [InlineData(3, -6, 3, 1.0, null)]
        [InlineData(1, 1, -6, 2.0, -3.0)]
        [InlineData(1, -8, 15, 5.0, 3.0)]
        [InlineData(1, 4, 4, -2.0, null)]
        [InlineData(1, -10, 21, 7.0, 3.0)]
        [InlineData(-7.545, 15.5386, 21.4232, -0.945, 3.004)]
        [InlineData(-10.0, 5.5, 3.0, -0.338, 0.888)]
       
        public void QuadraticEquationTest(double a, double b, double c, double? x1, double? x2)
        {
            QuadraticEquation equation = new(a, b, c);
            QuadraticEquation.RondNumber = 3;

            var result = equation.Solve();

            Assert.True(MathUtilities.AreApproximatelyEqual(x1, result.X1, QuadraticEquation.Epsilon));
            Assert.True(MathUtilities.AreApproximatelyEqual(x2, result.X2, QuadraticEquation.Epsilon));
            Assert.Equal(
                result.X1 == null ? QuadraticEquationRootStatus.NoRoots :
                result.X2 != null ? QuadraticEquationRootStatus.TwoRoots :
                QuadraticEquationRootStatus.OneRoot, result.RootsStatus);
        }

        [Fact]
        public void CreateQuadraticEquationWithInvalidCoefficient()
        {
            string errorMessage = string.Empty;

            try
            {
                QuadraticEquation equation = new(0, 5, 6);

            } catch (InvalidQuadraticCoefficientException exception)
            {
                errorMessage = exception.Message;
            }

            Assert.Equal("При коэффициенте a = 0 уравнение не является квадратичным", errorMessage);
        }
    }
}