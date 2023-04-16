using chessmag.src.defs;
using File = chessmag.src.defs.File;

namespace chessmag.src
{
    // Board Base Conversion
    public static class BoardBaseConversion
    {
        public static int[] Board64to120 { get; } = Enumerable.Repeat(120, 64).ToArray();

        public static int[] Board120to64 { get; } = Enumerable.Repeat(65, Constants.BoardSize).ToArray();

        public static int FrTo64(int file, int rank)
        {
            return file + (rank * 8);
        }

        public static int FrTo120(int file, int rank)
        {
            return 21 + file + (rank * 10);
        }

        static BoardBaseConversion()
        {
            for (int rank = (int)Rank._1; rank <= (int)Rank._8; ++rank)
            {
                for (int file = (int)File.a; file <= (int)File.h; ++file)
                {
                    int sq120 = FrTo120(file, rank);
                    int sq64 = FrTo64(file, rank);
                    Board64to120[sq64] = sq120;
                    Board120to64[sq120] = sq64;
                }
            }
        }
    }
}