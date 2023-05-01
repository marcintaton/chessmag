using chessmag.defs;
using chessmag.utils;

namespace chessmag.engine
{
    public static partial class MoveCtrl
    {
        public static Board MovePiece(Board board, int from120, int to120)
        {
            Assertions.SqOnBoard(from120);
            Assertions.SqOnBoard(to120);

            int piece = board.pieces[from120];
            int color = PieceData.pieceColor[piece];

            board.positionHash = hashPce(board, from120, piece);
            board.pieces[from120] = (int)Piece.NONE;

            board.positionHash = hashPce(board, to120, piece);
            board.pieces[from120] = piece;

            // pawn
            if (!PieceData.isPieceBig[piece])
            {
                board.pawns[color] = BitBoard.UnsetBit(board.pawns[color], from120);
                board.pawns[(int)Color.BOTH] = BitBoard.UnsetBit(board.pawns[(int)Color.BOTH], from120);

                board.pawns[color] = BitBoard.SetBit(board.pawns[color], to120);
                board.pawns[(int)Color.BOTH] = BitBoard.SetBit(board.pawns[(int)Color.BOTH], to120);
            }

            for (int i = 0; i < board.pieceList.GetLength(1); i++)
            {
                if (board.pieceList[piece, i] == from120)
                {
                    board.pieceList[piece, i] = to120;
                    break;
                }
            }

            return board;
        }
    }
}