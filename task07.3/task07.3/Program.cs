using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите позицию белой фигуры");
            var whiteElephantPosition = Console.ReadLine();

            var whiteElephantRow, whiteElephantColumn;

            
            Console.WriteLine();
        }
        static void DecodePosition(string position, out int x, out int y)
        {
            x = int.Parse(position[1].ToString());
            y = (int)position[0] - 0x60;
        }
    }
}
