using chessmag.engine;
using chessmag.utils;

namespace chessmag.defs
{
    public struct MoveList
    {
        public int count;
        public Move[] moves = new Move[Constants.MaxPosMoves];

        public MoveList()
        {
        }

        // why do we need a board?
        public void AddQuietMove(Move move, Board board)
        {
            if (board.searchKillers[0, board.ply].move == move.move)
            {
                move.score = MoveOrdering.KILLER_VALUE1;
            }
            else if (board.searchKillers[1, board.ply].move == move.move)
            {
                move.score = MoveOrdering.KILLER_VALUE2;
            }
            else
            {
                move.score = board.searchHistory[board.pieces[move.FromSq], board.pieces[move.ToSq]];
            }

            moves[count] = move;
            count++;
        }

        public void AddCaptureMove(Move move, int attacker)
        {
            move.score = MoveOrdering.MvvLvaScores[move.PceCaptured, attacker] + MoveOrdering.CAPTURE_VALUE;
            moves[count] = move;
            count++;
        }

        public void AddEnPassantMove(Move move)
        {
            move.score = MoveOrdering.MVV_VLA_PAWN_TAKES_PAWN + MoveOrdering.CAPTURE_VALUE;
            moves[count] = move;
            count++;
        }

        public void AddPawnMove(Move move, Board board)
        {
            Assertions.PieceValidOrNone(move.PceCaptured);
            Assertions.SqOnBoard(move.FromSq);
            Assertions.SqOnBoard(move.ToSq);

            int promotionRank = board.sideToMove == (int)Color.WHITE ? (int)Rank._7 : (int)Rank._2;
            int promPieceStart = board.sideToMove == (int)Color.WHITE ? (int)Piece.R : (int)Piece.r;
            int attacker = board.sideToMove == (int)Color.WHITE ? (int)Piece.P : (int)Piece.P;

            if (BBC.Sq120ToRank[move.FromSq] == promotionRank)
            {
                for (int i = 0; i < 4; i++)
                {
                    move.PcePromoted = promPieceStart + i;
                    if (move.Capture) AddCaptureMove(move, attacker); else AddQuietMove(move, board);
                }
            }
            else
            {
                if (move.Capture) AddCaptureMove(move, attacker); else AddQuietMove(move, board);
            }
        }
    }
}