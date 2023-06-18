using chessmag.defs;

namespace chessmag.engine
{
    public static partial class Search
    {
        public static ABResult Quiescence(int alpha, int beta, Board board, SearchInfo sInfo)
        {
            if ((sInfo.nodes & Constants.NodeCountCheckup) == 0)
            {
                sInfo = CheckUp(sInfo);

                if (sInfo.stopped || sInfo.quit)
                {
                    return new ABResult(board, sInfo, 0);
                }
            }

            sInfo.nodes++;

            if ((BoardState.CheckRepetition(board) || board.fiftyMoveCtr >= 100) && board.ply != 0)
            {
                // draw by repetition or 50 move rule
                return new ABResult(board, sInfo, 0);
            }

            if (board.ply >= Constants.MaxDepth)
            {
                return new ABResult(board, sInfo, Evaluation.Get(board));
            }

            int score = Evaluation.Get(board);

            if (score >= beta)
            {
                return new ABResult(board, sInfo, beta);
            }

            if (score > alpha)
            {
                alpha = score;
            }

            var moveList = MoveGenerator.GenerateAllCaptures(board);

            int legalMoves = 0;

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

                var abRes = Quiescence(-beta, -alpha, board, sInfo);

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

                        return new ABResult(board, sInfo, beta);
                    }
                    alpha = abRes.score;
                }
            }

            return new ABResult(board, sInfo, alpha);
        }
    }
}