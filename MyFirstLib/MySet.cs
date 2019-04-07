using System;
using System.Collections;
using System.Collections.Generic;

namespace MyFirstLib
{
    /// <summary>
    /// Represents a set of values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the set.</typeparam>
    public class MySet<T> : IEnumerable<T> where T : IEquatable<T>
    {
        private T[] collection;
        private const int initSize = 64;
        private int count;
        public int Count => count;
        public bool IsEmpty => count == 0;
        /// <summary>
        /// Initializes a new instance of the MySet class
        /// </summary>
        public MySet()
        {
            collection = new T[initSize];
        }
        /// <summary>
        /// Initializes a new instance of the MySet class
        /// </summary>
        /// <param name="elements">The collection whose elements are copied to the new set.</param>
        public MySet(IEnumerable<T> elements)
        {
            collection = new T[initSize];

            foreach (var item in elements)
            {
                Add(item);
            }
        }
        /// <summary>
        /// Adds the specified element to a set.
        /// </summary>
        /// <param name="element">The element to add to the set.</param>
        /// <returns>
        /// true if the element is added to the MySet object;
        /// false if the element is already present.</returns>
        public bool Add(T element)
        {
            if (!Contain(element))
            {
                if (count == collection.Length)
                    Resize(collection.Length + collection.Length);

                collection[count++] = element;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Removes the specified element from a MySet object.
        /// </summary>
        /// <param name="element">The element to remove.</param>
        public void Remove(T element)
        {
            int index = Index(element);
            if (index != -1)
            {
                T[] dest = new T[collection.Length];
                if (index > 0)
                    Array.Copy(collection, 0, dest, 0, index);

                if (index < collection.Length - 1)
                    Array.Copy(collection, index + 1, dest, index, collection.Length - index - 1);

                collection = dest;
                count--;
            }
        }
        /// <summary>
        /// Removes all elements from a MySet object.
        /// </summary>
        public void Clear()
        {
            collection = new T[initSize];
            count = 0;
        }
        /// <summary>
        /// Determines whether a MySet object contains the specified element.
        /// </summary>
        /// <param name="element">The element to locate in the MySet object.</param>
        /// <returns>true if the MySet object contains the specified element; otherwise, false.</returns>
        public bool Contain(T element)
        {
            if (Index(element) != -1)
                return true;
            return false;
        }
        /// <summary>
        /// Returns an enumerator that iterates through a MySet object.
        /// </summary>
        /// <returns>An System.Collections.IEnumerator for the MySet.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        private int Index(T element)
        {
            for (int i = 0; i < count; i++)
            {
                if (element.Equals(collection[i]))
                    return i;
            }
            return -1;
        }

        private void Resize(int size)
        {
            T[] tempItems = new T[size];
            for (int i = 0; i < count; i++)
                tempItems[i] = collection[i];
            collection = tempItems;
        }
    }
}
