using chessmag.engine;

namespace chessmag.defs
{
    public struct BoardWInfo
    {
        public Board board;
        public SearchInfo sInfo;

        public BoardWInfo(Board board, SearchInfo sInfo) : this()
        {
            this.board = board;
            this.sInfo = sInfo;
        }
    }
}