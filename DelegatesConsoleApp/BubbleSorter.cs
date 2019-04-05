using System.Collections.Generic;

namespace DelegatesConsoleApp
{
    public class BubbleSorter
    {
        private readonly int[,] matrix;
        public BubbleSorter(int[,] matrix, IComparer<int> comparer, bool isAscending = true)
        {
            this.matrix = matrix;

            Comparer<int>.Create((x, y) => x.CompareTo(y));
        }

        public bool IsValid(int[,] matrix)
        {
            return true;
        }

        public void Sort(int[,] matrix, IComparer<int> comparer)
        {
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            if (comparer.Compare(matrix[i,j], matrix[x,y]) > 0)
                            {
                                int t = matrix[x,y];
                                matrix[x,y] = matrix[i,j];
                                matrix[i,j] = t;
                            }
                        }
                    }
                }
            }
        }
    }
}

