using chessmag.defs;

namespace chessmag.engine
{
    public static class MoveOrdering
    {
        public const int MVV_VLA_PAWN_TAKES_PAWN = 105;
        public const int CAPTURE_VALUE = 1000000;
        public const int HISTORY_H_VALUE = 105;
        public const int KILLER_VALUE1 = 900000;
        public const int KILLER_VALUE2 = 800000;
        public const int ALWAYS_FIRST = 2000000;

        public static readonly int[,] MvvLvaScores = new int[13, 13];

        static MoveOrdering()
        {
            for (int attacker = (int)Piece.P; attacker <= (int)Piece.k; attacker++)
            {
                for (int victim = (int)Piece.P; victim <= (int)Piece.k; victim++)
                {
                    MvvLvaScores[victim, attacker] = PieceData.VictimWorth[victim] + 6 - (PieceData.VictimWorth[attacker] / 100);
                }
            }
        }
    }
}