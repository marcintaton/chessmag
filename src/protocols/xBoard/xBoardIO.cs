using chessmag.defs;
using chessmag.utils;

namespace chessmag.protocols.xBoard
{
    public static class XBoardIO
    {
        public static string? Read()
        {
            return Console.ReadLine();
        }

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

        public static void SetFeatures()
        {
            Console.Write("feature ping=1 setboard=1 colors=0 usermove=1 variants=crazyhouse\n");
            Console.Write("feature done=1\n");
        }

        public static void PingPong(string input)
        {
            Console.Write($"pong {input.Split(' ')[1]}\n");
        }

        public static int ParseNumber(string input, int index)
        {
            return int.Parse(input.Split(' ')[index]);
        }

        public static string ParseSetboardFen(string input)
        {
            return input[(input.IndexOf(' ') + 1)..];
        }

        public static string ParseMoveString(string input)
        {
            return input.Split(' ')[1];
        }

        public static void Info(Move bestMove, int depth, long nodes, PVLine pvLine)
        {
            Console.Write($"{depth} {bestMove.score} {TimeUtils.GetSwMs()} {nodes} pv {pvLine}\n");
        }

        public static void BestMove(Move move)
        {
            Console.Write($"move {move}\n");
        }
    }
}