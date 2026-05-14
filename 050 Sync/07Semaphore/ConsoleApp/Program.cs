using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        private static readonly Semaphore SampleSem = new Semaphore(1, 1);
        private static int Counter = 0;

        private static void Method()
        {
            for (int i = 0; i < 1024; i++)
            {
                SampleSem.WaitOne();    // 待機
                Counter++;
                Thread.Sleep(0);
                SampleSem.Release();    // 解放
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
