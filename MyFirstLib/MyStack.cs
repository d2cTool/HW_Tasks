using System;
using System.Collections;
using System.Collections.Generic;

namespace MyFirstLib
{
    public class MyStack<T> : IEnumerable<T>
    {
        Node<T> top;

        public MyStack() { }

        public MyStack(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Push(item);
            }
        }

        public T Peek()
        {
            if (top == null)
                throw new InvalidOperationException();
            return top.Element;
        }

        public void Push(T element)
        {
            Node<T> node = new Node<T>(element)
            {
                Next = top
            };
            top = node;
        }

        public T Pop()
        {
            if (top == null)
                throw new InvalidOperationException();
            Node<T> temp = top;
            top = top.Next;
            return temp.Element;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = top;
            while (current.HasNext)
            {
                yield return current.Element;
                current = current.Next;
            }
        }
    }
}
