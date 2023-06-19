using System.Diagnostics;
using System.Net.Sockets;
using chessmag.defs;
using chessmag.protocols.UCI;
using chessmag.protocols.UserMode;
using chessmag.protocols.xBoard;
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

                if (sInfo.protocol == Protocol.UCI)
                {
                    UCIIO.Info(bestMove, currentDepth, sInfo.nodes, pvLine);
                }
                else if (sInfo.protocol == Protocol.XBOARD && sInfo.verbose)
                {
                    XBoardIO.Info(bestMove, currentDepth, sInfo.nodes, pvLine);
                }
                else if (sInfo.protocol == Protocol.USER && sInfo.verbose)
                {
                    UserModeIO.Info(bestMove, currentDepth, sInfo.nodes, pvLine);
                }
            }

            if (sInfo.protocol == Protocol.UCI)
            {
                UCIIO.BestMove(bestMove);
            }
            else if (sInfo.protocol == Protocol.XBOARD)
            {
                XBoardIO.BestMove(bestMove);
                board = MoveCtrl.MakeMove(bestMove, board).board;
            }
            else if (sInfo.protocol == Protocol.USER)
            {
                UserModeIO.BestMove(bestMove);
                board = MoveCtrl.MakeMove(bestMove, board).board;
                IO.PrintBoard(board, false);
            }
            return new BoardWInfo(board, sInfo);
        }
    }
}