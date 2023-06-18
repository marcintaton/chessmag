using chessmag.defs;
using chessmag.engine;
using chessmag.utils;

namespace chessmag.protocols.UCI
{

    public static partial class UCIIO
    {
        public static void BestMove(Move move)
        {
            Console.Write($"bestmove {move}\n");
        }

        public static void Info(Move move, int depth, long nodes, PVLine pv)
        {
            Console.Write($"info score {move.ScoreStr} depth {depth} nodes {nodes} time {TimeUtils.GetSwMs()} pv {pv}\n");
        }

        public static void Name()
        {
            Console.Write($"id name {Constants.EngineName}\n");
        }

        public static void Author()
        {
            Console.Write($"id author {Constants.EngineAuthor}\n");
        }

        public static void UCIOk()
        {
            Console.Write("uciok\n");
        }

        internal static void ReadyOk()
        {
            Console.Write("readyok\n");
        }
    }
}