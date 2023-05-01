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
        public void AddQuietMove(Move move)
        {
            moves[count] = move;
            count++;
        }

        public void AddCaptureMove(Move move)
        {
            moves[count] = move;
            count++;
        }

        public void AddEnPassantMove(Move move)
        {
            moves[count] = move;
            count++;
        }

        public void AddPawnMove(Move move, int color)
        {
            Assertions.PieceValidOrNone(move.PceCaptured);
            Assertions.SqOnBoard(move.FromSq);
            Assertions.SqOnBoard(move.ToSq);

            int promotionRank = color == (int)Color.WHITE ? (int)Rank._7 : (int)Rank._2;
            int promPieceStart = color == (int)Color.WHITE ? (int)Piece.R : (int)Piece.r;

            if (BoardBaseConversion.Sq120ToRank[move.FromSq] == promotionRank)
            {
                for (int i = 0; i < 4; i++)
                {
                    move.PcePromoted = promPieceStart + i;
                    if (move.Capture) AddCaptureMove(move); else AddQuietMove(move);
                }
            }
            else
            {
                if (move.Capture) AddCaptureMove(move); else AddQuietMove(move);
            }
        }
    }
}