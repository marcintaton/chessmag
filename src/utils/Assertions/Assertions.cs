using System.Diagnostics;
using chessmag.defs;
using chessmag.engine;

namespace chessmag.utils
{
    public static partial class Assertions
    {
        public static void SqOnBoard(int sq120, string message = "")
        {
            Debug.Assert(!BoardBaseConversion.IsOffboard(sq120), "Square is outside of the board. Square: " + sq120, message);
        }

        public static void SideValid(int side, string message = "")
        {
            Debug.Assert(side == (int)Color.WHITE || side == (int)Color.BLACK, "Invalid side. Found: " + side, message);
        }

        public static void FileRankValid(int fr, string message = "")
        {
            Debug.Assert(fr >= 0 && fr <= 7, "File or rank out of bounds. Found: " + fr, message);
        }

        public static void PieceValid(int piece, string message = "")
        {
            Debug.Assert(piece >= (int)Piece.P && piece <= (int)Piece.k, "Invalid piece. Found: " + piece, message);
        }

        public static void PieceValidOrNone(int piece, string message = "")
        {
            Debug.Assert(piece >= (int)Piece.NONE && piece <= (int)Piece.k, "Invalid piece (inc. NONE). Found: " + piece, message);
        }

        public static void CastlingRightsValid(int cr, string message = "")
        {
            Debug.Assert(cr >= (int)CastlingRights.NONE && cr <= (int)CastlingRights.ALL, "Invalid Castling Rights. Found: " + cr, message);

        }
    }
}