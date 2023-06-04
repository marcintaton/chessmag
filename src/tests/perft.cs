using chessmag.defs;
using chessmag.engine;
using chessmag.utils;

namespace chessmag.tests
{
    public static class Perft
    {
        private static int leafNodes = 0;

        public static int Test(int depth, Board board, bool withOutput = false)
        {
            leafNodes = 0;
            Run(depth, board, withOutput);

            return leafNodes;
        }

        private static void Run(int depth, Board board, bool withOutput)
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

                var move = moveList.moves[i];

                if (withOutput)
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine(move + " Capture: " + move.Capture + " EnPas: " + move.EnPassant + " Promotion: " + move.Promotion);
                    IO.PrintBoard(board);
                }

                if (result.inCheck)
                {
                    continue;
                }

                Run(depth - 1, board, withOutput);
                board = MoveCtrl.UnmakeMove(board);
            }
        }
    }
}