namespace chessmag.defs
{

    public struct PVElement
    {
        public ulong positionHash;
        public Move move;

        public PVElement(ulong positionHash, Move move)
        {
            this.positionHash = positionHash;
            this.move = move;
        }
    }

    public struct PVTable
    {
        public const int size = 1000000;
        public PVElement[] elements = new PVElement[size];

        public PVTable()
        {
            Reset();
        }

        public readonly void Reset()
        {
            Array.Clear(elements, 0, size);
        }
    }


}