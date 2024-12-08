using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10._2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            {
                Console.Write("Введите натуральное число n: ");
                int n = int.Parse(Console.ReadLine());

                if (n < 2)
                {
                    Console.WriteLine("Для вычисления произведения должно быть как минимум два числа");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Введите a0: ");
                double previous = double.Parse(Console.ReadLine());

                double current;
                double lastProduct;
                string products = "";
                int i = 1;

                while (i <= n)
                {
                    Console.Write($"Введите a{i}: ");
                    current = double.Parse(Console.ReadLine());

                    lastProduct = previous * current;
                    products += lastProduct + ", ";

                    previous = current;
                    i++;
                }

                Console.WriteLine($"Последовательность произведений соседних чисел: {products}");

                Console.ReadKey();
            }
        }
    }
}
    

