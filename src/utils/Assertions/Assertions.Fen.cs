using System.Diagnostics;

namespace chessmag.utils
{
    public static partial class Assertions
    {
        public static void FenPartsNonEmpty(string fen)
        {
#if DEBUG
            foreach (var part in fen.Split(' '))
            {
                Debug.Assert(
                    part != "",
                    "Part of FEN is missing. Fen is: " + fen);
            }
#endif
        }

        public static void FenSideValid(string fenPart)
        {
            Debug.Assert(
               fenPart == "w" || fenPart == "b",
               "Side to move in FEN is invalid. Char found: " + fenPart);
        }
    }
}