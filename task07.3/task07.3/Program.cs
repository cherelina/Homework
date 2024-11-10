using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07._3
{
    using System;

    internal class Program
    {
        static void Main()
        {
            
            Console.WriteLine("Введите позицию белого слона:");
            var whiteBishopPosition = Console.ReadLine();

            int whiteBishopRow, whiteBishopColumn;
            DecodePosition(whiteBishopPosition, out whiteBishopRow, out whiteBishopColumn);
            Console.WriteLine($"Позиция белого слона: ({whiteBishopRow}; {whiteBishopColumn})");

            
            Console.WriteLine("Введите позицию черного коня:");
            var blackKnightPosition = Console.ReadLine();

            int blackKnightRow, blackKnightColumn;
            DecodePosition(blackKnightPosition, out blackKnightRow, out blackKnightColumn);
            Console.WriteLine($"Позиция черного коня: ({blackKnightRow}; {blackKnightColumn})");

            
            if (whiteBishopRow == blackKnightRow && whiteBishopColumn == blackKnightColumn)
            {
                Console.WriteLine("Позиции белого слона и черного коня не должны совпадать.");
                
                Console.ReadKey();
                return;
            }

            
            if (IsKnightAttacking(blackKnightRow, blackKnightColumn, whiteBishopRow, whiteBishopColumn))
            {
                Console.WriteLine("Белый слон находится под боем черного коня. Выберите другую начальную позицию.");
                
                Console.ReadKey();
                return;
            }

            
            Console.WriteLine("Введите позицию предполагаемого хода белого слона:");
            var targetPosition = Console.ReadLine();

            int targetRow, targetColumn;
            DecodePosition(targetPosition, out targetRow, out targetColumn);
            Console.WriteLine($"Позиция целевого хода: ({targetRow}; {targetColumn})");

            
            if (IsBishopMoveValid(whiteBishopRow, whiteBishopColumn, targetRow, targetColumn) &&
                !IsKnightAttacking(blackKnightRow, blackKnightColumn, targetRow, targetColumn))
            {
                Console.WriteLine("Белый слон может сделать ход на указанную клетку, и она не находится под боем черного коня.");
            }
            else
            {
                Console.WriteLine("Ход невозможен или клетка находится под боем черного коня.");
            }

            
            Console.ReadKey();
        }

        
        static void DecodePosition(string position, out int row, out int column)
        {
            row = int.Parse(position[1].ToString());
            column = position[0] - 'a' + 1;
        }

        
        static bool IsBishopMoveValid(int bishopRow, int bishopColumn, int targetRow, int targetColumn)
        {
            return Math.Abs(bishopRow - targetRow) == Math.Abs(bishopColumn - targetColumn);
        }

        
        static bool IsKnightAttacking(int knightRow, int knightColumn, int targetRow, int targetColumn)
        {
            return (Math.Abs(knightRow - targetRow) == 2 && Math.Abs(knightColumn - targetColumn) == 1) ||
                   (Math.Abs(knightRow - targetRow) == 1 && Math.Abs(knightColumn - targetColumn) == 2);
        }
    }
}