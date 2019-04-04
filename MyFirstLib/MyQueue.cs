using System;
using System.Collections;
using System.Collections.Generic;

namespace MyFirstLib
{
    public class MyQueue<T> : IEnumerable<T>
    {
        Node<T> first;
        Node<T> last;
        int count;

        public int Count => count;
        public bool IsEmpty => count == 0;

        public MyQueue() { }

        public MyQueue(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Enqueue(item);
            }
        }

        public void Enqueue(T element)
        {
            Node<T> node = new Node<T>(element);
            Node<T> tempNode = last;
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

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = first;
            while (current != null)
            {
                yield return current.Element;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
