using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        private static readonly Object _lockObject = new Object();
        private static int Counter = 0;

        private static void Method()
        {
            for (int i = 0; i < 1024; i++)
            {
                lock (_lockObject)
                {
                    Counter++;
                    Thread.Sleep(0);
                }
            }
        }

        static void Main(string[] _)
        {
            Task task = Task.Run(Method);
            Method();
            task.Wait();

            Console.WriteLine($"Counter = {Counter}.");
        }
    }
}
