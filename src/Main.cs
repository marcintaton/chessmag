using chessmag.protocols.xBoard;
using chessmag.defs;
using chessmag.engine;
using chessmag.tests;
using chessmag.utils;

namespace chessmag
{
    public static class ChessMag
    {
        private static void Main()
        {
            // XBoard.Loop();

            Board b = Fen.Parse(Constants.StartingFEN);

            IO.PrintBoard(b);
            Assertions.CheckBoard(b);

            b = MoveCtrl.MakeMove(new Move((int)Square.a2, (int)Square.a3, (int)Piece.NONE, (int)Piece.NONE, true), b).board;

            IO.PrintBoard(b);
            Assertions.CheckBoard(b);

            // b = MoveCtrl.UnmakeMove(b);

            // IO.PrintBoard(b);
            // Assertions.CheckBoard(b);
        }
    }
}