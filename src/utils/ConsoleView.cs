using chessmag.defs;
using chessmag.engine;
using File = chessmag.defs.File;

namespace chessmag.utils
{
    public static class ConsoleView
    {
        public static void PrintBitBoard(ulong board)
        {
            Console.WriteLine();

            for (int rank = (int)Rank._8; rank >= (int)Rank._1; --rank)
            {
                Console.Write(rank + 1 + "  ");

                for (int file = (int)File.a; file <= (int)File.h; ++file)
                {
                    int sq120 = BoardBaseConversion.FrTo120(file, rank);
                    int sq64 = BoardBaseConversion.Board120to64[sq120];
                    if (((1UL << sq64) & board) != 0)
                    {
                        Console.Write("@");
                    }
                    else
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("   abcdefgh");
            Console.WriteLine();
        }

        public static void printBoard(Board board)
        {
            Console.WriteLine("Game Board\n");


            for (int rank = (int)Rank._8; rank >= (int)Rank._1; --rank)
            {
                Console.Write((rank + 1) + "  ");
                for (int file = (int)File.a; file <= (int)File.h; ++file)
                {
                    int sq = BoardBaseConversion.FrTo120(file, rank);
                    int piece = board.pieces[sq];
                    if (piece < 12)
                        Console.Write(" " + (Piece)piece);
                    else
                        Console.Write(" .");
                }
                Console.WriteLine();
            }
            Console.Write("\n    a b c d e f g h\n");
            Console.WriteLine();

            Console.WriteLine("Side to move: " + (Color)board.sideToMove);
            Console.Write(
                "Castling rights: {0}{1}{2}{3}",
                (CastlingRights)(board.castlingRights & (int)CastlingRights.K) != CastlingRights.NONE ? (CastlingRights)(board.castlingRights & (int)CastlingRights.K) : "",
                (CastlingRights)(board.castlingRights & (int)CastlingRights.Q) != CastlingRights.NONE ? (CastlingRights)(board.castlingRights & (int)CastlingRights.Q) : "",
                (CastlingRights)(board.castlingRights & (int)CastlingRights.k) != CastlingRights.NONE ? (CastlingRights)(board.castlingRights & (int)CastlingRights.k) : "",
                (CastlingRights)(board.castlingRights & (int)CastlingRights.q) != CastlingRights.NONE ? (CastlingRights)(board.castlingRights & (int)CastlingRights.q) : "");
            if (board.castlingRights == (int)CastlingRights.NONE) Console.Write("-\n"); else Console.Write("\n");
            Console.WriteLine("EnPassant Square " + (Square)board.enPasSq);
            Console.WriteLine("Move: " + Math.Ceiling((double)board.ply / 2));
            Console.WriteLine("Ply: " + board.ply);
            Console.WriteLine("Fifty moves: " + board.fiftyMoveCtr);
            Console.WriteLine("Position ID: " + Convert.ToString((long)board.positionID, 16).ToUpper());
            Console.WriteLine("Materials: white - " + board.materials[(int)Color.WHITE] + "; black - " + board.materials[(int)Color.BLACK] + ";");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}