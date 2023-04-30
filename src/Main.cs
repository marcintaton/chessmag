using chessmag.defs;
using chessmag.engine;
using chessmag.utils;

namespace chessmag
{
    public static class ChessMag
    {
        private static void Main()
        {
            // ulong bitBoard = 0UL;

            // bitBoard = BitBoard.SetBit(bitBoard, (int)Square.d2);
            // bitBoard = BitBoard.SetBit(bitBoard, (int)Square.g4);
            // bitBoard = BitBoard.SetBit(bitBoard, (int)Square.e3);

            // bitBoard = BitBoard.UnsetBit(bitBoard, (int)Square.e3);

            // ConsoleView.PrintBitBoard(bitBoard);

            Board b = Fen.Parse(Constants.TestFEN6);

            ConsoleView.printBoard(b);

            Assertions.CheckBoard(b);

            var move = new Move(34, 36, (int)Piece.R, (int)Piece.p, true);

            Console.WriteLine(move.IsEnPas());
            Console.WriteLine(move.ToString());
        }
    }
}