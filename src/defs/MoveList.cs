namespace chessmag.defs
{
    public struct MoveList
    {
        public int count;
        public Move[] moves = new Move[Constants.MaxPosMoves];

        public MoveList()
        {
        }

        // why do we need a board?
        public void AddQuietMove(int move)
        {
            moves[count].move = move;
            moves[count].score = 0;
            count++;
        }

        public void AddCaptureMove(int move)
        {
            moves[count].move = move;
            moves[count].score = 0;
            count++;
        }

        public void AddEnPassantMove(int move)
        {
            moves[count].move = move;
            moves[count].score = 0;
            count++;
        }
    }
}