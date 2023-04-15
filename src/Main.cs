using chessmag.src;
using chessmag.src.defs;

namespace chessmag
{
    public static class ChessMag
    {
        private static void Main()
        {
            ulong bitBoard = 0UL;

            bitBoard = BitBoard.SetBit(bitBoard, Square.d2);
            bitBoard = BitBoard.SetBit(bitBoard, Square.g4);
            bitBoard = BitBoard.SetBit(bitBoard, Square.e3);

            bitBoard = BitBoard.UnsetBit(bitBoard, Square.e3);


            ConsoleView.PrintBitBoard(bitBoard);
        }
    }
}