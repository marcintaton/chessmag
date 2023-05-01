using chessmag.defs;
using chessmag.utils;

namespace chessmag.engine
{
    public static class MoveGenerator
    {
        public static MoveList GenerateAllMoves(Board board)
        {
            Assertions.CheckBoard(board);

            var moveList = new MoveList();

            if (board.sideToMove == (int)Color.WHITE)
            {
                for (int wp = 0; wp < board.piecesNum[(int)Piece.P]; wp++)
                {
                    int sq120 = board.pieceList[(int)Piece.P, wp];
                    Assertions.SqOnBoard(sq120);

                    if (board.pieces[sq120 + 10] == (int)Piece.NONE)
                    {
                        moveList.AddPawnMove(new Move(sq120, sq120 + 10), (int)Color.WHITE);
                        if (BoardBaseConversion.Sq120ToRank[sq120] == (int)Rank._2 && board.pieces[sq120 + 20] == (int)Piece.NONE)
                        {
                            moveList.AddQuietMove(new Move(sq120, sq120 + 20, (int)Piece.NONE, (int)Piece.NONE, false, true));
                        }
                    }

                    if (!BoardBaseConversion.IsOffboard(sq120 + 9) && PieceData.pieceColor[board.pieces[sq120 + 9]] == (int)Color.BLACK)
                    {
                        moveList.AddPawnMove(new Move(sq120, sq120 + 9, board.pieces[sq120 + 9]), (int)Color.WHITE);
                    }

                    if (!BoardBaseConversion.IsOffboard(sq120 + 11) && PieceData.pieceColor[board.pieces[sq120 + 11]] == (int)Color.BLACK)
                    {
                        moveList.AddPawnMove(new Move(sq120, sq120 + 11, board.pieces[sq120 + 11]), (int)Color.WHITE);
                    }

                    if (board.enPasSq != (int)Square.NONE)
                    {
                        if (!BoardBaseConversion.IsOffboard(sq120 + 9) && sq120 + 9 == board.enPasSq)
                        {
                            moveList.AddEnPassantMove(new Move(sq120, sq120 + 9, (int)Piece.NONE, (int)Piece.NONE, true));
                        }

                        if (!BoardBaseConversion.IsOffboard(sq120 + 11) && sq120 + 11 == board.enPasSq)
                        {
                            moveList.AddEnPassantMove(new Move(sq120, sq120 + 9, (int)Piece.NONE, (int)Piece.NONE, true));
                        }
                    }
                }
            }

            return moveList;
        }
    }
}