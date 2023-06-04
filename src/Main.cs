using chessmag.defs;
using chessmag.engine;
using chessmag.tests;
using chessmag.utils;

namespace chessmag
{
    public static class ChessMag
    {
        private static void Main(string[] args)
        {
            Board b = Fen.Parse(Constants.TestFEN6);

            IO.PrintBoard(b);
            Assertions.CheckBoard(b);

            // b = MoveCtrl.MakeMove(new Move((int)Square.b5, (int)Square.c6, (int)Piece.NONE, (int)Piece.NONE, true), b).board;

            // IO.PrintBoard(b);
            // Assertions.CheckBoard(b);

            // b = MoveCtrl.UnmakeMove(b);

            // IO.PrintBoard(b);
            // Assertions.CheckBoard(b);

            ///
            if (args.Length >= 1)
            {
                var depth = Int32.Parse(args[0]);
                var result = Perft.Test(depth, b, false);
                Console.WriteLine("Moves found " + result);
            }
            ///
        }
    }
}