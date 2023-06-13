using chessmag.defs;
using chessmag.utils;

namespace chessmag.engine
{
    public static partial class Search
    {
        public static void SearchPosition(Board board, SearchInfo sInfo)
        {
            Move bestMove = Move.SEARCH_NEG;
            int bestScore = -Constants.Infinity;

            board = PrepForSearch(board);
            sInfo.Reset();

            // perform search via iterative deepening
            for (int currentDepth = 1; currentDepth <= sInfo.depth; currentDepth++)
            {
                // call aB
                var result = AlphaBeta(-Constants.Infinity, Constants.Infinity, currentDepth, board, sInfo, true);

                // check for time constraints
                if (sInfo.stopped)
                {
                    break;
                }

                board = result.board;
                sInfo = result.sInfo;
                bestScore = result.score;

                PVLine pvLine = PV.GetPvLine(board, currentDepth);
                board.principalVariation = pvLine.line;
                bestMove = board.principalVariation[0];

                IO.PrintSearchInfo(bestMove, currentDepth, sInfo, pvLine);
            }

            IO.PrintScore(bestScore);
        }
    }
}