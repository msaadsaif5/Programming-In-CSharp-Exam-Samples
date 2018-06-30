using System;
using System.Diagnostics;
using System.Threading;

namespace ThreadPoolApi
{
    class Program
    {
        static void Main(string[] args)
        {
            //Queue work item
            bool queued = ThreadPool.QueueUserWorkItem(ThreadMethod, "Hello world!");
            Debug.Assert(queued);

            //Test Register Wait For Single Object
            var autoResetEvent = new AutoResetEvent(false);
            RegisterWaitHandle(autoResetEvent);

            Thread.Sleep(3100);
            autoResetEvent.Set();

            //Check Max min threads
            ThreadPool.GetMaxThreads(out int worker, out int io);
            Console.WriteLine($"Max worker threads: {worker}\nMaximum I/O threads: {io}");

            ThreadPool.GetMinThreads(out worker, out io);
            Console.WriteLine($"Min worker threads: {worker}\nMin I/O threads: {io}");

            ThreadPool.GetAvailableThreads(out worker, out io);
            Console.WriteLine($"Available worker threads: {worker}\nAvailable I/O threads: {io}");


            Console.ReadLine();
        }

        private static void RegisterWaitHandle(AutoResetEvent waitObject)
        {
            RegisteredWaitHandle registerWaitHandle = null;

            registerWaitHandle = ThreadPool.RegisterWaitForSingleObject(waitObject, new WaitOrTimerCallback(Callback), registerWaitHandle, 3000, true);

        }

        private static void Callback(object state, bool timedOut)
        {
            var waitHandle = (RegisteredWaitHandle)state;

            if (timedOut)
                Console.WriteLine("Wait handle callback has timed out");
            else
                Console.WriteLine($"Wait handle callback fired due to signal from wait handle!");

            waitHandle?.Unregister(null);
        }

        static void ThreadMethod(object state)
        {
            Console.WriteLine($"Hello from the thread. You sent {state?.ToString()}");
        }
    }
}
