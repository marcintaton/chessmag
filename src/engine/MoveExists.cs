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
                // check if move is valid and actually rework makemove so that it doesnt fail if move is invalid
                board = MoveCtrl.MakeMove(move, board).board;
                board = MoveCtrl.UnmakeMove(board);

                if (moveList.moves[i] == move)
                {
                    return true;
                }
            }
            return false;
        }
    }
}