using chessmag.defs;
using chessmag.utils;

namespace chessmag.protocols.UserMode
{
    public static class UserModeIO
    {
        public static void Info(Move bestMove, int depth, long nodes, PVLine pvLine)
        {
            Console.Write($"{Constants.EngineName} > Depth - {depth}; Score - {bestMove.score}; Time - {TimeUtils.GetSwMs()}; Nodes - {nodes}; Pv - {pvLine};\n");
        }

        public static void BestMove(Move move)
        {
            Console.Write($"{Constants.EngineName} > executing move - {move};\n");
        }
    }
}