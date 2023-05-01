using chessmag.engine;

namespace chessmag.defs
{
    public struct MakeMoveResult
    {
        public Board board;
        public bool inCheck;

        public MakeMoveResult(Board board, bool inCheck)
        {
            this.board = board;
            this.inCheck = inCheck;
        }
    }
}