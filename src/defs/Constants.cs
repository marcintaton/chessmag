namespace chessmag.defs
{
    public struct Constants
    {
        public const int BoardSize = 120;
        public const int MaxPly = 2048;
        public const int MaxPosMoves = 256;
        public const string StartingFEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        public const string TestFEN1 = "rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1";
        public const string TestFEN2 = "rnbqkbnr/pp1ppppp/8/2p5/4P3/8/PPPP1PPP/RNBQKBNR w KQkq c6 0 2";
        public const string TestFEN3 = "r3k2r/p1ppqpb1/bn2pnp1/3PN3/1p2P3/2N2Q1p/PPPBBPPP/R3K2R w KQkq - 0 1";
        public const string TestFEN4 = "rnbqkbnr/ppp1pppp/8/3p4/4P3/8/PPPP1PPP/RNBQKBNR w KQkq d6 0 2";
        public const string TestFEN5 = "rnbqkb1r/pppppppp/5n2/8/4P3/8/PPPP1PPP/RNBQKBNR w KQkq - 1 2";
        public const string TestFEN6 = "1n1qkbnr/1pp1pppp/5r2/p2P1b2/8/PP1Q4/2PP1PPP/RNB1KBNR b KQk - 2 6";
        public const string TestFEN7 = "r3k2r/p1ppqpb1/bn2pnp1/3PN3/1p2P3/2N2Q1p/PPPBBPPP/R3K2R w KQkq - 0 1";
        public const string TestFEN8 = "4k3/8/8/8/1q6/8/3B4/4K3 w KQkq - 0 1";
        public const string WhitePawnsFEN = "rnbqkb1r/pp1p1pPp/8/2p1pP2/1P1P4/3P3P/P1P1P3/RNBQKBNR w KQkq e6 0 1";
        public const string BlackPawnsFEN = "rnbqkbnr/p1p1p3/3p3p/1p1p4/2P1Pp2/8/PP1P1PpP/RNBQKB1R b KQkq e3 0 1";
        public const string kingsKnightsFEN = "5k2/1n6/4n3/6N1/8/3N4/8/5K2 w - - 0 1";
        public const string rooksFEN = "6k1/8/5r2/8/1nR5/5N2/8/6K1 w - - 0 1";
        public const string queensFEN = "6k1/8/4nq2/8/1nQ5/5N2/1N6/6K1 b - - 0 1";
        public const string bishopsFEN = "6k1/1b6/4n3/8/1n4B1/1B3N2/1N6/2b3K1 b - - 0 1";
        public const string castlingFEN1 = "r3k2r/8/8/8/8/8/8/R3K2R b KQkq - 0 1";
        public const string castlingFEN2 = "3rk2r/8/8/8/8/8/6p1/R3K2R b KQkq - 0 1";
        public const string castlingFEN3 = "3rk2r/p7/6N1/8/8/6n1/8/R3K2R b KQkq - 0 1";

    }
}