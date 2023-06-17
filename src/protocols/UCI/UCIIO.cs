using chessmag.defs;
using chessmag.utils;

namespace chessmag.protocols.UCI
{

    public static partial class UCIIO
    {
        public static void PrintBestMove(Move move)
        {
            Console.Write($"bestmove {move}\n");
        }

        public static void PrintInfo(Move move, int depth, long nodes, PVLine pv)
        {
            Console.Write($"info score {move.ScoreStr} depth {depth} nodes {nodes} time {TimeUtils.GetSwMs()} pv {pv}\n");
        }
    }
}