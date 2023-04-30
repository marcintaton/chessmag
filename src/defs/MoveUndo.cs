namespace chessmag.defs
{
    public struct MoveUndo
    {
        public int move;
        public int castleRights;
        public int enPasSq;
        public int fiftyMoveCtr;
        public ulong positionID;
    }
}