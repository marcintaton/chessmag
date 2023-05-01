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

            moveList = GeneratePawnMoves(board, moveList, board.sideToMove);

            return moveList;
        }

        private static MoveList GeneratePawnMoves(Board board, MoveList moveList, int color)
        {
            int oppositeColor = color == (int)Color.WHITE ? (int)Color.BLACK : (int)Color.WHITE;
            int directionMod = color == (int)Color.WHITE ? 1 : -1;
            int pawnCode = color == (int)Color.WHITE ? (int)Piece.P : (int)Piece.p;
            int pawnStartRank = color == (int)Color.WHITE ? (int)Rank._2 : (int)Rank._7;

            // gen forward, double forward moves (with promotions)
            for (int pawn = 0; pawn < board.piecesNum[pawnCode]; pawn++)
            {
                int sq120 = board.pieceList[pawnCode, pawn];
                Assertions.SqOnBoard(sq120);

                if (board.pieces[sq120 + (10 * directionMod)] == (int)Piece.NONE)
                {
                    moveList.AddPawnMove(new Move(sq120, sq120 + (10 * directionMod)), color);
                    if (BoardBaseConversion.Sq120ToRank[sq120] == pawnStartRank && board.pieces[sq120 + (20 * directionMod)] == (int)Piece.NONE)
                    {
                        moveList.AddQuietMove(new Move(sq120, sq120 + (20 * directionMod), (int)Piece.NONE, (int)Piece.NONE, false, true));
                    }
                }

                // gen captures (with promotions)
                if (!BoardBaseConversion.IsOffboard(sq120 + (9 * directionMod)) && PieceData.pieceColor[board.pieces[sq120 + (9 * directionMod)]] == oppositeColor)
                {
                    moveList.AddPawnMove(new Move(sq120, sq120 + (9 * directionMod), board.pieces[sq120 + (9 * directionMod)]), color);
                }

                if (!BoardBaseConversion.IsOffboard(sq120 + (11 * directionMod)) && PieceData.pieceColor[board.pieces[sq120 + (11 * directionMod)]] == oppositeColor)
                {
                    moveList.AddPawnMove(new Move(sq120, sq120 + (11 * directionMod), board.pieces[sq120 + (11 * directionMod)]), color);
                }

                // generate en passant
                if (board.enPasSq != (int)Square.NONE)
                {
                    if (!BoardBaseConversion.IsOffboard(sq120 + (9 * directionMod)) && sq120 + (9 * directionMod) == board.enPasSq)
                    {
                        moveList.AddEnPassantMove(new Move(sq120, sq120 + (9 * directionMod), board.pieces[sq120 + (-1 * directionMod)], (int)Piece.NONE, true));
                    }
                    else if (!BoardBaseConversion.IsOffboard(sq120 + (11 * directionMod)) && sq120 + (11 * directionMod) == board.enPasSq)
                    {
                        moveList.AddEnPassantMove(new Move(sq120, sq120 + (11 * directionMod), board.pieces[sq120 + (1 * directionMod)], (int)Piece.NONE, true));
                    }
                }
            }

            return moveList;
        }
    }
}