using chessmag.src.defs;

namespace chessmag.src
{
    class Board
    {
        // general position info
        public int[] pieces = new int[Constants.BoardSize];
        public ulong[] pawns = new ulong[3]; // for white, black and both
        public int[] kingSq = new int[2]; // field indices for kings

        // position specifics
        public int sideToMove = (int)Color.WHITE;
        public int enPasSq = (int)Square.NONE;
        public int fiftyMoveCtr = 0;
        public int ply = 0;
        public int histPly = 0; // determining repetition
        public int castlingRights = 15; // 1111 - meaning all 4 casting rights are available
        public ulong positionID = 0;

        public MoveUndo[] moveHist = new MoveUndo[Constants.MaxPly];

        // how many pieces of each tyle are on the board
        // separated into non pawns, major and minor pieces
        public int[] piecesNum = new int[13];
        public int[] chessmenNum = new int[3];
        public int[] majorPcsNum = new int[3];
        public int[] minorPcsNum = new int[3];

        // piece list - contains positions for every possible piece
        // 13 - types of pieces 
        // 20 - max number of given piece type (due to promotion and capturing with crazyhouse rules)
        // normally 10 instead of 20
        public int[,] piceList = new int[13, 20];
    }
}