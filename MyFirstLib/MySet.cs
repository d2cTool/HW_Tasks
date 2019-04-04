using System;
using System.Collections;
using System.Collections.Generic;

namespace MyFirstLib
{
    public class MySet<T> : IEnumerable<T> where T : IEquatable<T>
    {
        private T[] collection;
        const int initSize = 64;
        int count;
        public bool IsEmpty => count == 0;

        public MySet()
        {
            collection = new T[initSize];
        }

        public MySet(IEnumerable<T> elements)
        {
            collection = new T[initSize];

            foreach (var item in elements)
            {
                Add(item);
            }
        }

        public void Add(T element)
        {
            if (!Contain(element))
            {
                if (count == collection.Length)
                    Resize(collection.Length + collection.Length);

                collection[count++] = element;
            }
        }

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

        public void Clear()
        {
            collection = new T[initSize];
            count = 0;
        }

        public bool Contain(T element)
        {
            if (Index(element) != -1)
                return true;
            return false;
        }

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
