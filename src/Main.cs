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
                else if (i?[0] == 'p')
                {
                    var pv = PV.GetPvLine(b, 4);
                    b.principalVariation = pv.line;
                    Console.WriteLine("PV line of depth " + pv.count);
                    for (int j = 0; j < pv.count; j++)
                    {
                        var move = b.principalVariation[j];
                        Console.WriteLine(move.ToString());
                    }

                }
                else
                {
                    var m = IO.ParseClassicalMove(i!.Length != 0 ? i : "", b);
                    if (m.move != Move.NOMOVE)
                    {
                        b = PV.Store(b, m);
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