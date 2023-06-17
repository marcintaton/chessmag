using chessmag.defs;
using chessmag.engine;
using chessmag.utils;

namespace chessmag.protocols.UCI
{
    public static partial class UCIIO
    {
        public static Board ParsePosition(string command, Board board)
        {
            var split = command.Split(' ');

            if (split.Length >= 1 && split[0] != "position")
            {
                return board;
            }

            if (split.Length >= 2 && split[1] == "startpos")
            {
                board = Fen.Parse(Constants.StartingFEN);
            }
            else if (split.Length >= 2 && split[1] == "fen")
            {
                var fenSplit = new ArraySegment<string>(split, 2, 6);
                var fen = string.Join(' ', fenSplit);
                board = Fen.Parse(fen);
            }
            else
            {
                board = Fen.Parse(Constants.StartingFEN);
            }

            int movesIndex = Array.FindIndex(split, (x) => x == "moves") + 1;
            if (movesIndex != 0)
            {
                var moves = new ArraySegment<string>(split, movesIndex, split.Length - movesIndex).ToArray();

                for (int i = 0; i < moves.Length; i++)
                {
                    var move = IO.ParseClassicalMove(moves[i], board);
                    if (move.move == Move.NOMOVE) break;
                    board = MoveCtrl.MakeMove(move, board).board;
                    board.ply = 0;
                }
            }

            IO.PrintBoard(board);

            ///
            return board;
        }
    }
}