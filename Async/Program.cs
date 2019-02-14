using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        private readonly static TaskService _taskService = new TaskService();
        static List<ThreadState> threadStates = new List<ThreadState>
        {
            new ThreadState() { Factorial = 4 },
            new ThreadState() { Factorial = 5 }
        };

        static void Main(string[] args)
        {
            //ExecuteInAsyncMode();
            ExecuteThreadPool();
            //ExecuteParallels();
            Console.ReadKey();
        }

        static async void ExecuteInAsyncMode()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("Started");

            Task task = _taskService.GetFactorialTask(5);
            task.Start();

            _taskService.GetFactorial(4);

            await task;
            Console.WriteLine("All threads are completed");

            timer.Stop();
            Console.WriteLine($"Elapsed time for executing methods in async mode = {timer.ElapsedMilliseconds}");
            Console.WriteLine();
        }

        static void ExecuteThreadPool()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("Started");

            var waitCallback = new WaitCallback(_taskService.GetFactorial);
            ThreadPool.QueueUserWorkItem(new WaitCallback(_taskService.GetFactorial), threadStates[0]);
            ThreadPool.QueueUserWorkItem(new WaitCallback(_taskService.GetFactorial), threadStates[1]);
            WaitHandle.WaitAll(threadStates.Select(state => state.WaitHandle).ToArray());

            Console.WriteLine("All threads are completed");
            timer.Stop();
            Console.WriteLine($"Elapsed time for executing methods in async mode = {timer.ElapsedMilliseconds}");
        }

        static void ExecuteParallels()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("Started");

            Parallel.For(4, 6, iteration => _taskService.GetFactorial(iteration));
            Console.WriteLine("All threads are completed");

            timer.Stop();
            Console.WriteLine($"Elapsed time for executing methods in async mode = {timer.ElapsedMilliseconds}");
        }
    }
}
