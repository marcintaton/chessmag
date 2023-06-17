using chessmag.defs;

namespace chessmag.utils
{
    public static partial class IO
    {
        public static void PrintSearchInfo(Move bestMove, int depth, SearchInfo sInfo, PVLine pvLine)
        {
            Console.WriteLine("Found on depth: " + depth + " move: " + bestMove.ToString() + " Nodes: " + sInfo.nodes);
            Console.WriteLine("Principal Variation:");
            Console.WriteLine(pvLine);
            Console.WriteLine("Ordering: " + (sInfo.failHighFirst / sInfo.failHigh));
        }

        public static void PrintScore(Move move)
        {
            Console.WriteLine("---------");
            Console.WriteLine("Score is: " + move.ScoreStr);
        }
    }
}