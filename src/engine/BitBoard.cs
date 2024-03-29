using chessmag.defs;

namespace chessmag.engine
{
    public static class BitBoard
    {
        // BitBoard magic. Literally
        public static readonly int[] BitTable = {
            63, 30, 3, 32, 25, 41, 22, 33, 15, 50, 42, 13, 11, 53, 19, 34, 61, 29, 2,
            51, 21, 43, 45, 10, 18, 47, 1, 54, 9, 57, 0, 35, 62, 31, 40, 4, 49, 5, 52,
            26, 60, 6, 23, 44, 46, 27, 56, 16, 7, 39, 48, 24, 59, 14, 12, 55, 38, 28,
            58, 20, 37, 17, 36, 8
        };

        public static ulong SetBit(ulong bb, int sq120)
        {
            bb |= 1Ul << BBC.Board120to64[sq120];
            return bb;
        }

        public static ulong SetBit64(ulong bb, int sq64)
        {
            bb |= 1Ul << sq64;
            return bb;
        }

        public static ulong UnsetBit(ulong bb, int sq120)
        {
            bb &= ~(1Ul << BBC.Board120to64[sq120]);
            return bb;
        }

        public static ulong UnsetBit64(ulong bb, int sq64)
        {
            bb &= ~(1Ul << sq64);
            return bb;
        }

        public static Tuple<ulong, int> PopBit(ulong bb)
        {
            ulong b = bb ^ (bb - 1);
            uint fold = (uint)((b & 0xffffffff) ^ (b >> 32));
            bb &= (bb - 1);
            return Tuple.Create(bb, BitTable[(fold * 0x783a9b23) >> 26]);
        }

        public static int GetBitCount(ulong bb)
        {
            int ctr;
            for (ctr = 0; bb != 0; ctr++, bb &= bb - 1) ;
            return ctr;
        }
    }
}