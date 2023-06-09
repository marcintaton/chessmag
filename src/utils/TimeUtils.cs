using System.Diagnostics;
namespace chessmag.utils
{
    public static class TimeUtils
    {
        public static readonly Stopwatch stopwatch = new();

        public static double GetSwMs()
        {
            return (double)stopwatch.ElapsedTicks / 1000000;
        }
    }
}