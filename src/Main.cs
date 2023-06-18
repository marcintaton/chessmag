using System.Diagnostics;
using chessmag.defs;
using chessmag.engine;
using chessmag.protocols.UCI;
using chessmag.protocols.xBoard;
using chessmag.tests;
using chessmag.utils;

namespace chessmag
{
    public static class ChessMag
    {
        private static void Main()
        {
            // UCI.MainLoop();

            Board board = Fen.Parse("K7/8/1q6/8/8/8/8/7k w - - 0 1");

            XBoard.CheckGameState(board);
        }
    }
}