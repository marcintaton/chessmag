using chessmag.defs;

namespace chessmag.protocols.xBoard
{
    public static class XBoardIO
    {
        public static void Claim50RuleDraw()
        {
            Console.Write($"1/2-1/2 {{fity move rule (claimed by {Constants.EngineName})}}\n");
        }

        public static void Claim3FoldRepDraw()
        {
            Console.Write($"1/2-1/2 {{3-fold repetition (claimed by {Constants.EngineName})}}\n");
        }

        public static void ClaimMaterialDraw()
        {
            Console.Write($"1/2-1/2 {{insufficient material (claimed by {Constants.EngineName})}}\n");
        }

        public static void ClaimMate(int color)
        {
            string colorStr = color == (int)Color.WHITE ? "white" : "black";
            Console.Write($"0-1 {{{colorStr} mates (claimed by {Constants.EngineName})}}\n");
        }

        public static void ClaimStalemate()
        {
            Console.Write($"1/2-1/2 {{stalemate (claimed by {Constants.EngineName})}}\n");
        }
    }
}