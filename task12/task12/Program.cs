using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число m от 5 до 20");
            int m;
            if (!TryInputNumber(out m) || m < 5 || m > 20)
            {
                Console.WriteLine("Число m не удовлетворяет условию 5 <= m <= 20");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Введите целое число n от 5 до 20");
            int n;
            if (!TryInputNumber(out n) || n < 5 || n > 20)
            {
                Console.WriteLine("Число n не удовлетворяет условию 5 <= n <= 20");
                Console.ReadKey();
                return;
            }

            var matrix = new int[m, n];
            var rnd = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = rnd.Next(100);

            Console.WriteLine();
            PrintMatrix(matrix);
            Console.WriteLine();

            
            Console.WriteLine("Введите границы интервала a и b:");
            int a, b;
            if (!TryInputNumber(out a) || !TryInputNumber(out b))
            {
                Console.WriteLine("Ошибка ввода границ интервала.");
                return;
            }

            if (!CheckElementsInInterval(matrix, a, b))
            {
                Console.WriteLine("Некоторые элементы массива не находятся в заданном интервале.");
            }
            else
            {
                Console.WriteLine("Все элементы массива находятся в заданном интервале.");
            }

            
            var differences = CalculateDifferences(matrix);
            for (int j = 0; j < differences.Length; j++)
            {
                Console.WriteLine($"Разность между макс. и мин. значениями в столбце {j}: {differences[j]}");
            }

            Console.ReadKey();
        }

        static bool TryInputNumber(out int number)
        {
            number = 0;
            return int.TryParse(Console.ReadLine(), out number);
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j],2} ");
                Console.WriteLine();
            }
        }

        static bool CheckElementsInInterval(int[,] matrix, int a, int b)
        {
            bool inInterval = true;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < a || matrix[i, j] > b)
                    {
                        Console.WriteLine($"Элемент {matrix[i, j]} на индексе [{i}, {j}] нарушает условие.");
                        inInterval = false;
                    }
                }
            }

            return inInterval;
        }

        static int[] CalculateDifferences(int[,] matrix)
        {
            int[] result = new int[matrix.GetLength(1)];

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int max = matrix[0, j];
                int min = matrix[0, j];

                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > max)
                        max = matrix[i, j];
                    if (matrix[i, j] < min)
                        min = matrix[i, j];
                }

                result[j] = max - min;
            }

            return result;
        }
    }
}
