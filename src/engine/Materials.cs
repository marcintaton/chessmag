using System.Diagnostics;
using chessmag.defs;

namespace chessmag.engine
{
    public static class Materials
    {
        public static Board UpdateMaterials(Board board)
        {
            for (int i = 0; i < Constants.BoardSize; i++)
            {
                int square = i;
                int piece = board.pieces[square];
                if (piece != (int)Piece.NONE && piece != (int)Square.NONE)
                {
                    int color = PieceData.pieceColor[piece];
                    if (PieceData.isPieceBig[piece]) board.bigPceNum[color]++;
                    if (PieceData.isPieceMaj[piece]) board.majorPcsNum[color]++;
                    if (PieceData.isPieceMin[piece]) board.minorPcsNum[color]++;

                    board.materials[color] += PieceData.pieceValue[piece];

                    // piece list
                    board.pieceList[piece, board.piecesNum[piece]] = square;
                    board.piecesNum[piece]++;

                    if (piece == (int)Piece.K) board.kingSq[(int)Color.WHITE] = square;
                    else if (piece == (int)Piece.k) board.kingSq[(int)Color.BLACK] = square;

                    if (piece == (int)Piece.P)
                    {
                        board.pawns[(int)Color.WHITE] = BitBoard.SetBit(board.pawns[(int)Color.WHITE], square);
                        board.pawns[(int)Color.BOTH] = BitBoard.SetBit(board.pawns[(int)Color.BOTH], square);
                    }
                    if (piece == (int)Piece.p)
                    {
                        board.pawns[(int)Color.BLACK] = BitBoard.SetBit(board.pawns[(int)Color.BLACK], square);
                        board.pawns[(int)Color.BOTH] = BitBoard.SetBit(board.pawns[(int)Color.BOTH], square);
                    }
                }
            }

            return board;
        }
    }
}