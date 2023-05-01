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

            Board b = Fen.Parse(Constants.TestFEN8);

            IO.PrintBoard(b);

            Assertions.CheckBoard(b);

            var list = MoveGenerator.GenerateAllMoves(b);
            IO.PrintMoveList(list);

            Console.WriteLine(list.moves[0]);

            var result = MoveCtrl.MakeMove(list.moves[0], b);

            b = result.board;

            Assertions.CheckBoard(b);

            IO.PrintBoard(b);

            b = MoveCtrl.UnmakeMove(b);

            Assertions.CheckBoard(b);

            IO.PrintBoard(b);
        }
    }
}