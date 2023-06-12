using chessmag.defs;
using chessmag.utils;

namespace chessmag.engine
{
    public static partial class Search
    {
        public static ABResult AlphaBeta(int alpha, int beta, int depth, Board board, SearchInfo sInfo, bool doNULL)
        {
            Assertions.CheckBoard(board);

            if (depth == 0)
            {
                sInfo.nodes++;
                // run quiescence
                return new ABResult(board, sInfo, Evaluation.Get(board));
            }

            sInfo.nodes++;

            if (Repetition.Check(board) || board.fiftyMoveCtr >= 100)
            {
                // draw by repetition or 50 move rule
                return new ABResult(board, sInfo, 0);
            }

            if (board.ply >= Constants.MaxDepth)
            {
                return new ABResult(board, sInfo, Evaluation.Get(board));
            }

            // actual search

            var moveList = MoveGenerator.GenerateAllMoves(board);

            int legalMoves = 0;
            int originalAlpha = alpha;
            Move bestMove = Move.SEARCH_NEG;

            for (int i = 0; i < moveList.count; i++)
            {
                moveList = PickNextMove(i, moveList);

                var moveRes = MoveCtrl.MakeMove(moveList.moves[i], board);

                if (!moveRes.wasLegal)
                {
                    continue;
                }
                board = moveRes.board;
                legalMoves++;

                var abRes = AlphaBeta(-beta, -alpha, depth - 1, board, sInfo, true);

                abRes.score *= -1;

                board = MoveCtrl.UnmakeMove(abRes.board);
                sInfo = abRes.sInfo;

                if (abRes.score > alpha)
                {
                    if (abRes.score >= beta)
                    {
                        if (legalMoves == 1) sInfo.failHighFirst++;
                        sInfo.failHigh++;
                        return new ABResult(board, sInfo, beta);
                    }
                    alpha = abRes.score;
                    bestMove = moveList.moves[i];
                }
            }

            if (legalMoves == 0)
            {
                if (Attack.IsSquareAttacked(board.kingSq[board.sideToMove], board.sideToMove ^ 1, board))
                {
                    // checkmate found
                    return new ABResult(board, sInfo, -Constants.Infinity + board.ply);
                }
                else
                {
                    // stalemate
                    return new ABResult(board, sInfo, 0);
                }
            }

            if (alpha != originalAlpha)
            {
                bestMove.score = alpha;
                PV.Store(board, bestMove);
            }

            return new ABResult(board, sInfo, alpha);
        }
    }
}