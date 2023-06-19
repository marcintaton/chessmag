using chessmag.defs;

namespace chessmag.engine
{

    public static class TimeManagement
    {

        public static int GetNextMoveTime(Board board, TimeControl tCtrl)
        {
            // basic heuristics that allocates 1/30 of remaining time for the move
            // board can be later used for a more complex heuristic

            var time = (tCtrl.time / 30) - 50 + tCtrl.inc;

            // oponent's remaining time can also be compared to our time
            // to allocate more or less time for the move 

            return time;
        }
    }
}