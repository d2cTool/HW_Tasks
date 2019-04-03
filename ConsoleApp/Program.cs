using MyFirstLib;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 1, 2, 1, 1 };
            Console.WriteLine(CommonClass.BinarySearch(arr, 1));
            Print(CommonClass.FibonacciCalc(-1));
            Print(CommonClass.FibonacciCalc(0));
            Print(CommonClass.FibonacciCalc(1));
            Print(CommonClass.FibonacciCalc(2));
        }

        private static void Print<T>(IEnumerable<T> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
