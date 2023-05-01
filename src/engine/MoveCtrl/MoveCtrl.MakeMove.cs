using chessmag.defs;
using chessmag.utils;

namespace chessmag.engine
{
    public static partial class MoveCtrl
    {
        public static MakeMoveResult MakeMove(Board board, Move move)
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

            board.moveHist[board.ply].positionHash = board.positionHash;

            ///
            ///
            return new MakeMoveResult(board, false);
        }
    }
}