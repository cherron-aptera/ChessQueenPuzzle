using System;
using System.Linq;
using System.Collections.Generic;

namespace ChessLib
{
    public class QueenBoard
    {
        public int EdgeSize{get;set;} = 5;
        public IEnumerable<int> Queens;

        public QueenBoard(int edgeSize, IEnumerable<int> queens)
        {
            EdgeSize = edgeSize;
            Queens = queens;
        }

        public const char SAFE = ':';
        public const char QUEEN = 'Q';
        public const char THREAT = 'X';

        public int CalculateSafes(bool printBoard = false)
        {
            // Create an image of the board state
            char[] board = new char[EdgeSize * EdgeSize];

            for (int cnt = 0; cnt < EdgeSize * EdgeSize; cnt++)
            {
                board[cnt] = SAFE;
            }

            // Add each queen to the board
            foreach (var q in Queens)
            {
                var qx = q % EdgeSize;
                var qy = (int) (q / EdgeSize);


                // Loop and set threatened squares

                // Diagonals are a bit tricky. Start at the queen location, and then move outwards in each of the 4 directions.
                for (int diag = 0; diag < 4; diag++)
                {
                    int dx = diag % 2 == 0 ? 1 : -1;
                    int dy = diag <= 2 ? 1 : -1;

                    for (int cnt = 0; cnt < EdgeSize; cnt++)
                    {
                        var x = qx + cnt * dx;
                        var y = qy + cnt * dy;
                        SetXY(ref board, x, y, THREAT);
                    }
                }

                for (int cnt = 0; cnt < EdgeSize; cnt++)
                {
                    // Set everything on the same row
                    SetXY(ref board, qx + cnt, qy, THREAT, true);

                    // Set everything on the same column
                    SetXY(ref board, qx, qy + cnt, THREAT, true);
                }
            }

            // Set each space where a queen is.
            foreach (var q in Queens)
            {
                board[q] = QUEEN;
            }

            if (printBoard)
            {
                PrintBoard(board);
            }

            return board.Count(x=> x == SAFE);
        }

        public void SetXY(ref char[] board, int x, int y, char value, bool autoLoop = false)
        {
            if ((x >= 0 && x < EdgeSize &&
                y >= 0 && y < EdgeSize) ||
                autoLoop)
            {
                board[(x % EdgeSize) + (y % EdgeSize) * EdgeSize] = value;
            }
        }

        private void PrintBoard(char[] board)
        {
            for (int y = 0; y < EdgeSize; y++)
            {
                Console.WriteLine(string.Join(' ', board.Skip(y * EdgeSize).Take(EdgeSize)));
            }
            Console.WriteLine();
        }
    }
}
