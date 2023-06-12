using chessmag.defs;

namespace chessmag.engine
{
    public static class MvvLva
    {
        public const int PAWN_TAKES_PAWN = 105;

        public static readonly int[,] Scores = new int[13, 13];

        static MvvLva()
        {
            for (int attacker = (int)Piece.P; attacker <= (int)Piece.k; attacker++)
            {
                for (int victim = (int)Piece.P; victim <= (int)Piece.k; victim++)
                {
                    Scores[victim, attacker] = PieceData.VictimWorth[victim] + 6 - (PieceData.VictimWorth[attacker] / 100);
                }
            }
        }
    }
}