using System;
using System.Collections.Generic;
using System.Linq;
using ChessLib;

namespace ChessPuzzle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const int edge = 5;
            const int numQueens = 5;

            var boardrange = Enumerable.Range(0, edge * edge);

            int maxSafes = 0;

            foreach (var queens in GetKCombs(boardrange, numQueens))
            {
                var board = new QueenBoard(5, queens);

                var numSafes = board.CalculateSafes();

                if (numSafes > maxSafes)
                {
                    maxSafes = numSafes;
                    Console.WriteLine($"Found a better board state with {numSafes} safe positions!");
                    board.CalculateSafes(true);
                }
            }
        }

        static IEnumerable<IEnumerable<T>>
            GetKCombs<T>(IEnumerable<T> list, int length) where T : IComparable
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetKCombs(list, length - 1)
                .SelectMany(t => list.Where(o => o.CompareTo(t.Last()) > 0),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}

    /*
    public const int Width = 5;
    public const int Height = 5;

    public static void Main(string[] args)
    {
        var boardPieces = new char[] {
            'Q', 'Q', 'Q', 'Q', 'Q',
            ':', ':', ':', ':', ':',
            ':', ':', ':', ':', ':',
            ':', ':', ':', ':', ':',
            ':', ':', ':', ':', ':',
        };

        Console.WriteLine()
    }

    static int FindMax(char[] boardState)
    {
        var maxSafes = 0; // Find the maximum number of safe squares

        foreach (var boardState in Permutations(boardPieces))
        {  
            var safes = CalculateSafes(boardState);
            if (safes > maxSafes) 
            {
                maxSafes = safes;
                Console.WriteLine($"Found a better board state with {maxSafes} safe squares!");

                // Print out the board
                for (int y = 0; y < Height; y++)
                {
                    Console.WriteLine(string.Join(' ', boardState.Skip(y * Width).Take(Width)));
                }

                Console.WriteLine();
            }
        }
        return maxSafes;
    }

    static int CalculateSafes(char[] boardState)
    {
        return 1;
    }

    static IEnumerable<T[]> Permutations<T>(T[] values, int fromInd = 0)
    {
        if (fromInd + 1 == values.Length)
            yield return values;
        else
        {
            foreach (var v in Permutations(values, fromInd + 1))
                yield return v;

            for (var i = fromInd + 1; i < values.Length; i++)
            {
                SwapValues(values, fromInd, i);
                foreach (var v in Permutations(values, fromInd + 1))
                    yield return v;
                SwapValues(values, fromInd, i);
            }
        }
    }

    static void SwapValues<T>(T[] values, int pos1, int pos2)
    {
        if (pos1 != pos2)
        {
            T tmp = values[pos1];
            values[pos1] = values[pos2];
            values[pos2] = tmp;
        }
    }
    */