using chessmag.defs;
using chessmag.utils;

namespace chessmag.engine
{
    public static partial class MoveCtrl
    {
        public static MakeMoveResult MakeMove(Move move, Board board)
        {
            Assertions.CheckBoard(board);

            int from = move.FromSq;
            int to = move.ToSq;
            int side = board.sideToMove;
            int piece = board.pieces[from];

            Assertions.SqOnBoard(from);
            Assertions.SqOnBoard(to);
            Assertions.SideValid(side);
            Assertions.PieceValid(piece);

            board.moveHist[board.histPly].positionHash = board.positionHash;

            if (move.EnPassant)
            {
                if (side == (int)Color.WHITE) ClearPiece(to - 10, board);
                else ClearPiece(to + 10, board);
            }
            else if (move.Castle)
            {
                switch (to)
                {
                    case (int)Square.c1:
                        MovePiece((int)Square.a1, (int)Square.d1, board);
                        break;
                    case (int)Square.c8:
                        MovePiece((int)Square.a8, (int)Square.d8, board);
                        break;
                    case (int)Square.g1:
                        MovePiece((int)Square.h1, (int)Square.f1, board);
                        break;
                    case (int)Square.g8:
                        MovePiece((int)Square.h8, (int)Square.f8, board);
                        break;
                    default:
                        Assertions.Fail();
                        break;
                }
            }

            if (board.enPasSq != (int)Square.NONE) board.positionHash = hashEp(board);
            board.positionHash = hashCR(board);

            board.moveHist[board.histPly].move = move.move;
            board.moveHist[board.histPly].fiftyMoveCtr = board.fiftyMoveCtr;
            board.moveHist[board.histPly].enPasSq = board.enPasSq;
            board.moveHist[board.histPly].castlingRights = board.castlingRights;

            board.castlingRights &= castlePerms[from];
            board.castlingRights &= castlePerms[to];
            board.enPasSq = (int)Square.NONE;

            board.positionHash = hashCR(board);

            board.fiftyMoveCtr++;

            if (move.Capture)
            {
                Assertions.PieceValid(move.PceCaptured);
                ClearPiece(to, board);
                board.fiftyMoveCtr = 0;
            }

            board.ply++;
            board.histPly++;

            if (PieceData.isPawn[piece])
            {
                board.fiftyMoveCtr = 0;
                if (move.PawnStart)
                {
                    if (side == (int)Color.WHITE) board.enPasSq = from + 10;
                    else board.enPasSq = from - 10;

                    Assertions.EnPasSquareValid(board.enPasSq, side);

                    board.positionHash = hashEp(board);
                }
            }

            MovePiece(from, to, board);

            if (move.Promotion)
            {
                int promPce = move.PcePromoted;
                Assertions.PieceValid(promPce);
                ClearPiece(to, board);
                AddPiece(to, promPce, board);
            }

            if (PieceData.isKing[piece])
            {
                board.kingSq[side] = to;
            }

            board.sideToMove ^= 1;
            board.positionHash = hashSide(board);

            Assertions.CheckBoard(board);

            bool inCheck = false;
            if (Attack.IsSquareAttacked(board.kingSq[side], board.sideToMove, board))
            {
                board = UnmakeMove(board);
                inCheck = true;
            }

            ///
            return new MakeMoveResult(board, inCheck);
        }
    }
}