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
            var data = new PerftData[]
            {
                new PerftData(Constants.StartingFEN, new int[] { 20, 400, 8902, 197281, 4865609, 119060324 }),
                new PerftData(Constants.LegendaryFEN, new int[] { 48, 2039, 97862, 4085603, 193690690 }),
                new PerftData("4k3/8/8/8/8/8/8/4K2R w K - 0 1", new int[] { 15, 66, 1197, 7059, 133987, 764643 }),
                new PerftData("4k3/8/8/8/8/8/8/R3K3 w Q - 0 1", new int[] { 16, 71, 1287, 7626, 145232, 846648 }),
                new PerftData("4k2r/8/8/8/8/8/8/4K3 w k - 0 1", new int[] { 5, 75, 459, 8290, 47635, 899442 }),
                new PerftData("r3k3/8/8/8/8/8/8/4K3 w q - 0 1", new int[] { 5, 80, 493, 8897, 52710, 1001523 }),
                new PerftData("4k3/8/8/8/8/8/8/R3K2R w KQ - 0 1", new int[] { 26, 112, 3189, 17945, 532933, 2788982 }),
                new PerftData("r3k2r/8/8/8/8/8/8/4K3 w kq - 0 1", new int[] { 5, 130, 782, 22180, 118882, 3517770 }),
                new PerftData("8/8/8/8/8/8/6k1/4K2R w K - 0 1", new int[] { 12, 38, 564, 2219, 37735, 185867 }),
                new PerftData("8/8/8/8/8/8/1k6/R3K3 w Q - 0 1", new int[] { 15, 65, 1018, 4573, 80619, 413018 }),
                new PerftData("4k2r/6K1/8/8/8/8/8/8 w k - 0 1", new int[] { 3, 32, 134, 2073, 10485, 179869 }),
                new PerftData("r3k3/1K6/8/8/8/8/8/8 w q - 0 1", new int[] { 4, 49, 243, 3991, 20780, 367724 }),
            };

            foreach (var dataItem in data)
            {
                Board b = Fen.Parse(dataItem.fen);

                IO.PrintBoard(b);
                Console.WriteLine("Fen: " + dataItem.fen);
                Assertions.CheckBoard(b);

                Perft.Test(dataItem);

            }



        }
    }
}