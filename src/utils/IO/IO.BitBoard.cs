using chessmag.defs;
using chessmag.engine;
using File = chessmag.defs.File;

namespace chessmag.utils
{
    public static partial class IO
    {
        public static void PrintBitBoard(ulong board)
        {
            Console.WriteLine();

            for (int rank = (int)Rank._8; rank >= (int)Rank._1; --rank)
            {
                Console.Write(rank + 1 + "  ");

                for (int file = (int)File.a; file <= (int)File.h; ++file)
                {
                    int sq120 = BBC.FrTo120(file, rank);
                    int sq64 = BBC.Board120to64[sq120];
                    if (((1UL << sq64) & board) != 0)
                    {
                        Console.Write("@");
                    }
                    else
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("   abcdefgh");
            Console.WriteLine();
        }
    }
}