using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первый член геометрической прогрессии");
            var a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите знаментель геометрической прогрессии");
            var b = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите номер члена прогрессии");
            var c = int.Parse(Console.ReadLine());

            var x = a * Math.Pow(b, c - 1);
            Console.WriteLine(x);
           
            Console.ReadKey();

        }
    }
}
