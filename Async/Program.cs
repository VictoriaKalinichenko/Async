using System;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        private readonly static TaskService _taskService = new TaskService();

        static void Main(string[] args)
        {
            ExecuteTasks();
            ExecuteThreads();
            ExecuteParallels();
        }

        static void ExecuteTasks()
        {
            Task firstTask = Task.Factory.StartNew(() => _taskService.GetFactorial(13));
            Task secondTask = Task.Factory.StartNew(() => _taskService.GetFactorial(10));
            Task thirdTask = Task.Factory.StartNew(() => _taskService.GetFactorial(15));
            Task fourthTask = Task.Factory.StartNew(() => _taskService.GetFactorial(5));

            Task.WaitAll(firstTask, secondTask, thirdTask, fourthTask);
            Console.WriteLine("All threads are completed");

            Console.ReadKey();
            Console.WriteLine();
        }

        static void ExecuteThreads()
        {
            Thread firstThread = new Thread(() => _taskService.GetFactorial(13));
            Thread secondThread = new Thread(() => _taskService.GetFactorial(10));
            Thread thirdThread = new Thread(() => _taskService.GetFactorial(15));
            Thread fourthThread = new Thread(() => _taskService.GetFactorial(5));

            firstThread.Start();
            secondThread.Start();
            thirdThread.Start();
            fourthThread.Start();

            firstThread.Join();
            secondThread.Join();
            thirdThread.Join();
            fourthThread.Join();
            Console.WriteLine("All threads are completed");

            Console.ReadKey();
            Console.WriteLine();
        }

        static void ExecuteParallels()
        {
            int firstIteration = 11;
            int lastIteration = 15;

            Parallel.For(firstIteration, lastIteration, iteration => _taskService.GetFactorial(iteration));
            Console.WriteLine("All threads are completed");

            Console.ReadKey();
        }
    }
}
