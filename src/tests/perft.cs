using chessmag.defs;
using chessmag.engine;
using chessmag.utils;

namespace chessmag.tests
{
    public struct PerftData
    {
        public string fen;
        public int[] moveCount;

        public PerftData(string fen, int[] moveCount)
        {
            this.fen = fen;
            this.moveCount = moveCount;
        }
    }

    public static class Perft
    {
        private static int leafNodes = 0;

        public static int Test(int depth, Board board)
        {
            leafNodes = 0;
            TestSinglePosition(depth, board);

            return leafNodes;
        }

        public static int Test(PerftData data)
        {

            var board = Fen.Parse(data.fen);

            for (int depth = 1; depth <= data.moveCount.Length; depth++)
            {
                leafNodes = 0;
                TestSinglePosition(depth, board);
                Console.WriteLine("Depth: "
                                  + depth
                                  + "; Moves found: "
                                  + leafNodes
                                  + "; Moves expected: "
                                  + data.moveCount[depth - 1]
                                  + "; Result: "
                                  + (leafNodes == data.moveCount[depth - 1]));
            }


            return leafNodes;
        }

        private static void TestSinglePosition(int depth, Board board)
        {
            Assertions.CheckBoard(board);

            if (depth == 0)
            {
                leafNodes++;
                return;
            }

            MoveList moveList = MoveGenerator.GenerateAllMoves(board);

            for (int i = 0; i < moveList.count; i++)
            {
                var result = MoveCtrl.MakeMove(moveList.moves[i], board);
                board = result.board;

                // var move = moveList.moves[i];
                // Console.WriteLine("--------------------------------");
                // Console.WriteLine(move + " Capture: " + move.Capture + " EnPas: " + move.EnPassant + " Promotion: " + move.Promotion);
                // IO.PrintBoard(board);

                if (result.inCheck)
                {
                    continue;
                }

                TestSinglePosition(depth - 1, board);
                board = MoveCtrl.UnmakeMove(board);
            }
        }
    }
}