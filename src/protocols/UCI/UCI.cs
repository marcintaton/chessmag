using chessmag.defs;
using chessmag.engine;
using chessmag.utils;

namespace chessmag.protocols.UCI
{
    public static class UCI
    {
        public static void Loop()
        {
            UCIIO.Name();
            UCIIO.Author();
            UCIIO.UCIOk();

            var board = new Board();
            var sInfo = new SearchInfo
            {
                depth = 6,
                timeSet = true,
                stopTime = 500,
                protocol = Protocol.UCI
            };

            while (!sInfo.quit)
            {
                var input = UCIIO.Read();

                if (input == "\n" || input == null)
                {
                    continue;
                }

                if (input.Contains("isready"))
                {
                    UCIIO.ReadyOk();
                    continue;
                }

                if (input.Contains("position"))
                {
                    board = UCIIO.ParsePosition(input, board);
                    continue;
                }

                if (input.Contains("ucinewgame"))
                {
                    board = UCIIO.ParsePosition("position startpos\n", board);
                    continue;
                }

                if (input.Contains("go"))
                {
                    var result = UCIIO.ParseGo(input, board, sInfo);
                    board = result.board;
                    sInfo = result.sInfo;
                    continue;
                }

                if (input.Contains("quit"))
                {
                    sInfo.quit = true;
                    break;
                }

                if (input.Contains("uci"))
                {
                    UCIIO.Name();
                    UCIIO.Author();
                    UCIIO.UCIOk();
                    // continue;
                }
            }
        }
    }
}