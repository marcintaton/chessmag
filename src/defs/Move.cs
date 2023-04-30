using System.Diagnostics;
namespace chessmag.defs
{
    // move structure stored in an integer
    // 0000 0000 0000 0000 0000 0111 1111 - from 0x7F
    // 0000 0000 0000 0011 1111 1000 0000 - to >> 7, 0x7F
    // 0000 0000 0011 1100 0000 0000 0000 - piece captured >> 14, 0xF
    // 0000 0000 0100 0000 0000 0000 0000 - En passant 0x40000
    // 0000 0000 1000 0000 0000 0000 0000 - Pawn start 0x80000
    // 0000 1111 0000 0000 0000 0000 0000 - pawn promotion >> 20, 0xF
    // 0001 0000 0000 0000 0000 0000 0000 - castle 0x1000000

    public struct Move
    {
        private const int enPasFlag = 0x40000;
        private const int pawnStartFlag = 0x80000;
        private const int castleFlag = 0x1000000;
        private const int captureFlag = 0x7C000;
        private const int promotionFlag = 0xF00000;
        public int move;
        public int score;

        public Move(int move, int score)
        {
            this.move = move;
            this.score = score;
        }

        public Move(
            int from,
            int to,
            int pceCaptured,
            int promotion,
            bool enPas = false,
            bool pawnStar = false,
            bool castle = false,
            int score = 0)
        {
            move = from | (to << 7) | (pceCaptured << 14) | (promotion << 20);
            move |= enPas ? enPasFlag : 0x0;
            move |= pawnStar ? pawnStartFlag : 0x0;
            move |= castle ? castleFlag : 0x0;
            this.score = score;
        }

        public int GetFromSq() => move & 0x7F;
        public int GetToSq() => (move >> 7) & 0x7F;
        public int GetPceCaptured() => (move >> 14) & 0xF;
        public int GetPromotedPce() => (move >> 20) & 0xF;
        public bool IsEnPas() => (move & enPasFlag) != 0x0;
        public bool IsPawnStart() => (move & pawnStartFlag) != 0x0;
        public bool IsCastle() => (move & castleFlag) != 0x0;
        public bool IsCapture() => (move & captureFlag) != 0x0;
        public bool IsPromotion() => (move & promotionFlag) != 0x0;

        public override string ToString()
        {
            var prom = "";
            if (IsPromotion())
            {
                prom = "q";
                if (PieceData.isRook[GetPromotedPce()]) prom = "r";
                else if (PieceData.isBishop[GetPromotedPce()]) prom = "b";
                else if (PieceData.isKnight[GetPromotedPce()]) prom = "k";
            }
            return ((Square)GetFromSq()).ToString() + ((Square)GetToSq()).ToString() + prom;
        }
    }
}