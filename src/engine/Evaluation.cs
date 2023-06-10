using System.Runtime.InteropServices;
using chessmag.defs;
using chessmag.utils;

namespace chessmag.engine
{
    public static class Evaluation
    {
        public static int Get(Board board)
        {
            int score = board.materials[(int)Color.WHITE] - board.materials[(int)Color.BLACK];

            /// 
            // main shit goes here

            int piece = (int)Piece.P;

            for (int i = 0; i < board.piecesNum[piece]; i++)
            {
                int sq120 = board.pieceList[piece, i];
                Assertions.SqOnBoard(sq120);
                score += PositionalEvaluation.pawn[BBC.Board120to64[sq120]];
            }

            piece = (int)Piece.p;

            for (int i = 0; i < board.piecesNum[piece]; i++)
            {
                int sq120 = board.pieceList[piece, i];
                Assertions.SqOnBoard(sq120);
                score -= PositionalEvaluation.pawn[BBC.Mirror64[BBC.Board120to64[sq120]]];
            }

            piece = (int)Piece.N;

            for (int i = 0; i < board.piecesNum[piece]; i++)
            {
                int sq120 = board.pieceList[piece, i];
                Assertions.SqOnBoard(sq120);
                score += PositionalEvaluation.knight[BBC.Board120to64[sq120]];
            }

            piece = (int)Piece.n;

            for (int i = 0; i < board.piecesNum[piece]; i++)
            {
                int sq120 = board.pieceList[piece, i];
                Assertions.SqOnBoard(sq120);
                score -= PositionalEvaluation.knight[BBC.Mirror64[BBC.Board120to64[sq120]]];
            }

            piece = (int)Piece.N;

            for (int i = 0; i < board.piecesNum[piece]; i++)
            {
                int sq120 = board.pieceList[piece, i];
                Assertions.SqOnBoard(sq120);
                score += PositionalEvaluation.knight[BBC.Board120to64[sq120]];
            }

            piece = (int)Piece.n;

            for (int i = 0; i < board.piecesNum[piece]; i++)
            {
                int sq120 = board.pieceList[piece, i];
                Assertions.SqOnBoard(sq120);
                score -= PositionalEvaluation.knight[BBC.Mirror64[BBC.Board120to64[sq120]]];
            }

            piece = (int)Piece.B;

            for (int i = 0; i < board.piecesNum[piece]; i++)
            {
                int sq120 = board.pieceList[piece, i];
                Assertions.SqOnBoard(sq120);
                score += PositionalEvaluation.bishop[BBC.Board120to64[sq120]];
            }

            piece = (int)Piece.b;

            for (int i = 0; i < board.piecesNum[piece]; i++)
            {
                int sq120 = board.pieceList[piece, i];
                Assertions.SqOnBoard(sq120);
                score -= PositionalEvaluation.bishop[BBC.Mirror64[BBC.Board120to64[sq120]]];
            }

            piece = (int)Piece.R;

            for (int i = 0; i < board.piecesNum[piece]; i++)
            {
                int sq120 = board.pieceList[piece, i];
                Assertions.SqOnBoard(sq120);
                score += PositionalEvaluation.rook[BBC.Board120to64[sq120]];
            }

            piece = (int)Piece.r;

            for (int i = 0; i < board.piecesNum[piece]; i++)
            {
                int sq120 = board.pieceList[piece, i];
                Assertions.SqOnBoard(sq120);
                score -= PositionalEvaluation.rook[BBC.Mirror64[BBC.Board120to64[sq120]]];
            }

            ///

            if (board.sideToMove == (int)Color.BLACK) score *= -1;

            return score;
        }
    }
}