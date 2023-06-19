using System.Reflection;
using chessmag.defs;
using chessmag.engine;
using chessmag.utils;

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
            int moveTime = -1;
            int time = -1;
            int increment = 0;
            int engineSide = (int)Color.BOTH;
            int timeLeft;
            int movesPerSession;
            Move move = Move.NONE;

            while (!sInfo.quit)
            {

                if (board.sideToMove == engineSide)
                {
                    // search, evaluate etc.
                }

                var input = XBoardIO.Read();


                if (input == "\n" || input == null)
                {
                    continue;
                }

                if (input.StartsWith("quit"))
                {
                    sInfo.quit = true;
                    break;
                }

                if (input.StartsWith("force"))
                {
                    // force mode - never actually play / think
                    engineSide = (int)Color.BOTH;
                    continue;
                }

                if (input.StartsWith("protover"))
                {
                    XBoardIO.SetFeatures();
                    continue;
                }

                if (input.StartsWith("sd "))
                {
                    depth = XBoardIO.ParseNumber(input, 1);
                    continue;
                }

                if (input.StartsWith("st "))
                {
                    moveTime = XBoardIO.ParseNumber(input, 1);
                    continue;
                }

                if (input.StartsWith("ping "))
                {
                    XBoardIO.PingPong(input);
                    continue;
                }

                if (input.StartsWith("new"))
                {
                    engineSide = (int)Color.BLACK;
                    board = Fen.Parse(Constants.StartingFEN);
                    depth = -1;
                    continue;
                }

                if (input.StartsWith("setboard "))
                {
                    engineSide = (int)Color.BOTH;
                    board = Fen.Parse(XBoardIO.ParseSetboardFen(input));
                    continue;
                }

                if (input.StartsWith("go"))
                {
                    engineSide = board.sideToMove;
                    continue;
                }

                if (input.StartsWith("variant "))
                {
                    // set variant - do we actually need this?
                    continue;
                }

                if (input.StartsWith("usermove "))
                {
                    move = IO.ParseClassicalMove(XBoardIO.ParseMoveString(input), board);
                    if (move.move == Move.NOMOVE) continue;
                    board = MoveCtrl.MakeMove(move, board).board;
                    board.ply = 0;
                    continue;
                }

                // other protocol commands
            }
        }
    }
}