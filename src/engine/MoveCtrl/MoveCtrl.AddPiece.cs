using chessmag.defs;
using chessmag.utils;

namespace chessmag.engine
{
    public static partial class MoveCtrl
    {
        public static Board AddPiece(int sq120, int piece, Board board)
        {
            Assertions.SqOnBoard(sq120);
            Assertions.PieceValid(piece);

            int color = PieceData.pieceColor[piece];

            board.positionHash = HashPce(board, sq120, piece);

            board.pieces[sq120] = piece;

            if (PieceData.isPieceBig[piece])
            {
                board.bigPceNum[color]++;
                if (PieceData.isPieceMaj[piece])
                {
                    board.majorPcsNum[color]++;
                }
                else
                {
                    board.minorPcsNum[color]++;
                }
            }
            else
            {
                // pawn
                board.pawns[color] = BitBoard.SetBit(board.pawns[color], sq120);
                board.pawns[(int)Color.BOTH] = BitBoard.SetBit(board.pawns[(int)Color.BOTH], sq120);
            }

            board.materials[color] += PieceData.pieceValue[piece];
            board.pieceList[piece, board.piecesNum[piece]] = sq120;
            board.piecesNum[piece]++;

            return board;
        }
    }
}