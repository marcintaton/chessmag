using chessmag.src;
using chessmag.src.defs;

namespace chessmag
{
    public static class ChessMag
    {
        private static void Main()
        {
            ulong bitBoard = 0UL;

            ConsoleView.PrintBitBoard(bitBoard);

            bitBoard = BitBoard.PushPiece(bitBoard, Square.d2);

            Console.WriteLine("D2 added");

            ConsoleView.PrintBitBoard(bitBoard);

            bitBoard = BitBoard.PushPiece(bitBoard, Square.g4);


            Console.WriteLine("H2 added");

            ConsoleView.PrintBitBoard(bitBoard);


        }
    }
}