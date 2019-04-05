using System;
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
            bubbleSorter.Print(mas);

            MyCounter myCounter = new MyCounter();

            Worker worker1 = new Worker(myCounter, 1000);
            Worker worker2 = new Worker(myCounter, 1000);
            Worker worker3 = new Worker(myCounter, 1000);

            myCounter.Ready += MyCounter_Ready;
            myCounter.Start(5000);
            myCounter.Start(5000);
            myCounter.Start(5000);
            Console.ReadLine();
        }

        private static void MyCounter_Ready(object sender, EventArgs e)
        {
            Console.WriteLine("Counter ready.");
        }
    }
}
