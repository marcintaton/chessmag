using chessmag.src;
using chessmag.src.defs;

namespace chessmag
{
    public static class ChessMag
    {
        private static void Main()
        {
            ulong bitBoard = 0UL;

            bitBoard = BitBoard.PushBit(bitBoard, Square.d2);
            bitBoard = BitBoard.PushBit(bitBoard, Square.g4);
            bitBoard = BitBoard.PushBit(bitBoard, Square.e3);

            ConsoleView.PrintBitBoard(bitBoard);
        }
    }
}