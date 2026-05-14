using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] _)
        {
            var pTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Parent task started.");

                var cTask = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine(" Child task started.");
                    for (int i = 0; i < 1000; i++)
                        Thread.SpinWait(200);
                    Console.WriteLine(" End of child task.");
                }, TaskCreationOptions.AttachedToParent);
            });
            pTask.Wait();
            Console.WriteLine("End of parent task.");
        }
    }
}
