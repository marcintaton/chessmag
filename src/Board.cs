using chessmag.src.defs;

namespace chessmag.src
{
    class Board
    {
        // general position info
        public int[] pieces = new int[Constants.BoardSize];
        public UInt64[] pawns = new UInt64[3]; // for white, black and both
        public int[] kingSq = new int[2]; // field indices for kings

        // position specifics
        public int sideToMove = (int)Color.WHITE;
        public int enPasSq = (int)Square.NONE;
        public int fiftyMoveCtr = 0;
        public int ply = 0;
        public int histPly = 0; // determining repetition
        public UInt64 positionID = 0;

        // how many pieces of each tyle are on the board
        // separated into non pawns, major and minor pieces
        public int[] piecesNum = new int[13];
        public int[] chessmenNum = new int[3];
        public int[] majorPcsNum = new int[3];
        public int[] minorPcsNum = new int[3];
    }
}