using System;
using System.Diagnostics;
using System.Threading;

namespace Async
{
    public class TaskService
    {
        public void GetFactorial(int factorial)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            Console.WriteLine($"Thread({Thread.CurrentThread.ManagedThreadId}) started (Now:{DateTime.Now.ToLongTimeString()})");
            int result = 1;
            for (int iteration = 1; iteration <= factorial; iteration++)
            {
                result *= iteration;
                Console.WriteLine($"Thread({Thread.CurrentThread.ManagedThreadId}) iteration: {iteration} (Now:{DateTime.Now.ToLongTimeString()})");
                Thread.Sleep(100);
            }

            timer.Stop();
            TimeSpan timeSpan = timer.Elapsed;            
            var elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds,
                timeSpan.Milliseconds / 10);

            Console.WriteLine($"Thread({Thread.CurrentThread.ManagedThreadId}) Factorial of {factorial} = {result} (Now:{DateTime.Now.ToLongTimeString()}) Elapsed time: {elapsedTime}");
        }
    }
}
