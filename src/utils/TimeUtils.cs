using System.Diagnostics;
namespace chessmag.utils
{
    public static class TimeUtils
    {
        public static readonly Stopwatch stopwatch = new();

        public static Int128 GetSwMs()
        {
            return (Int128)stopwatch.ElapsedTicks / 1000000;
        }
    }
}