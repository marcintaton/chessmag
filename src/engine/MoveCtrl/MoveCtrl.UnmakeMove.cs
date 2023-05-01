using chessmag.defs;
using chessmag.utils;

namespace chessmag.engine
{
    public static partial class MoveCtrl
    {
        public static Board UnmakeMove(Board board)
        {
            Assertions.CheckBoard(board);

            board.histPly--;
            board.ply--;

            Move move = board.moveHist[board.histPly].move;
            int from = move.FromSq;
            int to = move.ToSq;

            Assertions.SqOnBoard(from);
            Assertions.SqOnBoard(to);

            if (board.enPasSq != (int)Square.NONE) board.positionHash = HashEp(board);
            board.positionHash = HashCR(board);

            board.castlingRights = board.moveHist[board.histPly].castlingRights;
            board.fiftyMoveCtr = board.moveHist[board.histPly].fiftyMoveCtr;
            board.enPasSq = board.moveHist[board.histPly].enPasSq;

            if (board.enPasSq != (int)Square.NONE) board.positionHash = HashEp(board);
            board.positionHash = HashCR(board);

            board.sideToMove ^= 1;
            board.positionHash = HashSide(board);

            if (move.EnPassant)
            {
                if (board.sideToMove == (int)Color.WHITE) board = AddPiece(to - 10, (int)Piece.P, board);
                else board = AddPiece(to + 10, (int)Piece.p, board);
            }
            else if (move.Castle)
            {
                switch (to)
                {
                    case (int)Square.c1:
                        board = MovePiece((int)Square.d1, (int)Square.a1, board);
                        break;
                    case (int)Square.c8:
                        board = MovePiece((int)Square.d8, (int)Square.a8, board);
                        break;
                    case (int)Square.g1:
                        board = MovePiece((int)Square.f1, (int)Square.h1, board);
                        break;
                    case (int)Square.g8:
                        board = MovePiece((int)Square.f8, (int)Square.h8, board);
                        break;
                    default:
                        Assertions.Fail();
                        break;
                }
            }

            board = MovePiece(to, from, board);

            // already moved it back
            int piece = board.pieces[from];

            if (PieceData.isKing[piece]) board.kingSq[board.sideToMove] = from;

            if (move.Capture)
            {
                Assertions.PieceValid(move.PceCaptured);
                board = AddPiece(to, move.PceCaptured, board);
            }

            if (move.Promotion)
            {
                Assertions.PieceValid(move.PcePromoted);
                board = ClearPiece(from, board);
                board = AddPiece(
                    from,
                    PieceData.pieceColor[move.PcePromoted] == (int)Color.WHITE ? (int)Piece.P : (int)Piece.p,
                    board);
            }

            Assertions.CheckBoard(board);

            return board;
        }
    }
}