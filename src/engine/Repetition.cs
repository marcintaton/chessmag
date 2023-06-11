using chessmag.utils;

namespace chessmag.engine
{
    public static class Repetition
    {
        public static bool Check(Board board)
        {

            for (int i = board.gamePly - 1; i >= 0; i--)
            {
                Assertions.WithinMaxGameMoves(i);

                if (board.positionHash == board.moveHist[i].positionHash)
                {
                    return true;
                }
            }

            return false;
        }
    }
}