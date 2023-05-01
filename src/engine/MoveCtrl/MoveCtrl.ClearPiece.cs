using chessmag.defs;
using chessmag.utils;

namespace chessmag.engine
{
    public static partial class MoveCtrl
    {
        public static Board ClearPiece(int sq120, Board board)
        {
            Assertions.SqOnBoard(sq120);

            int piece = board.pieces[sq120];

            Assertions.PieceValid(piece);

            board.positionHash = HashPce(board, sq120, piece);

            int color = PieceData.pieceColor[piece];

            board.pieces[sq120] = (int)Piece.NONE;
            board.materials[color] -= PieceData.pieceValue[piece];

            if (PieceData.isPieceBig[piece])
            {
                board.bigPceNum[color]--;
                if (PieceData.isPieceMaj[piece])
                {
                    board.majorPcsNum[color]--;
                }
                else
                {
                    board.minorPcsNum[color]--;
                }
            }
            else
            {
                // pawn
                board.pawns[color] = BitBoard.UnsetBit(board.pawns[color], sq120);
                board.pawns[(int)Color.BOTH] = BitBoard.UnsetBit(board.pawns[(int)Color.BOTH], sq120);
            }

            // handle piecelist
            int i;
            for (i = 0; i < board.pieceList.GetLength(1); i++)
            {
                if (board.pieceList[piece, i] == sq120)
                {
                    board.pieceList[piece, i] = 0;
                    break;
                }
            }
            for (i++; i < board.pieceList.GetLength(1); i++)
            {
                board.pieceList[piece, i - 1] = board.pieceList[piece, i];
            }

            board.piecesNum[piece]--;

            return board;
        }
    }
}