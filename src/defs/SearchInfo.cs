using chessmag.utils;

namespace chessmag.defs
{
    public struct SearchInfo
    {
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
        public Protocol protocol;

        public void Reset()
        {
            TimeUtils.stopwatch.Restart();
            stopped = false;
            nodes = 0;
            failHigh = 0;
            failHighFirst = 0;
        }
    }
}