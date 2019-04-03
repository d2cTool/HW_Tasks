using System;
using System.Collections.Generic;

namespace MyFirstLib
{
    public class CommonClass
    {
        public static int BinarySearch<T>(T[] sortedArray, T element) where T : IComparable<T>
        {
            int low = 0;
            int high = sortedArray.Length;
            int mid = 0;

            if (high == 0)
                return -1;

            while (low < high)
            {
                mid = low + (high - low) / 2;

                if (element.CompareTo(sortedArray[mid]) == 0)
                    return mid;

                if (element.CompareTo(sortedArray[mid]) > 0)
                    low = mid + 1;
                else
                    high = mid;
            }

            return -1;
        }

        public static IEnumerable<int> FibonacciCalc(int count)
        {
            int prev = -1;
            int next = 1;
            for (int i = 0; i < count; i++)
            {
                int sum = prev + next;
                prev = next;
                next = sum;
                yield return sum;
            }
        }
    }
}
