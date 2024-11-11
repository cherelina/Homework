using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите значение x: ");
            var x = double.Parse (Console.ReadLine());
            
            Console.WriteLine($"f(x) = {MyFunction(x)}");

            Console.ReadKey();
        }
        static double MyFunction (double x)
        {
            if (x < 2)
                return x - 2;
            else if (2 <= x && x <= 3)
                return 0;
            else  
                    return 3 - x;

        }

    }
}

