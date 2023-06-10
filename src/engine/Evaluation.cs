using System.Runtime.InteropServices;
using chessmag.defs;
using chessmag.utils;

namespace chessmag.engine
{
    public static class Evaluation
    {
        private static int ApplyPositionalInfo(Board board, int piece)
        {
            int score = 0;
            bool isWhite = PieceData.pieceColor[piece] == (int)Color.WHITE;
            int modifier = isWhite ? 1 : -1;
            int[] evalTable = PositionalEvaluation.GetEvalTableFor(piece);

            for (int i = 0; i < board.piecesNum[piece]; i++)
            {
                int sq120 = board.pieceList[piece, i];
                int sq64 = isWhite ? BBC.Board120to64[sq120] : BBC.Mirror64[BBC.Board120to64[sq120]];
                Assertions.SqOnBoard(sq120);
                score += evalTable[sq64] * modifier;
            }

            return score;
        }

        public static int Get(Board board)
        {
            int score = board.materials[(int)Color.WHITE] - board.materials[(int)Color.BLACK];

            /// 
            // main shit goes here

            score += ApplyPositionalInfo(board, (int)Piece.P);
            score += ApplyPositionalInfo(board, (int)Piece.p);
            score += ApplyPositionalInfo(board, (int)Piece.N);
            score += ApplyPositionalInfo(board, (int)Piece.n);
            score += ApplyPositionalInfo(board, (int)Piece.B);
            score += ApplyPositionalInfo(board, (int)Piece.b);
            score += ApplyPositionalInfo(board, (int)Piece.R);
            score += ApplyPositionalInfo(board, (int)Piece.r);

            ///
            if (board.sideToMove == (int)Color.BLACK) score *= -1;

            return score;
        }
    }
}