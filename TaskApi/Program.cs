using System;
using TaskApi;

namespace TaskLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executing Parallel For Each\n");
            Tasks.RunParallelForEach();

            Console.WriteLine("\nExecuting Parallel For\n");
            Tasks.RunParallelFor();

            Console.WriteLine("\nExecuting Parallel Invoke\n");
            Tasks.RunParallelInvoke();

            Console.ReadLine();
        }
    }
}
