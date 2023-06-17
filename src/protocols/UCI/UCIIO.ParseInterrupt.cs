using chessmag.defs;
using chessmag.engine;
using chessmag.utils;

namespace chessmag.protocols.UCI
{

    public static partial class UCIIO
    {

        public static SearchInfo ParseInterrupt(string interrupt, SearchInfo sInfo)
        {
            if (interrupt != "")
            {
                if (interrupt == "stop\n" || interrupt == "stop")
                {
                    Console.WriteLine("Stopping");
                    sInfo.stopped = true;
                }
                if (interrupt == "quit\n" || interrupt == "quit")
                {
                    Console.WriteLine("Quitting");
                    sInfo.quit = true;
                }
            }
            return sInfo;
        }
    }
}