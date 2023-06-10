using chessmag.defs;
using chessmag.utils;

namespace chessmag.engine
{
    public static class PV
    {
        public static Board Store(Board board, Move move)
        {
            ulong index = board.positionHash % PVTable.size;

            board.pvTable.elements[index] = new PVElement(board.positionHash, move);

            return board;
        }

        public static Move Probe(Board board)
        {
            ulong index = board.positionHash % PVTable.size;

            if (board.pvTable.elements[index].positionHash == board.positionHash)
            {
                return board.pvTable.elements[index].move;
            }

            return Move.NONE;
        }

        public static PVLine GetPvLine(Board board, int depth)
        {
            Assertions.WithinMaxDepth(depth);
            PVLine pv = new PVLine();
            Move move = Probe(board);

            while (move.move != Move.NOMOVE && pv.count < depth)
            {
                Assertions.WithinMaxDepth(pv.count);

                if (MoveExists.Check(board, move))
                {
                    board = MoveCtrl.MakeMove(move, board).board;
                    pv.line[pv.count] = move;
                    pv.count++;
                }
                else
                {
                    break;
                }
                move = Probe(board);
            }

            while (board.ply > 0)
            {
                board = MoveCtrl.UnmakeMove(board);
            }

            return pv;
        }
    }
}