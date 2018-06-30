using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskApi
{
    static class Tasks
    {
        public static void RunParallelFor(int maximumParallelism = Int32.MaxValue, CancellationToken token = new CancellationToken(), TaskScheduler scheduler = null)
        {

            var options = new ParallelOptions { CancellationToken = token, MaxDegreeOfParallelism = maximumParallelism, TaskScheduler = scheduler };
            var resut = Parallel.For(0, 1000, options, (i, loopState) =>
           {
               if (loopState.ShouldExitCurrentIteration || loopState.IsStopped || loopState.IsExceptional)
                   return;

               if (i == 500)
               {
                   loopState.Break();
               }

               i++;
           });

            Console.WriteLine($"Loop completion status:  {resut.IsCompleted}\nLoop's lowest break iteration: {resut.LowestBreakIteration}");
        }

        public static void RunParallelForEach()
        {
            // The sum of these elements is 40.
            int[] input = { 4, 1, 6, 2, 9, 5, 10, 3 };
            int sum = 0;

            try
            {
                Parallel.ForEach(
                        input,                          // source collection
                        () => 0,                            // thread local initializer
                        (n, loopState, localSum) =>     // body
                        {
                            localSum += n;
                            Console.WriteLine("Thread={0}, n={1}, localSum={2}", Thread.CurrentThread.ManagedThreadId, n, localSum);
                            return localSum;
                        },
                        (localSum) =>
                        {
                            Interlocked.Add(ref sum, localSum);
                        }// thread local aggregator
                    );

                Console.WriteLine("\nSum={0}", sum);
            }
            // No exception is expected in this example, but if one is still thrown from a task,
            // it will be wrapped in AggregateException and propagated to the main thread.
            catch (AggregateException e)
            {
                Console.WriteLine("Parallel.ForEach has thrown an exception. THIS WAS NOT EXPECTED.\n{0}", e);
            }
        }

        public static void RunParallelInvoke()
        {
            try
            {
                Parallel.Invoke(
                    BasicAction,	// Param #0 - static method
                    () =>			// Param #1 - lambda expression
                    {
                        Console.WriteLine("Method=beta, Thread={0}", Thread.CurrentThread.ManagedThreadId);
                    },
                    delegate ()		// Param #2 - in-line delegate
                    {
                        Console.WriteLine("Method=gamma, Thread={0}", Thread.CurrentThread.ManagedThreadId);
                    }
                );
            }
            // No exception is expected in this example, but if one is still thrown from a task,
            // it will be wrapped in AggregateException and propagated to the main thread.
            catch (AggregateException e)
            {
                Console.WriteLine("An action has thrown an exception. THIS WAS UNEXPECTED.\n{0}", e.InnerException.ToString());
            }
        }

        static void BasicAction()
        {
            Console.WriteLine("Method=alpha, Thread={0}", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
