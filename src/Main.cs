using chessmag.src;
using chessmag.src.defs;
using chessmag.src.utils;

namespace chessmag
{
    public static class ChessMag
    {
        private static void Main()
        {
            // ulong bitBoard = 0UL;

            // bitBoard = BitBoard.SetBit(bitBoard, Square.d2);
            // bitBoard = BitBoard.SetBit(bitBoard, Square.g4);
            // bitBoard = BitBoard.SetBit(bitBoard, Square.e3);

            // bitBoard = BitBoard.UnsetBit(bitBoard, Square.e3);

            // ConsoleView.PrintBitBoard(bitBoard);

            Board b = Fen.Parse(Constants.StartingFEN);

            ConsoleView.printBoard(b);

            // b = Fen.Parse(Constants.TestFEN1);

            // ConsoleView.printBoard(b);

            // b = Fen.Parse(Constants.TestFEN2);

            // ConsoleView.printBoard(b);

            // b = Fen.Parse(Constants.TestFEN3);

            // ConsoleView.printBoard(b);

        }
    }
}