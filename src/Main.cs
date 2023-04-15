using chessmag.src;
using chessmag.src.defs;

namespace chessmag
{
    public static class ChessMag
    {
        private static void Main()
        {
            UInt64 bitBoard = 0UL;

            ConsoleView.PrintBitBoard(bitBoard);

            bitBoard |= 1Ul << BBConversion.Board120to64[(int)Square.d2];

            Console.WriteLine("D2 added");

            ConsoleView.PrintBitBoard(bitBoard);

            bitBoard |= 1Ul << BBConversion.Board120to64[(int)Square.h2];

            Console.WriteLine("H2 added");

            ConsoleView.PrintBitBoard(bitBoard);


        }
    }
}