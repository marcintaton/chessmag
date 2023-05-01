using chessmag.defs;
using chessmag.utils;

namespace chessmag.engine
{
    public static partial class MoveCtrl
    {
        private static ulong hashPce(Board b, int sq120, int pce) => b.positionHash ^ PositionHash.PieceKeys[pce, sq120];
        private static ulong hashCR(Board b) => b.positionHash ^ PositionHash.CastlingKeys[b.castlingRights];
        private static ulong hashSide(Board b) => b.positionHash ^ PositionHash.SideKey;
        private static ulong hashEp(Board b) => b.positionHash ^ PositionHash.PieceKeys[(int)Piece.NONE, b.enPasSq];

        private static readonly int[] castlePerms = new int[120];

        static MoveCtrl()
        {
            // setting values for doing bitwise & with castling permissions 
            // to quickly determine if they are lost 
            Array.Fill(castlePerms, 15);
            castlePerms[(int)Square.a1] = 13;
            castlePerms[(int)Square.e1] = 12;
            castlePerms[(int)Square.h1] = 14;
            castlePerms[(int)Square.a8] = 7;
            castlePerms[(int)Square.e8] = 3;
            castlePerms[(int)Square.h8] = 11;
        }
    }
}