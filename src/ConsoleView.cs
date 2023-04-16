using chessmag.src.defs;
using File = chessmag.src.defs.File;

namespace chessmag.src
{
    public struct ConsoleView
    {
        public static void PrintBitBoard(ulong board)
        {
            Console.WriteLine();

            for (int rank = (int)Rank._8; rank >= (int)Rank._1; --rank)
            {
                for (int file = (int)File.a; file <= (int)File.h; ++file)
                {
                    int sq120 = BoardBaseConversion.FrTo120(file, rank);
                    int sq64 = BoardBaseConversion.Board120to64[sq120];
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
        }
    }
}