namespace chessmag.src.utils
{
    public readonly struct RandomUlong
    {
        private static readonly Random rand;

        static RandomUlong()
        {
            rand = new Random();
        }

        public static ulong Next()
        {
            return (ulong)rand.NextInt64();
        }
    }
}