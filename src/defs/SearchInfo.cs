using chessmag.utils;

namespace chessmag.defs
{
    public struct SearchInfo
    {
        public long startTime;
        public long stopTime;
        public int depth;
        public int depthSet;
        public bool timeSet;
        public int movesToGo;
        public int infinite;
        public long nodes;
        public bool quit;
        public bool stopped;
        public float failHigh;
        public float failHighFirst;

        public void Reset()
        {
            TimeUtils.stopwatch.Restart();
            startTime = TimeUtils.stopwatch.ElapsedMilliseconds;
            stopped = false;
            nodes = 0;
            failHigh = 0;
            failHighFirst = 0;
        }
    }
}