using System;
using System.Collections.Generic;

namespace MyFirstLib
{
    public class CommonClass
    {
        /// <summary>
        /// Return index of element in the sorted array using binary search algorithm.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="sortedArray">Sorted array.</param>
        /// <param name="element">Element to search.</param>
        /// <returns>Index of element in array; otherwise, -1.</returns>
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
        /// <summary>
        /// Return collection of first n Fibonacci numbers.
        /// </summary>
        /// <param name="count">Number of elements.</param>
        /// <returns>Collection.</returns>
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
