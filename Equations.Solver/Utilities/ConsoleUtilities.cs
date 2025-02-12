﻿using Equations.Enum;
using Equations.Implementations;
using System.Globalization;

namespace Equations.Solver.Utilities
{
    internal static class ConsoleUtilities
    {
        public static void ShowMenu()
        {
            Console.WriteLine("Квадратное уравнение имеет вид: ax^2 + bx + c = 0, где a != 0");
            Console.WriteLine("Прочесть данные с клавиатуры - 1");
            Console.WriteLine("Прочесть данные из файла - 2");
            Console.WriteLine("Округлять до указанного знака - 3");
            Console.WriteLine("Выйти из приложения - 4");
        }

        public static void SolveEquationFromConsole()
        {
            Console.Clear();
            QuadraticEquation equation = ReadEquationFromConsole();

            if (equation == null)
            {
                throw new ArgumentNullException("Экземпляр класса QuadraticEquation не был проинициализирован");
            }

            DisplayResults(equation);
            WaitForEnterInput();
        }

        public static void SetRoundValue()
        {
            Console.Clear();
            int roundNumber;

            while (true)
            {
                Console.Write("Введите положительное число в диапазоне от 0 до 15: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out roundNumber))
                {
                    if (roundNumber > 0 && roundNumber <= 15)
                    {
                        QuadraticEquation.RondNumber = roundNumber;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Число должно быть больше 0 и меньше или равно 15.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите числовое значение.");
                }
            }

            Console.Clear();
        }

        public static void SolveEquationsFromFile()
        {
            Console.Clear();
            Console.WriteLine("Введите путь к файлу:");
            string filePath = Console.ReadLine();
            IEnumerable<QuadraticEquation> equations = ReadEquationsFromFile(filePath);

            foreach (var equation in equations)
            {
                DisplayResults(equation);
                WaitForEnterInput();
            }
        }

        public static QuadraticEquation ReadEquationFromConsole()
        {
            QuadraticEquation equation = null;

            Console.WriteLine("Введите коэффициенты a, b, c (через пробел):");

            while (true)
            {
                string input = Console.ReadLine();

                var coefficients = input.Split(' ');

                if (coefficients.Length == 3 &&
                    double.TryParse(coefficients[0], CultureInfo.InvariantCulture, out double a) &&
                    double.TryParse(coefficients[1], CultureInfo.InvariantCulture, out double b) &&
                    double.TryParse(coefficients[2], CultureInfo.InvariantCulture, out double c))
                {
                    equation = new QuadraticEquation(a, b, c);
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                }
            }

            return equation;
        }

        public static IList<QuadraticEquation> ReadEquationsFromFile(string filePath)
        {
            IList<QuadraticEquation> equations = new List<QuadraticEquation>();

            try
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    var coefficients = line.Split(' ');

                    if (coefficients.Length == 3 &&
                        double.TryParse(coefficients[0], CultureInfo.InvariantCulture, out double a) &&
                        double.TryParse(coefficients[1], CultureInfo.InvariantCulture, out double b) &&
                        double.TryParse(coefficients[2], CultureInfo.InvariantCulture, out double c))
                    {
                        equations.Add(new QuadraticEquation(a, b, c));
                    }
                    else
                    {
                        Console.WriteLine($"Неверный формат строки: {line}");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Файл не найден: {filePath}");
                WaitForEnterInput();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Произошла ошибка ввода-вывода: {ex.Message}");
                WaitForEnterInput();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
                WaitForEnterInput();
            }

            return equations;
        }

        public static void WaitForEnterInput()
        {
            Console.WriteLine("Нажмите Enter для продолжения");

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }

            Console.Clear();
        }

        static void DisplayResults(QuadraticEquation equation)
        {
            var result = equation.Solve();

            if (result.RootsStatus != QuadraticEquationRootStatus.NoRoots)
            {
                if (result.RootsStatus == QuadraticEquationRootStatus.OneRoot)
                {
                    Console.WriteLine($"Уравнение {equation.A}x^2 + {equation.B}x + {equation.C} = 0 имеет один корень: x = {result.X1}");
                }
                else
                {
                    Console.WriteLine($"Уравнение {equation.A}x^2 + {equation.B}x + {equation.C} = 0 имеет два корня: x1 = {result.X1}, x2 = {result.X2}");
                }
            }
            else
            {
                Console.WriteLine($"Уравнение {equation.A}x^2 + {equation.B}x + {equation.C} = 0 не имеет действительных корней.");
            }
        }
    }
}
