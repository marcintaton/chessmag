using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using chessmag.defs;

namespace chessmag.utils
{
    public static partial class IO
    {
        public static readonly Queue<string> messageQueue = new();
        private static Thread peekThread = null!;

        public static void StartPeeking(CancellationToken token)
        {
            peekThread = new Thread(() => PeekingFn(token))
            {
                IsBackground = true
            };
            peekThread.Start();
        }

        private static void PeekingFn(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var key = Console.ReadKey(true).KeyChar.ToString();
                messageQueue.Enqueue(key);
            }
        }

        public static string PeekStdIn()
        {
            var interrupt = "";

            while (messageQueue.Count != 0)
            {
                string keyCode = messageQueue.Dequeue();

                if (keyCode != "")
                {
                    interrupt += keyCode;
                }
            }

            Thread.Yield();

            return interrupt;
        }
    }
}