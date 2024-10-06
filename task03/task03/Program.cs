using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите четырехзначное число");
            var a = int.Parse(Console.ReadLine());

            var thousands = a / 1000;
            var hundreds = (a / 100) % 10;
            var tens = (a / 10) % 10;
            var units = a % 10;

            var result = thousands * 1000 + tens * 100 + units * 10 + hundreds;

            Console.WriteLine(result);

            Console.ReadKey();



        }
    }
}
