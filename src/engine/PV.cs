using chessmag.defs;

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

            return Move.NOMOVE;
        }
    }
}