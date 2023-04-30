using System.Diagnostics;
using chessmag.defs;

namespace chessmag.engine
{
    public static class Attack
    {
        // no need for specific queen attack pattern, as it is king's AP multiplied 
        private static readonly int[] knightAttackPattern = new int[] { -8, -19, -21, -12, 8, 19, 21, 12 };
        private static readonly int[] rookAttackPattern = new int[] { -1, -10, 1, 10 };
        private static readonly int[] bishopAttackPattern = new int[] { -9, -11, 9, 11 };
        private static readonly int[] kingAttackPattern = new int[] { -1, -10, 1, 10, -9, -11, 9, 11 };


        // square - that is attacked
        // side - that is attacking the square
        public static bool IsSquareAttacked(int sq120, int side, Board board)
        {

            Debug.Assert(
                side == (int)Color.WHITE || side == (int)Color.BLACK,
                "Invalid attacking side. Got: " + side);
            Debug.Assert(
                sq120 >= BoardBaseConversion.Board64to120[0] && sq120 <= BoardBaseConversion.Board64to120[63],
                "Attacked square out of the board. Got: " + sq120);

            // pawns' attacks
            if (side == (int)Color.WHITE)
            {
                if (board.pieces[sq120 - 11] == (int)Piece.P || board.pieces[sq120 - 9] == (int)Piece.P) return true;
            }
            else
            {
                if (board.pieces[sq120 + 11] == (int)Piece.p || board.pieces[sq120 + 9] == (int)Piece.p) return true;
            }

            // knights' attacks
            for (int i = 0; i < knightAttackPattern.Length; i++)
            {
                int piece = board.pieces[sq120 + knightAttackPattern[i]];
                if (PieceData.isKnight[piece] && PieceData.pieceColor[piece] == side)
                {
                    return true;
                }
            }

            // rooks' and queens' attacks
            for (int i = 0; i < rookAttackPattern.Length; i++)
            {
                int dir = rookAttackPattern[i];
                int t_sq120 = sq120 + dir;
                int piece = board.pieces[t_sq120];
                while (!BoardBaseConversion.IsOffboard(t_sq120))
                {
                    if (piece != (int)Piece.NONE)
                    {
                        if (PieceData.isRookQueen[piece] && PieceData.pieceColor[piece] == side)
                        {
                            return true;
                        }
                        break;
                    }
                    t_sq120 += dir;
                    piece = board.pieces[t_sq120];
                }
            }

            // bishops' and queens' attacks
            for (int i = 0; i < bishopAttackPattern.Length; i++)
            {
                int dir = bishopAttackPattern[i];
                int t_sq120 = sq120 + dir;
                int piece = board.pieces[t_sq120];
                while (!BoardBaseConversion.IsOffboard(t_sq120))
                {
                    if (piece != (int)Piece.NONE)
                    {
                        if (PieceData.isBishopQueen[piece] && PieceData.pieceColor[piece] == side)
                        {
                            return true;
                        }
                        break;
                    }
                    t_sq120 += dir;
                    piece = board.pieces[t_sq120];
                }
            }

            // kings' attacks
            for (int i = 0; i < kingAttackPattern.Length; i++)
            {
                int piece = board.pieces[sq120 + kingAttackPattern[i]];
                if (PieceData.isKing[piece] && PieceData.pieceColor[piece] == side)
                {
                    return true;
                }
            }

            return false;
        }
    }
}