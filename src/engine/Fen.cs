using System.Diagnostics;
using System.Runtime.InteropServices;
using chessmag.defs;
using chessmag.utils;
using File = chessmag.defs.File;

namespace chessmag.engine
{
    public static class Fen
    {
        public static Board Parse(string fen)
        {
            // splitting fen into manageable parts 
            // 0 - position
            // 1 - side to move
            // 2 - castling rights
            // 3 - enpas square
            // 4 - 50 move counter
            // 5 - full move counter 

            string[] splitFEN = fen.Split(' ');

            Assertions.FenPartsNonEmpty(fen);

            Board pos = Board.Clear();

            int rank = (int)Rank._8;
            int file = (int)File.a;

            // position
            foreach (var c in splitFEN[0])
            {
                int count = 1;
                int piece = (int)Piece.NONE;
                switch (c)
                {
                    case 'p': piece = (int)Piece.p; break;
                    case 'r': piece = (int)Piece.r; break;
                    case 'n': piece = (int)Piece.n; break;
                    case 'b': piece = (int)Piece.b; break;
                    case 'q': piece = (int)Piece.q; break;
                    case 'k': piece = (int)Piece.k; break;
                    case 'P': piece = (int)Piece.P; break;
                    case 'R': piece = (int)Piece.R; break;
                    case 'N': piece = (int)Piece.N; break;
                    case 'B': piece = (int)Piece.B; break;
                    case 'Q': piece = (int)Piece.Q; break;
                    case 'K': piece = (int)Piece.K; break;

                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                        piece = (int)Piece.NONE;
                        count = c - '0';
                        break;

                    case ' ':
                    case '/':
                        rank--;
                        file = (int)File.a;
                        continue;
                    default:
                        Assertions.Fail();
                        break;
                }

                for (int i = 0; i < count; i++)
                {
                    int sq64 = BBC.FrTo64(file, rank);
                    int sq120 = BBC.Board64to120[sq64];
                    if (piece != (int)Piece.NONE)
                    {
                        pos.pieces[sq120] = piece;
                    }
                    file++;
                }
            }

            // side to move
            Assertions.FenSideValid(splitFEN[1]);
            pos.sideToMove = splitFEN[1] == "w" ? (int)Color.WHITE : (int)Color.BLACK;

            // castling
            if (splitFEN[2] != "-")
            {
                foreach (var cr in splitFEN[2])
                {
                    switch (cr)
                    {
                        case 'K': pos.castlingRights |= (int)CastlingRights.K; break;
                        case 'Q': pos.castlingRights |= (int)CastlingRights.Q; break;
                        case 'k': pos.castlingRights |= (int)CastlingRights.k; break;
                        case 'q': pos.castlingRights |= (int)CastlingRights.q; break;
                    }
                }
            }

            Assertions.CastlingRightsValid(pos.castlingRights);

            // en passant
            if (splitFEN[3] != "-")
            {
                int enpas_file = splitFEN[3][0] - 'a';
                int enpas_rank = splitFEN[3][1] - '1';

                Assertions.FileRankValid(enpas_file);
                Assertions.FileRankValid(enpas_rank);

                pos.enPasSq = BBC.FrTo120(enpas_file, enpas_rank);
            }

            // fifty move 
            pos.fiftyMoveCtr = int.Parse(splitFEN[4]);

            // move counter 
            pos.gamePly = ((int.Parse(splitFEN[5]) - 1) * 2) + pos.sideToMove;

            pos.positionHash = PositionHash.Get(pos);

            return Materials.UpdateMaterials(pos);
        }
    }
}