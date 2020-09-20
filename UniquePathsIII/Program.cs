using System;

namespace UniquePathsIII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Solution
    {
        public int Rows { get; set; }
        public int Cols { get; set; }
        public int[][] BidimensionalGridArray { get; set; }
        public int Counter { get; set; }

        public int UniquePathsIII(int[][] grid)
        {
            int startRow = 0, startCol = 0;
            int noObstacles = 0;

            Rows = grid.Length;
            Cols = grid[0].Length;

            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Cols; col++)
                {
                    int cell = grid[row][col];
                    if (cell >= 0)
                        noObstacles += 1;
                    if (cell == 1)
                    {
                        startRow = row;
                        startCol = col;
                    }
                }

            BidimensionalGridArray = grid;
            Counter = 0;

            Backtrack(startRow, startCol, noObstacles);

            return Counter;
        }

        private void Backtrack(int row, int col, int remain)
        {
            if (BidimensionalGridArray[row][col] == 2 && remain == 1)
            {
                Counter++;
                return;
            }

            int temp = BidimensionalGridArray[row][col];
            BidimensionalGridArray[row][col] = -4;
            remain--;

            int[] rowOffsets = { 0, 0, 1, -1 };
            int[] colOffsets = { 1, -1, 0, 0 };
            for (int i = 0; i < 4; ++i)
            {
                int nextRow = row + rowOffsets[i];
                int nextCol = col + colOffsets[i];

                if (0 > nextRow || nextRow >= this.Rows ||
                    0 > nextCol || nextCol >= this.Cols)
                    continue;

                if (BidimensionalGridArray[nextRow][nextCol] < 0)
                    continue;

                Backtrack(nextRow, nextCol, remain);
            }

            BidimensionalGridArray[row][col] = temp;
        }
    }
}
