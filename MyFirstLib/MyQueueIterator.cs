using System;

namespace MyFirstLib
{
    public class MyQueueIterator<T> : IIterator<T>
    {
        MyQueue<T> queue;
        MyNode<T> current;

        public MyQueueIterator(MyQueue<T> queue)
        {
            this.queue = queue;
        }

        public bool IsDone => throw new NotImplementedException();

        T IIterator<T>.Current => throw new NotImplementedException();

        public T First()
        {
            throw new NotImplementedException();
        }

        public T Next()
        {
            throw new NotImplementedException();
        }
    }
}
