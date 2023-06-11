using chessmag.defs;

namespace chessmag.engine
{
    public static partial class Search
    {
        public static void CheckUp()
        {
            // periodically test if time is up or search is interrupted
        }

        public static Board PrepForSearch(Board board)
        {
            board.searchHistory = new int[13, Constants.BoardSize];
            board.searchKillers = new int[2, Constants.MaxDepth];

            board.pvTable = new PVTable();

            board.ply = 0;

            //call searchinfo reset before this or init new
            return board;
        }

        public static ABResult AlphaBeta(int alpha, int beta, int depth, Board board, SearchInfo sInfo, bool doNULL)
        {
            // does AB modify board and info 
            return new ABResult(board, sInfo, 0);
        }

        public static int Quiescence(int alpha, int beta, Board board, SearchInfo sInfo)
        {
            return 0;
        }
    }
}