using System;
using System.Collections.Generic;

namespace MyFirstLib
{
    public class MyQueue<T>
    {
        MyNode<T> first;
        MyNode<T> last;
        public int Count { get; private set; }

        public MyQueue()
        {
            
        }

        public MyQueue(IEnumerable<T> collection)
        {

        }

        public void Enqueue(T element)
        {
            MyNode<T> node = new MyNode<T>(element);
            MyNode<T> tempNode = last;
            last = node;
            if (count == 0)
                first = last;
            else
                tempNode.Next = last;
            count++;
        }

        public T Dequeue()
        {
            if (count == 0)
                throw new InvalidOperationException();

            T current = first.Element;
            first = first.Next;
            count--;
            return current;
        }
    }
}
