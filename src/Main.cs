using System.Diagnostics;
using chessmag.defs;
using chessmag.engine;
using chessmag.protocols.UCI;
using chessmag.tests;
using chessmag.utils;

namespace chessmag
{
    public static class ChessMag
    {
        private static void Main()
        {
            UCI.MainLoop();
        }
    }
}