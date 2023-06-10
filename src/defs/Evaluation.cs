namespace chessmag.defs
{
    public struct PositionalEvaluation
    {
        public static int[] pawn = {
            0   ,   0   ,   0   ,   0   ,   0   ,   0   ,   0   ,   0,
            10  ,   10  ,   0   ,   -10 ,   -10 ,   0   ,   10  ,   10,
            5   ,   0   ,   0   ,   5   ,   5   ,   0   ,   0   ,   5,
            0   ,   0   ,   10  ,   20  ,   20  ,   10  ,   0   ,   0,
            5   ,   5   ,   5   ,   10  ,   10  ,   5   ,   5   ,   5,
            10  ,   10  ,   10  ,   20  ,   20  ,   10  ,   10  ,   10,
            20  ,   20  ,   20  ,   30  ,   30  ,   20  ,   20  ,   20,
            0   ,   0   ,   0   ,   0   ,   0   ,   0   ,   0   ,   0,
        };

        public static int[] knight = {
            0   ,   -10 ,   0   ,   0   ,   0   ,   0   ,   -10 ,   0   ,
            0   ,   0   ,   0   ,   5   ,   5   ,   0   ,   0   ,   0   ,
            0   ,   0   ,   10  ,   10  ,   10  ,   10  ,   0   ,   0   ,
            0   ,   0   ,   10  ,   20  ,   20  ,   10  ,   0   ,   0   ,
            5   ,   10  ,   15  ,   20  ,   20  ,   15  ,   10  ,   5   ,
            5   ,   10  ,   10  ,   20  ,   20  ,   10  ,   10  ,   5   ,
            0   ,   0   ,   5   ,   10  ,   10  ,   5   ,   0   ,   0   ,
            0   ,   0   ,   0   ,   0   ,   0   ,   0   ,   0   ,   0   ,
        };

        public static int[] bishop = {
            0   ,   0   ,   -10 ,   0   ,   0   ,   -10 ,   0   ,   0   ,
            0   ,   10  ,   0   ,   0   ,   0   ,   0   ,   10  ,   0   ,
            0   ,   0   ,   10  ,   15  ,   15  ,   10  ,   0   ,   0   ,
            0   ,   10  ,   15  ,   20  ,   20  ,   15  ,   10  ,   0   ,
            0   ,   10  ,   15  ,   20  ,   20  ,   15  ,   10  ,   0   ,
            0   ,   0   ,   10  ,   15  ,   15  ,   10  ,   0   ,   0   ,
            0   ,   0   ,   0   ,   10  ,   10  ,   0   ,   0   ,   0   ,
            0   ,   0   ,   0   ,   0   ,   0   ,   0   ,   0   ,   0   ,
        };

        public static int[] rook = {
            0   ,   0   ,   5   ,   10  ,   10  ,   5   ,   0   ,   0   ,
            0   ,   0   ,   5   ,   10  ,   10  ,   5   ,   0   ,   0   ,
            0   ,   0   ,   0   ,   0   ,   0   ,   0   ,   0   ,   0   ,
            0   ,   0   ,   0   ,   0   ,   0   ,   0   ,   0   ,   0   ,
            0   ,   0   ,   0   ,   0   ,   0   ,   0   ,   0   ,   0   ,
            0   ,   0   ,   0   ,   0   ,   0   ,   0   ,   0   ,   0   ,
            25  ,   25  ,   25  ,   25  ,   25  ,   25  ,   25  ,   25  ,
            0   ,   0   ,   5   ,   10  ,   10  ,   5   ,   0   ,   0   ,
        };

        public PositionalEvaluation()
        {
        }
    }
}