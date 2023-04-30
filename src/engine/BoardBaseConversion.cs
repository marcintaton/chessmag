using chessmag.defs;
using File = chessmag.defs.File;

namespace chessmag.engine
{
    // Board Base Conversion
    public static class BoardBaseConversion
    {
        public static int[] Board64to120 { get; } = Enumerable.Repeat(120, 64).ToArray();

        public static int[] Board120to64 { get; } = Enumerable.Repeat(65, Constants.BoardSize).ToArray();

        public static int[] Sq120ToFile { get; } = Enumerable.Repeat(65, Constants.BoardSize).ToArray();
        public static int[] Sq120ToRank { get; } = Enumerable.Repeat(65, Constants.BoardSize).ToArray();

        public static int FrTo64(int file, int rank)
        {
            return file + (rank * 8);
        }

        // fr2sq
        public static int FrTo120(int file, int rank)
        {
            return 21 + file + (rank * 10);
        }

        public static bool IsOffboard(int sq120)
        {
            return Board120to64[sq120] == 65;
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
                    Sq120ToFile[sq120] = file;
                    Sq120ToRank[sq120] = rank;
                }
            }

            // for (int i = 0; i < 64; i++)
            // {
            //     Console.Write(Board64to120[i].ToString().PadRight(3));

            //     if (i % 8 == 7) Console.WriteLine();
            // }
        }
    }
}