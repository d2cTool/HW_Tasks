using System.Collections.Generic;

namespace DelegatesConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] m = { { 1 }, { 2 } };
            int[,] mm = { { 25, 22 }, { 10, 16 } };
            int[,] mas = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };

            var comp = Comparer<int>.Create((x, y) => x.CompareTo(y));

            BubbleSorter bubbleSorter = new BubbleSorter(m, comp);

            bubbleSorter.Sort(mm, comp);


        }
    }
}
