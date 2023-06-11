using chessmag.defs;

namespace chessmag.utils
{
    public static partial class IO
    {
        public static void PrintSearchInfo(Move bestMove, int depth, SearchInfo sInfo, PVLine pvLine)
        {
            Console.WriteLine("Found on depth: " + depth + " move: " + bestMove.ToString() + " Nodes: " + sInfo.nodes);
            Console.WriteLine("Principal Variation:");
            for (int i = 0; i < pvLine.count; i++)
            {
                Console.WriteLine(i + 1 + ": " + pvLine.line[i].ToString());
            }
            Console.WriteLine("Ordering: " + (sInfo.failHighFirst / sInfo.failHigh));
        }

        public static void PrintScore(int bestScore)
        {
            string score = bestScore > Constants.Infinity - Constants.MaxDepth ? "Mate in " + (Constants.Infinity - bestScore) : bestScore.ToString();
            Console.WriteLine("---------");
            Console.WriteLine("Score is: " + score);
        }
    }
}