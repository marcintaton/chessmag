using chessmag.defs;
using chessmag.engine;
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

        public static void Name()
        {
            Console.Write("id name Chessmag\n");
        }

        public static void Author()
        {
            Console.Write("id author Marcin Tatoń\n");
        }

        public static void UCIOk()
        {
            Console.Write("uciok\n");
        }

        public static BoardWInfo ParseGo(string command, Board board, SearchInfo sInfo)
        {
            return new BoardWInfo(board, sInfo);
        }

        public static Board ParsePosition(string command, Board board)
        {

            ///
            return board;
        }

        internal static void ReadyOk()
        {
            Console.Write("readyok\n");
        }
    }
}