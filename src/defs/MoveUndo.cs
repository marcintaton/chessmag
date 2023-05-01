namespace chessmag.defs
{
    public struct MoveUndo
    {
        public int move;
        public int castlingRights;
        public int enPasSq;
        public int fiftyMoveCtr;
        public ulong positionHash;
    }
}