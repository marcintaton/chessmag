using chessmag.src.defs;

namespace chessmag.src
{
    public static class BitBoard
    {
        public static ulong PushPiece(ulong bitBoard, Square sq)
        {
            bitBoard |= 1Ul << BoardBaseConversion.Board120to64[(int)sq];
            return bitBoard;
        }

    }
}