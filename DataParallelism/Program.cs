using System;

namespace DataParallelism
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executing Parallel For Each\n");
            ParallelSample.RunParallelForEach();

            Console.WriteLine("\nExecuting Parallel For\n");
            ParallelSample.RunParallelFor();

            Console.WriteLine("\nExecuting Parallel Invoke\n");
            ParallelSample.RunParallelInvoke();

            Console.ReadLine();
        }
    }
}
