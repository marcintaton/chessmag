namespace chessmag.defs
{
    public struct MoveUndo
    {
        public Move move;
        public int castlingRights;
        public int enPasSq;
        public int fiftyMoveCtr;
        public ulong positionHash;
    }
}