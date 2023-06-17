using chessmag.defs;
using chessmag.engine;
using chessmag.utils;

namespace chessmag.protocols.UCI
{
    public static partial class UCIIO
    {
        public static BoardWInfo ParseGo(string command, Board board, SearchInfo sInfo)
        {
            var depth = -1;
            var movesToGo = 30;
            var moveTime = -1;
            var time = -1;
            var inc = 0;
            sInfo.timeSet = false;

            var split = command.Split(' ');

            if (split.Length >= 1 && split[0] != "go")
            {
                return new BoardWInfo(board, sInfo);
            }

            if (split.Contains("infinite"))
            {
                sInfo.timeSet = false;
            }

            if (board.sideToMove == (int)Color.WHITE)
            {
                var wTimeIdx = Array.FindIndex(split, (x) => x == "wtime") + 1;
                var wIncIdx = Array.FindIndex(split, (x) => x == "winc") + 1;

                if (wTimeIdx != 0)
                {
                    try
                    {
                        time = int.Parse(split[wTimeIdx]);
                    }
                    catch { }
                }

                if (wIncIdx != 0)
                {
                    try
                    {
                        inc = int.Parse(split[wIncIdx]);
                    }
                    catch { }
                }
            }

            if (board.sideToMove == (int)Color.BLACK)
            {
                var bTimeIdx = Array.FindIndex(split, (x) => x == "btime") + 1;
                var bIncIdx = Array.FindIndex(split, (x) => x == "binc") + 1;

                if (bTimeIdx != 0)
                {
                    try
                    {
                        time = int.Parse(split[bTimeIdx]);
                    }
                    catch { }
                }

                if (bIncIdx != 0)
                {
                    try
                    {
                        inc = int.Parse(split[bIncIdx]);
                    }
                    catch { }
                }
            }

            var moveToGoIdx = Array.FindIndex(split, (x) => x == "movestogo") + 1;
            try
            {
                movesToGo = int.Parse(split[moveToGoIdx]);
            }
            catch { }

            var moveTimeIdx = Array.FindIndex(split, (x) => x == "movetime") + 1;
            try
            {
                moveTime = int.Parse(split[moveTimeIdx]);
            }
            catch { }

            var depthIndex = Array.FindIndex(split, (x) => x == "depth") + 1;
            try
            {
                depth = int.Parse(split[depthIndex]);
            }
            catch { }

            if (moveTime != -1)
            {
                time = moveTime;
                movesToGo = 1;
            }

            if (time != -1)
            {
                sInfo.timeSet = true;
                time /= movesToGo;
                time -= 50;
                sInfo.stopTime = time + inc;
            }

            sInfo.depth = depth == -1 ? Constants.MaxDepth : depth;

            return Search.SearchPosition(board, sInfo);
        }
    }
}