using chessmag.engine;

namespace chessmag.defs
{
    public struct ABResult
    {
        public Board board;
        public SearchInfo sInfo;
        public int score;

        public ABResult(Board board, SearchInfo sInfo, int score) : this()
        {
            this.board = board;
            this.sInfo = sInfo;
            this.score = score;
        }
    }
}