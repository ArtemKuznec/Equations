using Equations.Exceptions;
using Equations.Solver.Utilities;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            ConsoleUtilities.ShowMenu();

            try
            {
                int choiceInput = int.Parse(Console.ReadLine());

                switch (choiceInput)
                {
                    case 1:
                        ConsoleUtilities.SolveEquationFromConsole();
                        break;
                    case 2:
                        ConsoleUtilities.SolveEquationsFromFile();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Некорректный выбор.");
                        ConsoleUtilities.WaitForEnterInput();
                        break;
                }
            }
            catch (InvalidQuadraticCoefficientException)
            {
                Console.WriteLine("Коэффициент 'a' квадратного уравнения не может быть равен 0.");
                ConsoleUtilities.WaitForEnterInput();
            }
            catch (FormatException)
            {
                Console.WriteLine("Введен некорректный символ.");
                ConsoleUtilities.WaitForEnterInput();
            }

            Console.Clear();
        }
    }
}