using System.Net.Sockets;
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
                // sInfo.nodes++;
                // return new ABResult(board, sInfo, Evaluation.Get(board));
                return Quiescence(alpha, beta, board, sInfo);
            }

            if ((sInfo.nodes & Constants.NodeCountCheckup) == 0)
            {
                sInfo = CheckUp(sInfo);

                if (sInfo.stopped || sInfo.quit)
                {
                    return new ABResult(board, sInfo, 0);
                }
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
            Move pvMove = PV.Probe(board);

            if (pvMove.move != Move.NOMOVE)
            {
                for (int i = 0; i < moveList.count; i++)
                {
                    if (moveList.moves[i].move == pvMove.move)
                    {
                        moveList.moves[i].score = MoveOrdering.ALWAYS_FIRST;
                        break;
                    }
                }
            }

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

                if (sInfo.stopped)
                {
                    return new ABResult(board, sInfo, 0);
                }

                if (abRes.score > alpha)
                {
                    if (abRes.score >= beta)
                    {
                        if (legalMoves == 1) sInfo.failHighFirst++;
                        sInfo.failHigh++;

                        if (!moveList.moves[i].Capture)
                        {
                            board.searchKillers[1, board.ply] = board.searchKillers[0, board.ply];
                            board.searchKillers[0, board.ply] = moveList.moves[i];
                        }

                        return new ABResult(board, sInfo, beta);
                    }
                    alpha = abRes.score;
                    bestMove = moveList.moves[i];

                    if (!moveList.moves[i].Capture)
                    {
                        board.searchHistory[board.pieces[bestMove.FromSq], board.pieces[bestMove.ToSq]] += depth;
                    }

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