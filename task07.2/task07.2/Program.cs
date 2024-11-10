using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты (x, y) через пробел");

            var input = Console.ReadLine();
            var k = input.IndexOf(' ');

            var x = double.Parse(input.Substring(0, k));
            var y = double.Parse(input.Substring(k + 1));

            if (IsPointInArea (x, y))
                Console.WriteLine("Точка лежит в области");
            else
                Console.WriteLine("Точка не в области");

            Console.ReadKey();
        }
        static bool IsPointInArea (double x, double y)
        {
            return y <= 1.5 && y >= -2; 
        } 
    }
}
