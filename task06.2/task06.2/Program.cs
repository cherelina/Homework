using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task06._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "прогулка";
            Console.WriteLine($"Из слова \"{s}\"получили");

            var word1 = s.Remove(4, 2)
                .Remove(0, 1)
                .Substring(2, 1) +
                s.Substring(2, 1) +
                s.Substring(1, 1) +
                s.Substring(6, 2);

            Console.WriteLine(word1);

            var word2 = s.Remove(4, 4)
                .Substring(0, 1) +
                s.Substring(2, 1) +
                s.Substring(1, 2) +
                s.Substring(3, 1);

                

            Console.WriteLine(word2);

            Console.ReadKey();

        }
       
        
    }

}
