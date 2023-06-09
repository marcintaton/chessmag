using System.Diagnostics;
namespace chessmag.defs
{
    // move structure stored in an integer
    // 0000 0000 0000 0000 0000 0111 1111 - from 0x7F
    // 0000 0000 0000 0011 1111 1000 0000 - to >> 7, 0x7F (or 0x3F80)
    // 0000 0000 0011 1100 0000 0000 0000 - piece captured >> 14, 0xF (or 0x3C000)
    // 0000 0000 0100 0000 0000 0000 0000 - En passant 0x40000
    // 0000 0000 1000 0000 0000 0000 0000 - Pawn start 0x80000
    // 0000 1111 0000 0000 0000 0000 0000 - pawn promotion >> 20, 0xF (or 0xF00000)
    // 0001 0000 0000 0000 0000 0000 0000 - castle 0x1000000

    public struct Move
    {
        private const int fromMask = 0x7F;
        private const int toMask = 0x3F80;
        private const int enPasMask = 0x40000;
        private const int pawnStartMask = 0x80000;
        private const int castleMask = 0x1000000;
        private const int captureMask = 0x7C000;
        private const int promotionMask = 0xF00000;
        public int move;
        public int score;

        public static Move NOMOVE { get { return new Move(0); } }

        public Move(int move)
        {
            this.move = move;
            this.score = 0;
        }

        public Move(
            int from,
            int to,
            int pceCaptured = (int)Piece.NONE,
            int promotion = (int)Piece.NONE,
            bool enPas = false,
            bool pawnStar = false,
            bool castle = false,
            int score = 0)
        {
            move = from | (to << 7) | (pceCaptured << 14) | (promotion << 20);
            move |= enPas ? enPasMask : 0x0;
            move |= pawnStar ? pawnStartMask : 0x0;
            move |= castle ? castleMask : 0x0;
            this.score = score;
        }

        public int FromSq { get => move & 0x7F; set => move = (move & ~fromMask) | value; }
        public int ToSq { get => (move >> 7) & 0x7F; set => move = (move & ~toMask) | (value << 7); }
        public int PceCaptured { get => (move >> 14) & 0xF; set => move = (move & ~captureMask) | (value << 14); }
        public int PcePromoted { get => (move >> 20) & 0xF; set => move = (move & ~promotionMask) | (value << 20); }
        public bool EnPassant { get => (move & enPasMask) != 0x0; set => move = (move & ~enPasMask) | (value ? enPasMask : 0x0); }
        public bool PawnStart { get => (move & pawnStartMask) != 0x0; set => move = (move & ~pawnStartMask) | (value ? pawnStartMask : 0x0); }
        public bool Castle { get => (move & castleMask) != 0x0; set => move = (move & ~castleMask) | (value ? castleMask : 0x0); }
        public bool Capture { get => (move & captureMask) != 0x0; }
        public bool Promotion { get => (move & promotionMask) != 0x0; }

        public override string ToString()
        {
            var prom = "";
            if (Promotion)
            {
                prom = "q";
                if (PieceData.isRook[PcePromoted]) prom = "r";
                else if (PieceData.isBishop[PcePromoted]) prom = "b";
                else if (PieceData.isKnight[PcePromoted]) prom = "n";
            }
            return ((Square)FromSq).ToString() + ((Square)ToSq).ToString() + prom;
        }

        public static bool operator ==(Move a, Move b)
        {
            return a.move == b.move;
        }

        public static bool operator !=(Move a, Move b)
        {
            return a.move != b.move;
        }
    }
}