using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
           double a;
                do
                {
                    Console.Write("Введите число a (a > 1): ");
                } while (!double.TryParse(Console.ReadLine(), out a) || a <= 1);

                double sum = 0;
                int n = 0;

                Console.WriteLine($"Сумма будет вычисляться до тех пор, пока она меньше {a}:");

                while (sum < a)
                {
                    n++;
                    sum += 1.0 / n;
                    if (sum < a)
                    {
                        Console.WriteLine($"n = {n}, сумма = {sum}");
                    }
                }

                Console.WriteLine();
                Console.ReadKey();
            }
        }

    }

