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
            var board = Fen.Parse(Constants.StartingFEN);
            IO.PrintBoard(board);
            Assertions.CheckBoard(board);
        }
    }
}