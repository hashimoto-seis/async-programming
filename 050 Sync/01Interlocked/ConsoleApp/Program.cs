using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        private static int Counter = 0;

        static void Main(string[] _)
        {
            Task task = Task.Run(() =>
            {
                for (int i = 0; i < 1024; i++)
                {
                    //Counter++;
                    //Interlocked.Increment(ref Counter);
                    Counter++;
                    Thread.Sleep(0);
                }
            });

            for (int i = 0; i < 1024; i++)
            {
                //Counter++;
                //Interlocked.Increment(ref Counter);
                Counter++;
                Thread.Sleep(0);
            }

            task.Wait();
            Console.WriteLine($"Counter = {Counter}.");
        }
    }
}
