using chessmag.defs;

namespace chessmag.utils
{
    public static partial class IO
    {
        public static void PrintMoveList(MoveList ml)
        {
            Console.WriteLine($"MoveList. Item count: {ml.count}");

            for (int i = 0; i < ml.count; i++)
            {
                Console.WriteLine($"Move({i + 1}): {ml.moves[i]}, score: {ml.moves[i].score}");
            }
        }
    }
}