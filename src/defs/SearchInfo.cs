using chessmag.utils;

namespace chessmag.defs
{
    public struct SearchInfo
    {
        public long startTime;
        public long stopTime;
        public int depth;
        public int depthSet;
        public int timeSet;
        public int movesToGo;
        public int infinite;
        public long nodes;
        public int quit;
        public int stopped;

        public void Reset()
        {
            TimeUtils.stopwatch.Restart();
            startTime = TimeUtils.stopwatch.ElapsedMilliseconds;
            stopped = 0;
            nodes = 0;
        }
    }
}