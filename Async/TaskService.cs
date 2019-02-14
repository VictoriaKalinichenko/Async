using System;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    public class TaskService
    {
        public void GetFactorial(int factorial)
        {
            Console.WriteLine($"Thread({Thread.CurrentThread.ManagedThreadId}) started ({factorial})");
            for (int iteration = 1; iteration <= factorial; iteration++)
            {
                Console.WriteLine($"Thread({Thread.CurrentThread.ManagedThreadId}) iteration: {iteration} ({factorial})");
                Thread.Sleep(200);
            }
            Console.WriteLine($"Thread({Thread.CurrentThread.ManagedThreadId}) is completed ({factorial})");
        }
        
        public Task GetFactorialTask(int factorial)
        {
            return new Task(() =>
            {
                Console.WriteLine($"Thread({Thread.CurrentThread.ManagedThreadId}) started ({factorial})");
                for (int iteration = 1; iteration <= factorial; iteration++)
                {
                    Console.WriteLine($"Thread({Thread.CurrentThread.ManagedThreadId}) iteration: {iteration} ({factorial})");
                    Thread.Sleep(200);
                }
                Console.WriteLine($"Thread({Thread.CurrentThread.ManagedThreadId}) is completed ({factorial})");
            });
        }

        public void GetFactorial(object state)
        {
            var threadState = (ThreadState)state;

            Console.WriteLine($"Thread({Thread.CurrentThread.ManagedThreadId}) started ({threadState.Factorial})");
            for (int iteration = 1; iteration <= threadState.Factorial; iteration++)
            {
                Console.WriteLine($"Thread({Thread.CurrentThread.ManagedThreadId}) iteration: {iteration} ({threadState.Factorial})");
                Thread.Sleep(200);
            }
            Console.WriteLine($"Thread({Thread.CurrentThread.ManagedThreadId}) is completed ({threadState.Factorial})");
            threadState.WaitHandle.Set();
        }
    }
}
