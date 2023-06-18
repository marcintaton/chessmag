using System.Net.NetworkInformation;
using chessmag.defs;
using chessmag.utils;

namespace chessmag.engine
{
    public static class BoardState
    {
        public static bool CheckRepetition(Board board)
        {

            for (int i = board.gamePly - 1; i >= 0; i--)
            {
                Assertions.WithinMaxGameMoves(i);

                if (board.positionHash == board.moveHist[i].positionHash)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool CheckThreeFold(Board board)
        {
            int repCount = 0;

            for (int i = 0; i < board.gamePly; i++)
            {
                Assertions.WithinMaxGameMoves(i);

                if (board.positionHash == board.moveHist[i].positionHash)
                {
                    repCount++;
                }
            }

            return repCount >= 3;
        }

        public static bool DrawByMaterial(Board board)
        {
            if (board.piecesNum[(int)Piece.P] != 0 || board.piecesNum[(int)Piece.p] != 0) return false;
            if (board.piecesNum[(int)Piece.R] != 0 || board.piecesNum[(int)Piece.r] != 0) return false;
            if (board.piecesNum[(int)Piece.Q] != 0 || board.piecesNum[(int)Piece.q] != 0) return false;
            if (board.piecesNum[(int)Piece.B] > 1 || board.piecesNum[(int)Piece.b] > 1) return false;
            if (board.piecesNum[(int)Piece.N] > 1 || board.piecesNum[(int)Piece.n] > 1) return false;
            if (board.piecesNum[(int)Piece.N] != 0 && board.piecesNum[(int)Piece.B] != 0) return false;
            if (board.piecesNum[(int)Piece.n] != 0 && board.piecesNum[(int)Piece.b] != 0) return false;

            return true;
        }

        public static bool DrawBy50MoveRule(Board board)
        {
            return board.fiftyMoveCtr > 100;
        }

        public static GameResult CheckOrStaleMate(Board board)
        {
            var moveList = MoveGenerator.GenerateAllMoves(board);
            for (int i = 0; i < moveList.count; i++)
            {
                var result = MoveCtrl.MakeMove(moveList.moves[i], board);

                if (result.wasLegal)
                {
                    return GameResult.UNRESOLVED;
                }
            }

            var inCheck = Attack.IsSquareAttacked(board.kingSq[board.sideToMove], board.sideToMove ^ 1, board);

            return inCheck ? GameResult.CHECKMATE : GameResult.STALEMATE;
        }
    }
}