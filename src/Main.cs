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
            var b = Fen.Parse(Constants.TestFEN3);

            IO.PrintBoard(b);

            var info = new SearchInfo
            {
                depth = 5
            };
            Search.SearchPosition(b, info);

            // var moveList = MoveGenerator.GenerateAllMoves(b);

            // while (true)
            // {
            //     IO.PrintBoard(b);
            //     Assertions.CheckBoard(b);

            //     Console.Write("Make your move: ");
            //     var i = Console.ReadLine();

            //     if (i?.Length == 0)
            //     {
            //         continue;
            //     }
            //     if (i?[0] == 'q')
            //     {
            //         break;
            //     }
            //     else if (i?[0] == 't')
            //     {
            //         b = MoveCtrl.UnmakeMove(b);
            //         continue;
            //     }
            //     else if (i?[0] == 's')
            //     {
            //         var info = new SearchInfo
            //         {
            //             depth = 4
            //         };
            //         Search.SearchPosition(b, info);
            //     }
            //     else
            //     {
            //         var m = IO.ParseClassicalMove(i!.Length != 0 ? i : "", b);
            //         if (m.move != Move.NOMOVE)
            //         {
            //             b = PV.Store(b, m);
            //             b = MoveCtrl.MakeMove(m, b).board;
            //         }
            //         else
            //         {
            //             Console.WriteLine("Couldn't parse move");
            //         }
            //     }
            // }
        }
    }
}