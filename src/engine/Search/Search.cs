using chessmag.defs;

namespace chessmag.engine
{
    public static class Search
    {
        public static void CheckUp()
        {
            // periodically test if time is up or search is interrupted
        }

        public static Board PrepForSearch(Board board, SearchInfo sInfo)
        {
            return board;
        }

        public static void Run(Board board, SearchInfo sInfo)
        {
            // perform search via itterative deepening
        }

        public static int AlphaBeta(int alpha, int beta, int depth, Board board, SearchInfo sInfo, int doNULL)
        {
            return 0;
        }

        public static int Quiescence(int alpha, int beta, Board board, SearchInfo sInfo)
        {
            return 0;
        }
    }
}