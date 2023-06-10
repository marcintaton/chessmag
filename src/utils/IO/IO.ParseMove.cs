using chessmag.defs;
using chessmag.engine;

namespace chessmag.utils
{
    public static partial class IO
    {
        public static Move ParseClassicalMove(string input, Board board)
        {
            if (input.Length > 5) return Move.NONE;
            if (input[0] > 'h' || input[0] < 'a') return Move.NONE;
            if (input[2] > 'h' || input[2] < 'a') return Move.NONE;
            if (input[1] > '8' || input[1] < '1') return Move.NONE;
            if (input[3] > '8' || input[3] < '1') return Move.NONE;

            int from = BoardBaseConversion.FrTo120(input[0] - 'a', input[1] - '1');
            int to = BoardBaseConversion.FrTo120(input[2] - 'a', input[3] - '1');

            Assertions.SqOnBoard(from);
            Assertions.SqOnBoard(to);

            MoveList mList = MoveGenerator.GenerateAllMoves(board);
            for (int i = 0; i < mList.count; i++)
            {
                Move move = mList.moves[i];
                if (move.FromSq == from && move.ToSq == to)
                {
                    int promPce = move.PcePromoted;
                    if (promPce != (int)Piece.NONE && input.Length > 4)
                    {
                        if (PieceData.isQueen[promPce] && input[4] == 'q') return move;
                        else if (PieceData.isRook[promPce] && input[4] == 'r') return move;
                        else if (PieceData.isBishop[promPce] && input[4] == 'b') return move;
                        else if (PieceData.isKnight[promPce] && input[4] == 'n') return move;
                        continue;
                    }
                    return move;
                }
            }

            return Move.NONE;
        }

        public static Move ParseCrazyhouseMoveMove(string input, Board board)
        {
            return Move.NONE;

        }


    }
}