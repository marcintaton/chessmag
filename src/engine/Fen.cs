using System.Diagnostics;
using System.Runtime.InteropServices;
using chessmag.defs;
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

            foreach (var part in splitFEN)
            {
                Debug.Assert(part != "");
            }

            Board pos = Board.Clear();

            int rank = (int)Rank._8;
            int file = (int)File.a;

            // position
            foreach (var c in splitFEN[0])
            {
                int count = 1;
                int piece;
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
                        throw new Exception("Invalid FEN string");
                }

                for (int i = 0; i < count; i++)
                {
                    int sq64 = BoardBaseConversion.FrTo64(file, rank);
                    int sq120 = BoardBaseConversion.Board64to120[sq64];
                    if (piece != (int)Piece.NONE)
                    {
                        pos.pieces[sq120] = piece;
                    }
                    file++;
                }
            }

            // side to move
            Debug.Assert(splitFEN[1] == "w" || splitFEN[1] == "b");
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
            Debug.Assert(pos.castlingRights >= (int)CastlingRights.NONE && pos.castlingRights <= (int)CastlingRights.ALL);

            // en passant
            if (splitFEN[3] != "-")
            {
                int enpas_file = splitFEN[3][0] - 'a';
                int enpas_rank = splitFEN[3][1] - '1';

                Debug.Assert(enpas_file >= (int)File.a && enpas_file <= (int)File.h);
                Debug.Assert(enpas_rank >= (int)Rank._1 && enpas_rank <= (int)Rank._8);

                pos.enPasSq = BoardBaseConversion.FrTo120(enpas_file, enpas_rank);
            }

            // fifty move 
            pos.fiftyMoveCtr = int.Parse(splitFEN[4]);

            // move counter 
            pos.ply = ((int.Parse(splitFEN[5]) - 1) * 2) + pos.sideToMove;

            pos.positionID = PositionHash.Get(pos);

            return Materials.UpdateMaterials(pos);
        }
    }
}