namespace chessmag.src.defs
{
    public struct MoveUndo
    {
        public int move;
        public int castleRights;
        public int enPasSq;
        public int fiftyMoveCtr;
        public UInt64 positionID;
    }
}