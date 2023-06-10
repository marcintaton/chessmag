using chessmag.engine;

namespace chessmag.defs
{
    public struct MakeMoveResult
    {
        public Board board;
        public bool wasLegal;

        public MakeMoveResult(Board board, bool wasLegal)
        {
            this.board = board;
            this.wasLegal = wasLegal;
        }
    }
}