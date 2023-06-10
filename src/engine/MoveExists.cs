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
                var result = MoveCtrl.MakeMove(move, board);

                if (!result.wasLegal)
                {
                    continue;
                }
                board = MoveCtrl.UnmakeMove(board);

                if (moveList.moves[i].move == move.move)
                {
                    return true;
                }
            }
            return false;
        }
    }
}