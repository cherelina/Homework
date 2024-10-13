using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var x = F(2, 3) + F(3, 5) + F(4, 3);
            Console.WriteLine($"x= {x:F3}");

            Console.ReadKey();

        }
        static double F(double a, double b)
        {
            return (Math.Sin((Math.Pow(a, a) + 1) / (Math.Pow(b, b) + 1)));
        }
    }
}
