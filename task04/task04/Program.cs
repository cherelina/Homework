using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите действительное число х");
            var x = double.Parse(Console.ReadLine());

            var y = MyFunction(x);
            Console.WriteLine($"f(x)={y}");
            Console.ReadKey();
        }
        static double MyFunction(double x)
        {
            //throw new NotImplementedException();
            return (Math.Pow(-x, 3) + 1 / (Math.Pow(x, 2) + 1)) / (1 + (5 / (Math.Pow(x, 2) + x + 1)));

        }
    }
}
