using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число элементов массива:");
            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Ошибка ввода.");
                Console.ReadKey();
                return;
            }

            var numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введите элемент {i + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out numbers[i]))
                {
                    Console.WriteLine("Ошибка ввода. Пожалуйста, введите целое число.");
                }
            }

            PrintArray(numbers);

            Console.WriteLine("Введите значение k для умножения элементов массива:");
            int k;
            while (!int.TryParse(Console.ReadLine(), out k))
            {
                Console.WriteLine("Ошибка ввода.");
            }

            MultiplyArray(numbers, k);
            PrintArray(numbers);

            double average = CalculateAverage(numbers);
            Console.WriteLine($"Среднее арифметическое элементов массива: {average}");

            var swappedArray = SwapArrayElements(numbers);
            PrintArray(swappedArray);

            Console.ReadKey();
        }

        static void PrintArray(int[] array)
        {
            foreach (var element in array)
                Console.Write($"{element} ");
            Console.WriteLine();
        }

        static void MultiplyArray(int[] array, int k)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] *= k;
            }
        }

        static double CalculateAverage(int[] array)
        {
            if (array == null || array.Length == 0) return 0;

            double sum = 0;
            foreach (var element in array)
                sum += element;

            return sum / array.Length;
        }

        static int[] SwapArrayElements(int[] array)
        {
            if (array == null || array.Length == 0) return new int[0];

            int[] swappedArray = new int[array.Length];
            Array.Copy(array, swappedArray, array.Length);

            int mid = swappedArray.Length / 2;
            for (int i = 0; i < mid; i++)
            {
                int temp = swappedArray[i];
                swappedArray[i] = swappedArray[swappedArray.Length - 1 - i];
                swappedArray[swappedArray.Length - 1 - i] = temp;
            }

            return swappedArray;
        }
    }
}

