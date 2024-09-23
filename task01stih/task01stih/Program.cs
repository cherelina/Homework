using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task01stih
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Зимний вечер");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Буря мглою небо кроет,");
            Console.WriteLine("Вихри снежные крутя;");
            Console.WriteLine("То как зверь она завоет,");
            Console.WriteLine("То заплачет как дитя...");

            Console.ResetColor();

            Console.ReadKey ();
        }
    }
}
