using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m = 0;
            if (!TryInputNumber("Введите число m", out m))
            {
                Console.ReadKey();
                return;
            }
            if (m < 1)
            {
                Console.WriteLine("Число m должно быть натуральным");
                Console.ReadKey();
                return;
            }

            int n = 0;
            if (!TryInputNumber("Введите число n", out n))
            {
                Console.ReadKey();
                return;
            }
            if (n < 1)
            {
                Console.WriteLine("Число n должно быть натуральным");
                Console.ReadKey();
                return;
            }

            long sum = 0; 

            
            for (int i = 1; i <= m; i++)
            {
                sum += Power(i, n); 
            }

            Console.WriteLine($"Сумма 1^{n} + 2^{n} + ... + {m}^{n} = {sum}");
            Console.ReadKey();
        }

        
        static long Power(int baseNum, int exp)
        {
            long result = 1;
            for (int i = 0; i < exp; i++)
            {
                result *= baseNum; 
            }
            return result;
        }

        
        static bool TryInputNumber(string message, out int number)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Ошибка ввода");
                return false;
            }
            return true;
        }
    }

}
 
