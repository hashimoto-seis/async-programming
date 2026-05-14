using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        private static readonly AutoResetEvent aEvent = new AutoResetEvent(true);
        private static int Counter = 0;

        private static void Method()
        {
            for (int i = 0; i < 1024; i++)
            {
                aEvent.WaitOne(); // 待ち
                Counter++;
                Thread.Sleep(0);
                aEvent.Set();     // 解放
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
