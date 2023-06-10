using System.Diagnostics;
using chessmag.defs;
using chessmag.engine;
using chessmag.tests;
using chessmag.utils;

namespace chessmag
{
    public static class ChessMag
    {
        private static void Main()
        {
            var b = Fen.Parse(Constants.StartingFEN);

            // MoveExists.Check(b, new Move((int)Square.e2, (int)Square.e4));

            // IO.PrintBoard(b);

            while (true)
            {
                IO.PrintBoard(b);
                Assertions.CheckBoard(b);

                Console.Write("Make your move: ");
                var i = Console.ReadLine();

                if (i?.Length == 0)
                {
                    continue;
                }
                if (i?[0] == 'q')
                {
                    break;
                }
                else if (i?[0] == 't')
                {
                    b = MoveCtrl.UnmakeMove(b);
                    continue;
                }
                else
                {
                    var m = IO.ParseClassicalMove(i!.Length != 0 ? i : "", b);
                    if (m.move != 0x0)
                    {
                        b = MoveCtrl.MakeMove(m, b).board;
                    }
                    else
                    {
                        Console.WriteLine("Couldn't parse move");
                    }
                }
            }
        }
    }
}