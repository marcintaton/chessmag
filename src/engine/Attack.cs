using System.Diagnostics;
using chessmag.defs;
using chessmag.utils;

namespace chessmag.engine
{
    public static class Attack
    {
        // square - that is attacked
        // side - that is attacking the square
        public static bool IsSquareAttacked(int sq120, int side, Board board)
        {
            Assertions.SideValid(side);
            Assertions.SqOnBoard(sq120);
            Assertions.CheckBoard(board);

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
            for (int i = 0; i < PieceData.knightMovePattern.Length; i++)
            {
                int piece = board.pieces[sq120 + PieceData.knightMovePattern[i]];
                if (PieceData.isKnight[piece] && PieceData.pieceColor[piece] == side)
                {
                    return true;
                }
            }

            // rooks' and queens' attacks
            for (int i = 0; i < PieceData.rookMovePattern.Length; i++)
            {
                int dir = PieceData.rookMovePattern[i];
                int t_sq120 = sq120 + dir;
                int piece = board.pieces[t_sq120];
                while (!BBC.IsOffboard(t_sq120))
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
            for (int i = 0; i < PieceData.bishopMovePattern.Length; i++)
            {
                int dir = PieceData.bishopMovePattern[i];
                int t_sq120 = sq120 + dir;
                int piece = board.pieces[t_sq120];
                while (!BBC.IsOffboard(t_sq120))
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
            for (int i = 0; i < PieceData.kingMovePattern.Length; i++)
            {
                int piece = board.pieces[sq120 + PieceData.kingMovePattern[i]];
                if (PieceData.isKing[piece] && PieceData.pieceColor[piece] == side)
                {
                    return true;
                }
            }

            return false;
        }
    }
}