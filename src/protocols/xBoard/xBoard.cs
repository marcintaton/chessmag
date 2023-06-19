using chessmag.defs;
using chessmag.engine;

namespace chessmag.protocols.xBoard
{
    public static partial class XBoard
    {
        public static void Loop()
        {
            var board = new Board();
            var sInfo = new SearchInfo
            {
                depth = 6,
                timeSet = true,
                stopTime = 500,
                protocol = Protocol.XBOARD
            };

            int depth = -1;
            int movesToGo = 30;
            int movetime = -1;
            int time = -1;
            int increment = 0;
            int engineSide = (int)Color.BOTH;
            int timeLeft;
            int movesPerSecond;
            Move move = Move.NONE;

            while (!sInfo.quit)
            {
                var input = Console.ReadLine();

                if (input == "\n" || input == null)
                {
                    continue;
                }

                if (input.Contains("quit"))
                {
                    sInfo.quit = true;
                    break;
                }
            }
        }
    }
}