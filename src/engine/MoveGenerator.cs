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
            moveList = GenerateCastlingMoves(board, moveList);

            return moveList;
        }

        private static MoveList GeneratePawnMoves(Board board, MoveList moveList)
        {
            int color = board.sideToMove;
            int oppositeColor = color ^ 1;
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
                        moveList.AddEnPassantMove(new Move(sq120, sq120 + (9 * directionMod), (int)Piece.NONE, (int)Piece.NONE, true));
                    }
                    else if (!BoardBaseConversion.IsOffboard(sq120 + (11 * directionMod)) && sq120 + (11 * directionMod) == board.enPasSq)
                    {
                        moveList.AddEnPassantMove(new Move(sq120, sq120 + (11 * directionMod), (int)Piece.NONE, (int)Piece.NONE, true));
                    }
                }
            }

            return moveList;
        }

        private static MoveList GenerateSlidingMoves(Board board, MoveList moveList)
        {
            int color = board.sideToMove;
            int oppositeColor = color ^ 1;

            for (int sp = 0; sp < SlidingPieces.GetLength(1); sp++)
            {
                int pieceType = SlidingPieces[color, sp];
                Assertions.PieceValid(pieceType);

                for (int pieceIndex = 0; pieceIndex < board.piecesNum[pieceType]; pieceIndex++)
                {
                    int[] movePattern = new int[1];
                    switch (pieceType)
                    {
                        case (int)Piece.Q:
                        case (int)Piece.q:
                            movePattern = PieceData.queenMovePattern;
                            break;
                        case (int)Piece.B:
                        case (int)Piece.b:
                            movePattern = PieceData.bishopMovePattern;
                            break;
                        case (int)Piece.R:
                        case (int)Piece.r:
                            movePattern = PieceData.rookMovePattern;
                            break;
                    }

                    int sq120 = board.pieceList[pieceType, pieceIndex];
                    Assertions.SqOnBoard(sq120);

                    for (int moveSq = 0; moveSq < movePattern.Length; moveSq++)
                    {
                        int direction = movePattern[moveSq];
                        int t_sq120 = sq120 + direction;

                        while (!BoardBaseConversion.IsOffboard(t_sq120))
                        {
                            int t_piece = board.pieces[t_sq120];
                            if (t_piece != (int)Piece.NONE)
                            {
                                if (PieceData.pieceColor[t_piece] == oppositeColor)
                                {
                                    // capture
                                    moveList.AddCaptureMove(new Move(sq120, t_sq120, t_piece));
                                }
                                break;
                            }

                            // normal move
                            moveList.AddQuietMove(new Move(sq120, t_sq120));
                            t_sq120 += direction;
                        }
                    }
                }
            }
            return moveList;
        }

        private static MoveList GenerateNonSlidingMoves(Board board, MoveList moveList)
        {
            int color = board.sideToMove;
            int oppositeColor = color ^ 1;

            for (int nsp = 0; nsp < NonSlidingPieces.GetLength(1); nsp++)
            {
                int pieceType = NonSlidingPieces[color, nsp];
                Assertions.PieceValid(pieceType);

                for (int pieceIndex = 0; pieceIndex < board.piecesNum[pieceType]; pieceIndex++)
                {
                    int[] movePattern = (pieceType == (int)Piece.K || pieceType == (int)Piece.k) ? PieceData.kingMovePattern : PieceData.knightMovePattern;
                    int sq120 = board.pieceList[pieceType, pieceIndex];
                    Assertions.SqOnBoard(sq120);

                    for (int moveSq = 0; moveSq < movePattern.Length; moveSq++)
                    {
                        int direction = movePattern[moveSq];
                        int t_sq120 = sq120 + direction;
                        int t_piece = board.pieces[t_sq120];

                        if (BoardBaseConversion.IsOffboard(t_sq120)) continue;

                        if (t_piece != (int)Piece.NONE)
                        {
                            if (PieceData.pieceColor[t_piece] == oppositeColor)
                            {
                                // capture
                                moveList.AddCaptureMove(new Move(sq120, t_sq120, t_piece));
                            }
                            continue;
                        }

                        // normal move
                        moveList.AddQuietMove(new Move(sq120, t_sq120));
                    }
                }
            }
            return moveList;
        }

        private static MoveList GenerateCastlingMoves(Board board, MoveList moveList)
        {
            if (board.sideToMove == (int)Color.WHITE)
            {
                if ((board.castlingRights & (int)CastlingRights.K) != 0
                    && board.pieces[(int)Square.f1] == (int)Piece.NONE
                    && board.pieces[(int)Square.g1] == (int)Piece.NONE
                    && !Attack.IsSquareAttacked((int)Square.e1, (int)Color.BLACK, board)
                    && !Attack.IsSquareAttacked((int)Square.f1, (int)Color.BLACK, board)
                    && !Attack.IsSquareAttacked((int)Square.g1, (int)Color.BLACK, board))
                {
                    // gen castling move K
                    moveList.AddQuietMove(new Move((int)Square.e1, (int)Square.g1, (int)Piece.NONE, (int)Piece.NONE, false, false, true));
                }
                if ((board.castlingRights & (int)CastlingRights.Q) != 0
                    && board.pieces[(int)Square.d1] == (int)Piece.NONE
                    && board.pieces[(int)Square.c1] == (int)Piece.NONE
                    && board.pieces[(int)Square.b1] == (int)Piece.NONE
                    && !Attack.IsSquareAttacked((int)Square.e1, (int)Color.BLACK, board)
                    && !Attack.IsSquareAttacked((int)Square.d1, (int)Color.BLACK, board)
                    && !Attack.IsSquareAttacked((int)Square.c1, (int)Color.BLACK, board))
                {
                    // gen castling move Q
                    moveList.AddQuietMove(new Move((int)Square.e1, (int)Square.c1, (int)Piece.NONE, (int)Piece.NONE, false, false, true));
                }
            }
            else
            {
                if ((board.castlingRights & (int)CastlingRights.k) != 0
                    && board.pieces[(int)Square.f8] == (int)Piece.NONE
                    && board.pieces[(int)Square.g8] == (int)Piece.NONE
                    && !Attack.IsSquareAttacked((int)Square.e8, (int)Color.WHITE, board)
                    && !Attack.IsSquareAttacked((int)Square.f8, (int)Color.WHITE, board)
                    && !Attack.IsSquareAttacked((int)Square.g8, (int)Color.WHITE, board))
                {
                    // gen castling move k
                    moveList.AddQuietMove(new Move((int)Square.e8, (int)Square.g8, (int)Piece.NONE, (int)Piece.NONE, false, false, true));
                }
                if ((board.castlingRights & (int)CastlingRights.q) != 0
                    && board.pieces[(int)Square.d8] == (int)Piece.NONE
                    && board.pieces[(int)Square.c8] == (int)Piece.NONE
                    && board.pieces[(int)Square.b8] == (int)Piece.NONE
                    && !Attack.IsSquareAttacked((int)Square.e8, (int)Color.WHITE, board)
                    && !Attack.IsSquareAttacked((int)Square.d8, (int)Color.WHITE, board)
                    && !Attack.IsSquareAttacked((int)Square.c8, (int)Color.WHITE, board))
                {
                    // gen castling move q
                    moveList.AddQuietMove(new Move((int)Square.e8, (int)Square.c8, (int)Piece.NONE, (int)Piece.NONE, false, false, true));
                }
            }
            return moveList;
        }
    }
}