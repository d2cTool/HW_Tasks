using System;
using System.Collections.Generic;

namespace DelegatesConsoleApp
{
    public static class BubbleSorter
    {
        public static void Sort(int[,] matrix, IComparer<int> rowComparer, Func<int[], int> matrixRowAggregator, bool isAscending = true)
        {
            if (!IsValid(matrix))
                throw new ArgumentException("Invalid matrix", "matrix");

            if(rowComparer == null)
                throw new ArgumentException("Invalid row comparer", "rowComparer");

            if (matrixRowAggregator == null)
                throw new ArgumentException("Invalid matrix row aggregate function", "matrixRowAggregator");

            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            int[] rows = new int[rowLength];

            for (int i = 0; i < rowLength; i++)
            {
                int[] row = new int[colLength];
                for (int j = 0; j < colLength; j++)
                {
                    row[j] = matrix[i, j];
                }

                rows[i] = matrixRowAggregator(row);
            }

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    int comp;
                    if (isAscending)
                        comp = rowComparer.Compare(rows[i], rows[j]);
                    else
                        comp = rowComparer.Compare(rows[j], rows[i]);

                    if (comp > 0)
                    {
                        SwapRows(matrix, i, j);
                        int tmp = rows[i];
                        rows[i] = rows[j];
                        rows[j] = tmp;
                    }
                }
            }
        }

        public static void SwapRows(int[,] matrix, int i, int j)
        {
            var intSize = sizeof(int);
            var colLength = matrix.GetLength(1);

            var temp = new int[colLength];

            Buffer.BlockCopy(matrix, i * intSize * colLength, temp, 0, colLength * intSize);
            Buffer.BlockCopy(matrix, j * colLength * intSize, matrix, i * intSize * colLength, colLength * intSize);
            Buffer.BlockCopy(temp, 0, matrix, j * colLength * intSize, colLength * intSize);
        }


        public static bool IsValid(int[,] matrix)
        {
            if (matrix.Rank != 2)
                return false;

            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            if (rowLength < 1 || colLength < 1)
                return false;

            return true;
        }

        public static void Print(int[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0,4} ", matrix[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
    }
}

