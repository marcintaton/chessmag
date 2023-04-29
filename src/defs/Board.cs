using System.IO.Pipes;
using chessmag.src.defs;

namespace chessmag.src
{
    public struct Board
    {
        // general position info
        // how many pieces of each tyle are on the board
        // separated into non pawns, major and minor pieces
        public int[] pieces = new int[Constants.BoardSize];
        public int[] kingSq = new int[2]; // field indices for kings
        public ulong[] pawns = new ulong[3]; // for white, black and both
        public int[] chessmenNum = new int[3]; // big pieces - non pawns
        public int[] majorPcsNum = new int[3]; // rooks and queens
        public int[] minorPcsNum = new int[3]; // bishops and knights
        public int[] piecesNum = new int[13];



        // position specifics
        public int sideToMove = (int)Color.WHITE;
        public int enPasSq = (int)Square.NONE;
        public int fiftyMoveCtr = 0;
        public int ply = 0;
        public int histPly = 0; // determining repetition
        public int castlingRights = (int)CastlingRights.NONE; // 15 - 1111 - meaning all 4 casting rights are available
        public ulong positionID = 0; // a unique position hash key 

        public MoveUndo[] moveHist = new MoveUndo[Constants.MaxPly];


        // piece list - contains positions for every possible piece
        // 13 - types of pieces 
        // 20 - max number of given piece type (due to promotion and capturing with crazyhouse rules)
        // normally 10 instead of 20
        public int[,] piceList = new int[13, 10];

        public Board()
        {
            Array.Fill(pieces, (int)Square.NONE);

            for (int i = 0; i < 3; i++)
            {
                chessmenNum[i] = 0;
                majorPcsNum[i] = 0;
                minorPcsNum[i] = 0;
                pawns[i] = 0UL;
            }

            Array.Fill(piecesNum, 0);
            Array.Fill(kingSq, (int)Square.NONE);

            sideToMove = (int)Color.BOTH;
            enPasSq = (int)Square.NONE;
            fiftyMoveCtr = 0;
            ply = 0;
            histPly = 0;
            castlingRights = (int)CastlingRights.NONE;
            positionID = 0UL;

            moveHist = new MoveUndo[Constants.MaxPly];

            // piece list reset comes later
        }

        public static Board Clear()
        {
            return new();
        }
    }
}