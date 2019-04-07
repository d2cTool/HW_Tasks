using MyFirstLib;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 1, 2, 3, 4 };
            int[] arr2 = { 3, 1, 2, 6, 4 };

            Console.WriteLine(CommonClass.BinarySearch(arr1, 1));
            Console.WriteLine(CommonClass.BinarySearch(arr1, 3));

            Print(CommonClass.FibonacciCalc(-1));
            Print(CommonClass.FibonacciCalc(0));
            Print(CommonClass.FibonacciCalc(1));
            Print(CommonClass.FibonacciCalc(2));
            Print(CommonClass.FibonacciCalc(12));

            Console.WriteLine("Set operations:");
            MySet<int> set = new MySet<int>(arr1);
            Console.WriteLine(set.Contain(1));
            set.Add(0);
            Print(set);
            set.Remove(2);
            Print(set);
            set.Clear();

            Console.WriteLine("Queue operations:");
            MyQueue<int> queue = new MyQueue<int>(arr1);
            Console.WriteLine(queue.IsEmpty);
            queue.Enqueue(0);
            Print(queue);
            Console.WriteLine(queue.Dequeue());
            Print(queue);
            Console.WriteLine(queue.Count);

            Console.WriteLine("Stack operations:");
            MyStack<int> stack = new MyStack<int>(arr1);
            Console.WriteLine(stack.Peek());
            stack.Push(0);
            Print(stack);
            Console.WriteLine(stack.Pop());
            Print(stack);
        }

        static void Print<T>(IEnumerable<T> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
