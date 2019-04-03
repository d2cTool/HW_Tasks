﻿namespace MyFirstLib
{
    public class MyNode<T>
    {
        public T Element { get; set; }
        public MyNode<T> Next { get; set; }
        public bool HasNext => (Next != null);
        public MyNode(T element)
        {
            Element = element;
        }
    }
}
