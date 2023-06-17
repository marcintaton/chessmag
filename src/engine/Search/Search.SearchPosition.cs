using chessmag.defs;
using chessmag.protocols.UCI;
using chessmag.utils;

namespace chessmag.engine
{
    public static partial class Search
    {
        public static BoardWInfo SearchPosition(Board board, SearchInfo sInfo)
        {
            Move bestMove = Move.SEARCH_NEG;

            board = PrepForSearch(board);
            sInfo.Reset();

            // perform search via iterative deepening
            for (int currentDepth = 1; currentDepth <= sInfo.depth; currentDepth++)
            {
                // call aB
                var result = AlphaBeta(-Constants.Infinity, Constants.Infinity, currentDepth, board, sInfo, true);

                // check for time constraints
                if (sInfo.stopped || sInfo.quit)
                {
                    break;
                }

                board = result.board;
                sInfo = result.sInfo;

                PVLine pvLine = PV.GetPvLine(board, currentDepth);
                board.principalVariation = pvLine.line;
                bestMove = board.principalVariation[0];

                UCIIO.Info(bestMove, currentDepth, sInfo.nodes, pvLine);
            }

            UCIIO.BestMove(bestMove);

            return new BoardWInfo(board, sInfo);
        }
    }
}