using chessmag.defs;
using chessmag.engine;

namespace chessmag.protocols.xBoard
{
    public static class XBoard
    {
        public static bool CheckGameState(Board board)
        {
            if (BoardState.DrawBy50MoveRule(board))
            {
                XBoardIO.Claim50RuleDraw();
                return true;
            }

            if (BoardState.CheckThreeFold(board))
            {
                XBoardIO.Claim3FoldRepDraw();
                return true;
            }

            if (BoardState.DrawByMaterial(board))
            {
                XBoardIO.ClaimMaterialDraw();
                return true;
            }

            var gameResult = BoardState.CheckOrStaleMate(board);

            if (gameResult == GameResult.CHECKMATE)
            {
                XBoardIO.ClaimMate(board.sideToMove ^ 1);
                return true;
            }
            else if (gameResult == GameResult.STALEMATE)
            {
                XBoardIO.ClaimStalemate();
                return true;
            }

            return false;
        }
    }
}