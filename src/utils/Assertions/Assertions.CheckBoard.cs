using System.Diagnostics;
using System.Security.Cryptography;
using chessmag.defs;
using chessmag.engine;

namespace chessmag.utils
{
    public static partial class Assertions
    {
        // this function is only called in debug environment, through Debug.Assert
        // in itself it also runs Debug.Assert statements
        // thus it always returns true if it reaches end of the function
        public static void CheckBoard(Board board)
        {
            Debug.Assert(checkBoard(board), "Failed to validate board");
        }
        private static bool checkBoard(Board board)
        {
            // only using several properties of board here
            // pceNum
            // bigPcs
            // majorPcs
            // minorPcs
            // materials
            // pawns
            Board t_board = Board.Clear();

            t_board.pawns[0] = board.pawns[0];
            t_board.pawns[1] = board.pawns[1];
            t_board.pawns[2] = board.pawns[2];

            // check if pieceList and pieces arrays are aligned correctly
            // for every single piece on the board
            for (int t_pceType = (int)Piece.P; t_pceType < (int)Piece.k; ++t_pceType)
            {
                for (int t_pceNum = 0; t_pceNum < board.piecesNum[t_pceType]; t_pceNum++)
                {
                    int sq = board.pieceList[t_pceType, t_pceNum];
                    Debug.Assert(
                        board.pieces[sq] == t_pceType,
                        "Inconsistency between pieceList and piece array on piece type " + (Piece)t_pceType);
                }
            }

            // set piece numbers and material values in temp structures
            // by looping through the board
            for (int sq64 = 0; sq64 < 64; sq64++)
            {
                int sq = BoardBaseConversion.Board64to120[sq64];
                int t_pce = board.pieces[sq];
                if (t_pce >= (int)Piece.P && t_pce <= (int)Piece.k)
                {
                    t_board.piecesNum[t_pce]++;
                    int color = PieceData.pieceColor[t_pce];
                    if (PieceData.isPieceBig[t_pce]) t_board.bigPceNum[color]++;
                    if (PieceData.isPieceMaj[t_pce]) t_board.majorPcsNum[color]++;
                    if (PieceData.isPieceMin[t_pce]) t_board.minorPcsNum[color]++;
                    t_board.materials[color] += PieceData.pieceValue[t_pce];
                }
            }

            // then check if incrementally updated piecesNum in original board 
            // aligns with the above 
            for (int t_pce = (int)Piece.P; t_pce < (int)Piece.k; t_pce++)
            {
                Debug.Assert(
                    t_board.piecesNum[t_pce] == board.piecesNum[t_pce],
                    "Inconsistency in piece counters on piece type " + (Piece)t_pce);
            }

            // check if pawn counters match with pawn bit boards
            Debug.Assert(
                board.piecesNum[(int)Piece.P] == BitBoard.GetBitCount(t_board.pawns[(int)Color.WHITE]),
                "Inconsistency between white pawn counter and bitboard.");
            Debug.Assert(
                board.piecesNum[(int)Piece.p] == BitBoard.GetBitCount(t_board.pawns[(int)Color.BLACK]),
                "Inconsistency between black pawn counter and bitboard.");
            Debug.Assert(
                board.piecesNum[(int)Piece.P] + board.piecesNum[(int)Piece.p] == BitBoard.GetBitCount(t_board.pawns[(int)Color.BOTH]),
                "Inconsistency between total pawn counter and bitboard.");

            // check if bit boards have pawns on correct squares
            while (t_board.pawns[(int)Color.WHITE] != 0UL)
            {
                var result = BitBoard.PopBit(t_board.pawns[(int)Color.WHITE]);
                t_board.pawns[(int)Color.WHITE] = result.Item1;
                int sq = board.pieces[BoardBaseConversion.Board64to120[result.Item2]];
                Debug.Assert(
                    sq == (int)Piece.P,
                    "Mismatch between white pawn positions in pieces array and pawn bitboard");
            }

            while (t_board.pawns[(int)Color.BLACK] != 0UL)
            {
                var result = BitBoard.PopBit(t_board.pawns[(int)Color.BLACK]);
                t_board.pawns[(int)Color.BLACK] = result.Item1;
                int sq = board.pieces[BoardBaseConversion.Board64to120[result.Item2]];
                Debug.Assert(
                    sq == (int)Piece.p,
                    "Mismatch between black pawn positions in pieces array and pawn bitboard");
            }

            while (t_board.pawns[(int)Color.BOTH] != 0UL)
            {
                var result = BitBoard.PopBit(t_board.pawns[(int)Color.BOTH]);
                t_board.pawns[(int)Color.BOTH] = result.Item1;
                int sq = board.pieces[BoardBaseConversion.Board64to120[result.Item2]];
                Debug.Assert(
                    sq == (int)Piece.P || sq == (int)Piece.p,
                    "Mismatch between any pawn positions in pieces array and pawn bitboard");
            }

            // check if relevant info is the same
            Debug.Assert(t_board.materials[(int)Color.WHITE] == board.materials[(int)Color.WHITE]
                && t_board.materials[(int)Color.BLACK] == board.materials[(int)Color.BLACK],
                "Mismatch between material count");

            Debug.Assert(t_board.bigPceNum[(int)Color.WHITE] == board.bigPceNum[(int)Color.WHITE]
               && t_board.bigPceNum[(int)Color.BLACK] == board.bigPceNum[(int)Color.BLACK],
               "Mismatch between big pieces counters");

            Debug.Assert(t_board.majorPcsNum[(int)Color.WHITE] == board.majorPcsNum[(int)Color.WHITE]
                           && t_board.majorPcsNum[(int)Color.BLACK] == board.majorPcsNum[(int)Color.BLACK],
                           "Mismatch between major pieces counters");

            Debug.Assert(t_board.minorPcsNum[(int)Color.WHITE] == board.minorPcsNum[(int)Color.WHITE]
                           && t_board.minorPcsNum[(int)Color.BLACK] == board.minorPcsNum[(int)Color.BLACK],
                           "Mismatch between minor pieces counters");

            Debug.Assert(board.sideToMove == (int)Color.WHITE || board.sideToMove == (int)Color.BLACK);
            Debug.Assert(
                PositionHash.Get(board) == board.positionHash,
                "Mismatch between position hashes.");

            // check en passant square stuff
            Debug.Assert(board.enPasSq == (int)Square.NONE
                || (BoardBaseConversion.Sq120ToRank[board.enPasSq] == (int)Rank._6 && board.sideToMove == (int)Color.WHITE)
                || (BoardBaseConversion.Sq120ToRank[board.enPasSq] == (int)Rank._3 && board.sideToMove == (int)Color.BLACK),
                $"En passant square found on unexpected rank. Expected rank 6 for white or rank 3 for black. Found: rank {BoardBaseConversion.Sq120ToRank[board.enPasSq]} side to move: {(Color)board.sideToMove}");

            // check kings' positions
            Debug.Assert(
                board.pieces[board.kingSq[(int)Color.WHITE]] == (int)Piece.K,
                "White King not found on expected square. Found " + (Piece)board.pieces[board.kingSq[(int)Color.WHITE]]);
            Debug.Assert(
                board.pieces[board.kingSq[(int)Color.BLACK]] == (int)Piece.k,
                "Black King not found on expected square. Found " + (Piece)board.pieces[board.kingSq[(int)Color.BLACK]]);

            return true;
        }
    }
}