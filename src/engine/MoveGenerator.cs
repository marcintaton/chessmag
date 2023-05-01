using chessmag.defs;
using chessmag.utils;

namespace chessmag.engine
{
    public static class MoveGenerator
    {
        private static readonly int[,] SlidingPieces = { { (int)Piece.R, (int)Piece.B, (int)Piece.Q, }, { (int)Piece.r, (int)Piece.b, (int)Piece.q } };
        private static readonly int[,] NonSlidingPieces = { { (int)Piece.N, (int)Piece.K, }, { (int)Piece.n, (int)Piece.k, } };

        public static MoveList GenerateAllMoves(Board board)
        {
            Assertions.CheckBoard(board);

            var moveList = new MoveList();

            moveList = GeneratePawnMoves(board, moveList);
            moveList = GenerateSlidingMoves(board, moveList);
            moveList = GenerateNonSlidingMoves(board, moveList);

            return moveList;
        }

        private static MoveList GeneratePawnMoves(Board board, MoveList moveList)
        {
            int color = board.sideToMove;
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

        private static MoveList GenerateSlidingMoves(Board board, MoveList moveList)
        {
            int color = board.sideToMove;

            for (int i = 0; i < SlidingPieces.GetLength(1); i++)
            {
                int piece = SlidingPieces[color, i];
                Assertions.PieceValid(piece);
                Console.WriteLine((Piece)piece);
            }

            return moveList;
        }

        private static MoveList GenerateNonSlidingMoves(Board board, MoveList moveList)
        {
            int color = board.sideToMove;

            for (int i = 0; i < NonSlidingPieces.GetLength(1); i++)
            {
                int piece = NonSlidingPieces[color, i];
                Assertions.PieceValid(piece);
                Console.WriteLine((Piece)piece);
            }

            return moveList;
        }
    }
}