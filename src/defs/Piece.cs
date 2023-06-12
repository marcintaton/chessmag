namespace chessmag.defs
{
    public enum Piece : int
    {
        //empty
        NONE,
        // white pieces
        P, R, N, B, Q, K,
        // black pieces
        p, r, n, b, q, k,
    }

    public static class PieceData
    {
        public static readonly bool[] isPieceBig = new bool[] { false, false, true, true, true, true, true, false, true, true, true, true, true };
        public static readonly bool[] isPieceMaj = new bool[] { false, false, true, false, false, true, true, false, true, false, false, true, true };
        public static readonly bool[] isPieceMin = new bool[] { false, false, false, true, true, false, false, false, false, true, true, false, false };
        public static readonly int[] pieceColor = new int[] { (int)Color.BOTH, (int)Color.WHITE, (int)Color.WHITE, (int)Color.WHITE, (int)Color.WHITE, (int)Color.WHITE, (int)Color.WHITE, (int)Color.BLACK, (int)Color.BLACK, (int)Color.BLACK, (int)Color.BLACK, (int)Color.BLACK, (int)Color.BLACK };
        public static readonly int[] pieceValue = new int[] { 0, 100, 500, 300, 300, 900, 10000, 100, 500, 300, 300, 900, 10000 };
        public static readonly int[] VictimWorth = new int[] { 0, 100, 400, 200, 300, 500, 600, 100, 400, 200, 300, 500, 600 };
        public static readonly bool[] isPawn = new bool[] { false, true, false, false, false, false, false, true, false, false, false, false, false };
        public static readonly bool[] isKnight = new bool[] { false, false, false, true, false, false, false, false, false, true, false, false, false };
        public static readonly bool[] isKing = new bool[] { false, false, false, false, false, false, true, false, false, false, false, false, true };
        public static readonly bool[] isRookQueen = new bool[] { false, false, true, false, false, true, false, false, true, false, false, true, false };
        public static readonly bool[] isBishopQueen = new bool[] { false, false, false, false, true, true, false, false, false, false, true, true, false };
        public static readonly bool[] isBishop = new bool[] { false, false, false, false, true, false, false, false, false, false, true, false, false };
        public static readonly bool[] isRook = new bool[] { false, false, true, false, false, false, false, false, true, false, false, false, false };
        public static readonly bool[] isQueen = new bool[] { false, false, false, false, false, true, false, false, false, false, false, true, false };
        public static readonly bool[] isSliding = new bool[] { false, false, true, false, true, true, false, false, true, false, true, true, false, };
        public static readonly int[] knightMovePattern = new int[] { -8, -19, -21, -12, 8, 19, 21, 12 };
        public static readonly int[] rookMovePattern = new int[] { -1, -10, 1, 10 };
        public static readonly int[] bishopMovePattern = new int[] { -9, -11, 9, 11 };
        public static readonly int[] kingMovePattern = new int[] { -1, -10, 1, 10, -9, -11, 9, 11 };
        public static readonly int[] queenMovePattern = new int[] { -1, -10, 1, 10, -9, -11, 9, 11 };

    }
}