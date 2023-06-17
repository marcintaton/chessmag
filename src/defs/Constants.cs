namespace chessmag.defs
{
    public struct Constants
    {
        public const int BoardSize = 120;
        public const int MaxPly = 2048;
        public const int MaxPosMoves = 256;
        public const int MaxDepth = 64;
        public const int Infinity = 1000000;
        public const int NodeCountCheckup = 2047;
        public const string StartingFEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        public const string LegendaryFEN = "r3k2r/p1ppqpb1/bn2pnp1/3PN3/1p2P3/2N2Q1p/PPPBBPPP/R3K2R w KQkq - 0 1";
        public const string MoveTestingFEN = "n1n5/PPPk4/8/8/8/8/4Kppp/5N1N w - - 0 1";
        public const string TestFEN1 = "4k3/8/8/3pp3/8/8/3PP3/4K3 w - - 0 1";
        public const string TestFEN2 = "2rr3k/pp3pp1/1nnqbN1p/3pN3/2pP4/2P3Q1/PPB4P/R4RK1 w - - 0 1";
        public const string TestFEN3 = "r1b1k2r/ppppnppp/2n2q2/2b5/3NP3/2P1B3/PP3PPP/RN1QKB1R w KQkq - 0 1";

        // perft testing
    }
}