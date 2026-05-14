using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        private static readonly Mutex SampleMu = new Mutex(false, "test");
        private static int Counter = 0;

        private static void Method()
        {
            for (int i = 0; i < 1024; i++)
            {
                SampleMu.WaitOne();        // 待機
                Counter++;
                Thread.Sleep(0);
                SampleMu.ReleaseMutex();   // 解放
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
