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
            Board b = Fen.Parse(Constants.StartingFEN);

            IO.PrintBoard(b);

            Assertions.CheckBoard(b);

            ///
            var result = Perft.Test(5, b);
            Console.WriteLine("Moves found " + result);
            ///
        }
    }
}