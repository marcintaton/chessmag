using chessmag.defs;
using chessmag.engine;
using chessmag.utils;

namespace chessmag.protocols.UCI
{
    public static class UCI
    {
        public static void MainLoop()
        {
            UCIIO.Name();
            UCIIO.Author();
            UCIIO.UCIOk();

            var board = new Board();
            var sInfo = new SearchInfo
            {
                depth = 6,
                timeSet = true,
                stopTime = 500
            };

            while (!sInfo.quit)
            {
                var input = Console.ReadLine();

                if (input == "\n" || input == null)
                {
                    continue;
                }
                else if (input.Contains("isready"))
                {
                    UCIIO.ReadyOk();
                    continue;
                }
                else if (input.Contains("position"))
                {
                    board = UCIIO.ParsePosition(input, board);
                    continue;
                }
                else if (input.Contains("ucinewgame"))
                {
                    board = UCIIO.ParsePosition("position startpos\n", board);
                    continue;
                }
                else if (input.Contains("go"))
                {
                    var tokenSource = new CancellationTokenSource();
                    IO.StartPeeking(tokenSource.Token);
                    var result = UCIIO.ParseGo(input, board, sInfo);
                    board = result.board;
                    sInfo = result.sInfo;
                    tokenSource.Cancel();
                    continue;
                }
                else if (input.Contains("quit"))
                {
                    sInfo.quit = true;
                    break;
                }
                else if (input.Contains("uci"))
                {
                    UCIIO.Name();
                    UCIIO.Author();
                    UCIIO.UCIOk();
                    continue;
                }
            }
        }
    }
}