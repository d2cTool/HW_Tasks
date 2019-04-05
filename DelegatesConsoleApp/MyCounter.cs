using System;
using System.Threading;

namespace DelegatesConsoleApp
{
    public class MyCounter
    {
        private bool started = false;
        public event EventHandler Ready;

        public void Start(int delay)
        {
            if(!started)
            {
                started = true;
                Thread.Sleep(delay);
                Ready?.Invoke(this, EventArgs.Empty);
                started = false;
            }
        }
    }

    public class Worker
    {
        private MyCounter counter;
        private int timeout;
        public Worker(MyCounter counter, int timeout)
        {
            this.counter = counter;
            this.timeout = timeout;
            counter.Ready += Counter_Ready;
        }

        private void Counter_Ready(object sender, EventArgs e)
        {
            Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}, counter ready.");
        }

        public void Start()
        {
            counter.Start(timeout);
            Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}, start counter.");
        }
    }
}
