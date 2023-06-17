using chessmag.defs;
using chessmag.protocols.UCI;
using chessmag.utils;

namespace chessmag.engine
{
    public static partial class Search
    {
        public static SearchInfo CheckUp(SearchInfo sInfo)
        {
            // periodically test if time is up or search is interrupted
            if (sInfo.timeSet && TimeUtils.GetSwMs() > sInfo.stopTime)
            {
                sInfo.stopped = true;
            }

            var interrupt = IO.PeekStdIn();

            return UCIIO.ParseInterrupt(interrupt, sInfo);
        }

        public static Board PrepForSearch(Board board)
        {
            board.searchHistory = new int[13, Constants.BoardSize];
            board.searchKillers = new Move[2, Constants.MaxDepth];

            board.pvTable = new PVTable();

            board.ply = 0;

            //call searchinfo reset before this or init new
            return board;
        }

        public static MoveList PickNextMove(int moveIndex, MoveList moveList)
        {
            Move temp;
            int bestScore = 0;
            int bestIndex = moveIndex;

            for (int i = moveIndex; i < moveList.count; i++)
            {
                if (moveList.moves[i].score > bestScore)
                {
                    bestScore = moveList.moves[i].score;
                    bestIndex = i;
                }
            }

            temp = moveList.moves[moveIndex];
            moveList.moves[moveIndex] = moveList.moves[bestIndex];
            moveList.moves[bestIndex] = temp;

            return moveList;
        }
    }
}