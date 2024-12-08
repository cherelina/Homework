using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10._1
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Введите число n: ");
            int n;

            if (!int.TryParse(Console.ReadLine(), out n) || n <= 1)
            {
                Console.WriteLine("Число должно быть больше 1");
                Console.ReadKey();
                return;
            }

            double totalSum = 0;

            for (int i = 1; i <= n; i++)
            {
                int sign = (i % 2 == 1) ? 1 : -1;
                totalSum += sign * (1.0 / i);
            }

            Console.WriteLine($"Сумма 1 - 1/2 + 1/3 - ... + (-1)^(n+1) * 1/n для n={n}: {totalSum}");

            Console.ReadKey();
        }
    }
}