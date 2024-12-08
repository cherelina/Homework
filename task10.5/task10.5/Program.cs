using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите натуральное число");
            int number;
            if (!int.TryParse(Console.ReadLine(), out number) || number < 1)
            {
                Console.WriteLine("Ошибка ввода");
                Console.ReadKey();
                return;
            }

            int largestPrimeDivisor = 1; 
            int temp = number;

            
            for (int i = 2; i <= Math.Sqrt(temp); i++)
            {
                
                while (temp % i == 0)
                {
                    largestPrimeDivisor = i; 
                    temp /= i; 
                }
            }

            
            if (temp > 1)
            {
                largestPrimeDivisor = temp;
            }

            Console.WriteLine($"Наибольший простой делитель числа {number} равен {largestPrimeDivisor}");
            Console.ReadKey();
        }
    }
}
    