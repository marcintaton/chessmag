using chessmag.defs;
using chessmag.utils;

namespace chessmag.protocols.UCI
{

    public static class UCIIO
    {
        public static void BestMove(Move move)
        {
            Console.Write($"bestmove {move}\n");
        }

        public static void Info(Move move, int depth, long nodes, PVLine pv)
        {
            Console.Write($"info score {move.ScoreStr} depth {depth} nodes {nodes} time {TimeUtils.GetSwMs()} pv {pv}\n");
        }
    }
}