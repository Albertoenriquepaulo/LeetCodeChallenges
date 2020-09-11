using System;

namespace ImageOverlap
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int LargestOverlap(int[][] A, int[][] B)
        {
            int MAXOverlaps = 0;

            for (int shiftOnYaxis = 0; shiftOnYaxis < A.Length; shiftOnYaxis++)
                for (int shiftOnXAxis = 0; shiftOnXAxis < A.Length; shiftOnXAxis++)
                {
                    MAXOverlaps = Math.Max(MAXOverlaps, CountOverlaps(A, B, shiftOnXAxis, shiftOnYaxis));
                    MAXOverlaps = Math.Max(MAXOverlaps, CountOverlaps(B, A, shiftOnXAxis, shiftOnYaxis));
                }

            return MAXOverlaps;
        }

        private int CountOverlaps(int[][] matrix1, int[][] matrix2, int shiftOnXaxis, int shiftOnYaxis)
        {
            if (matrix1 == null || matrix2 == null || matrix1.Length == 0 || matrix2.Length == 0)
            {
                return 0;
            }
            int matrix2Row = 0;
            int counter = 0;
            for (int matrix1Row = shiftOnYaxis; matrix1Row < matrix1.Length; ++matrix1Row)
            {
                int matrix2Col = 0;
                for (int matrix1Col = shiftOnXaxis; matrix1Col < matrix1.Length; ++matrix1Col)
                {
                    if (matrix1[matrix1Row][matrix1Col] == 1 && matrix1[matrix1Row][matrix1Col] == matrix2[matrix2Row][matrix2Col])
                        counter += 1;
                    matrix2Col += 1;
                }
                matrix2Row += 1;
            }
            return counter;
        }
    }
}
