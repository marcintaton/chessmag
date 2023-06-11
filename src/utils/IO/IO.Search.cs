using chessmag.defs;

namespace chessmag.utils
{

    public static partial class IO
    {

        public static void PrintSearchInfo(Move bestMove, int depth, SearchInfo sInfo, PVLine pvLine)
        {
            Console.WriteLine("Found on depth: " + depth + " Score: " + bestMove.score + " move: " + bestMove.ToString() + " Nodes: " + sInfo.nodes);
            Console.WriteLine("Principal Variation:");
            for (int i = 0; i < pvLine.line.Length; i++)
            {
                Console.WriteLine(i + ": " + pvLine.line[i].ToString());
            }
        }
    }
}