using System.Diagnostics;
using chessmag.defs;
using chessmag.utils;

namespace chessmag.engine
{
    public static class PositionHash
    {
        public static readonly ulong[,] PieceKeys = new ulong[13, 120];
        public static readonly ulong SideKey = 0;
        public static readonly ulong[] CastlingKeys = new ulong[16];

        // Maybe figure out a way to generate piece keys
        // in a unique way to avoid hash collisions 
        static PositionHash()
        {
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 120; j++)
                {
                    PieceKeys[i, j] = RandomUlong.Next();
                }
            }

            SideKey = RandomUlong.Next();

            for (int i = 0; i < CastlingKeys.Length; i++)
            {
                CastlingKeys[i] = RandomUlong.Next();
            }
        }

        public static ulong Get(Board b)
        {
            ulong keyOut = 0UL;

            for (int sq = 0; sq < Constants.BoardSize; sq++)
            {
                int piece = b.pieces[sq];
                if (piece != (int)Square.NONE && piece != (int)Piece.NONE)
                {
                    Assertions.PieceValid(piece);
                    keyOut ^= PieceKeys[piece, sq];
                }
            }

            if (b.sideToMove == (int)Color.WHITE)
            {
                keyOut ^= SideKey;
            }

            if (b.enPasSq != (int)Square.NONE)
            {
                Assertions.SqOnBoard(b.enPasSq);
                keyOut ^= PieceKeys[(int)Piece.NONE, b.enPasSq];
            }

            Assertions.CastlingRightsValid(b.castlingRights);
            keyOut ^= CastlingKeys[b.castlingRights];

            return keyOut;
        }
    }
}