using chessmag.defs;

namespace chessmag.engine
{
    public static class MoveExists
    {
        public static bool Check(Board board, Move move)
        {
            var moveList = MoveGenerator.GenerateAllMoves(board);

            for (int i = 0; i < moveList.moves.Length; i++)
            {
                if (moveList.moves[i].move == move.move)
                {
                    var result = MoveCtrl.MakeMove(move, board);

                    board = result.board;
                    board = MoveCtrl.UnmakeMove(board);

                    if (result.wasLegal)
                        return true;
                }
            }
            return false;
        }
    }
}