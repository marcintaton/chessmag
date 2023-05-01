using chessmag.defs;
using chessmag.engine;
using chessmag.utils;

namespace chessmag.tests
{
    public static class Perft
    {
        private static int leafNodes = 0;

        public static int Test(int depth, Board board)
        {
            leafNodes = 0;
            Run(depth, board);

            return leafNodes;
        }

        private static void Run(int depth, Board board)
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


                Console.WriteLine("--------------------------------");
                var move = moveList.moves[i];
                Console.WriteLine(move + " Capture: " + move.Capture + " EnPas: " + move.EnPassant + " Promotion: " + move.Promotion);
                IO.PrintBoard(board);

                if (result.inCheck)
                {
                    continue;
                }

                Run(depth - 1, board);
                board = MoveCtrl.UnmakeMove(board);
            }
        }
    }
}