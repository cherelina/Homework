using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;
            do
            {
                if (!TryInputNumber("Введите натуральное число (0 для выхода):", out number) || number < 0)
                {
                    Console.ReadKey();
                    return;
                }

                int maxDigit = 0;
                int minDigit = 9;
                int tempNumber = number;

                
                while (tempNumber > 0)
                {
                    int digit = tempNumber % 10; 

                    if (digit > maxDigit)
                        maxDigit = digit;

                    if (digit < minDigit)
                        minDigit = digit;

                    tempNumber /= 10; 
                }

                int sum = maxDigit + minDigit;
                Console.WriteLine($"Сумма максимальной ({maxDigit}) и минимальной ({minDigit}) цифр числа {number} равна {sum}");

            } while (number != 0);

            Console.WriteLine("Завершение программы.");
            Console.ReadKey();
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
  
