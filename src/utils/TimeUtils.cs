using System.Diagnostics;
namespace chessmag.utils
{
    public static class TimeUtils
    {
        public static readonly Stopwatch stopwatch = new();

        public static int GetSwMs()
        {
            return (int)stopwatch.ElapsedTicks / 1000000;
        }
    }
}