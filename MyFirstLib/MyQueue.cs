using System;
using System.Collections;
using System.Collections.Generic;

namespace MyFirstLib
{
    /// <summary>
    /// Represents a first-in, first-out collection of the same specified type.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the queue.</typeparam>
    public class MyQueue<T> : IEnumerable<T>
    {
        private Node<T> first;
        private Node<T> last;
        private int count;

        public int Count => count;
        public bool IsEmpty => count == 0;

        /// <summary>
        /// Initializes a new instance of the MyQueue class.
        /// </summary>
        public MyQueue() { }

        /// <summary>
        /// Initializes a new instance of the MyQueue class that contains
        /// elements copied from the specified collection
        /// </summary>
        /// <param name="collection">The System.Collections.ICollection to copy elements from.</param>
        public MyQueue(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Enqueue(item);
            }
        }

        /// <summary>
        /// Adds an object to the end of the MyQueue.
        /// </summary>
        /// <param name="element">The object to add to the MyQueue. The value can be null.</param>
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

        /// <summary>
        /// Removes and returns the object at the beginning of the MyQueue.
        /// </summary>
        /// <returns>The object that is removed from the beginning of the MyQueue.</returns>
        public T Dequeue()
        {
            if (count == 0)
                throw new InvalidOperationException();

            T current = first.Element;
            first = first.Next;
            count--;
            return current;
        }
        /// <summary>
        /// Returns an enumerator that iterates through the MyQueue.
        /// </summary>
        /// <returns>An System.Collections.IEnumerator for the MyQueue.</returns>
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
