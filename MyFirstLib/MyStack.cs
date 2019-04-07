using System;
using System.Collections;
using System.Collections.Generic;

namespace MyFirstLib
{
    /// <summary>
    /// Represents a simple last-in-first-out (LIFO) non-generic collection of the same specified type.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the stack.</typeparam>
    public class MyStack<T> : IEnumerable<T>
    {
        private Node<T> top;
        /// <summary>
        /// Initializes a new instance of the MyStack class.
        /// </summary>
        public MyStack() { }
        /// <summary>
        /// Initializes a new instance of the MyStack class that
        /// contains elements copied from the specified collection.
        /// </summary>
        /// <param name="collection">The collection to copy elements from.</param>
        public MyStack(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Push(item);
            }
        }
        /// <summary>
        /// Returns the object at the top of the MyStack without removing it.
        /// </summary>
        /// <returns>The object at the top of the MyStack.</returns>
        /// <exception cref="InvalidOperationException">Thrown when MyStack is empty.
        /// </exception>
        public T Peek()
        {
            if (top == null)
                throw new InvalidOperationException();
            return top.Element;
        }
        /// <summary>
        /// Inserts an object at the top of the MyStack.
        /// </summary>
        /// <param name="element">The object to push onto the MyStack.</param>
        public void Push(T element)
        {
            Node<T> node = new Node<T>(element)
            {
                Next = top
            };
            top = node;
        }
        /// <summary>
        /// Removes and returns the object at the top of the MyStack.
        /// </summary>
        /// <returns>The object removed from the top of the MyStack.</returns>
        /// /// <exception cref="InvalidOperationException">Thrown when MyStack is empty.
        /// </exception>
        public T Pop()
        {
            if (top == null)
                throw new InvalidOperationException();
            Node<T> temp = top;
            top = top.Next;
            return temp.Element;
        }

        /// <summary>
        /// Returns an enumerator for the MyStack.
        /// </summary>
        /// <returns>An System.Collections.IEnumerator for the MyStack.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = top;
            while (current.HasNext)
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
