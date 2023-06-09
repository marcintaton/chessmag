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

            b = MoveCtrl.MakeMove(new Move(8, (int)Square.e7), b).board;

            IO.PrintBoard(b);
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
            //     else
            //     {
            //         var m = IO.ParseClassicalMove(i!.Length != 0 ? i : "", b);
            //         if (m.move != 0x0)
            //         {
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