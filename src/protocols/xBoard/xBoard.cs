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