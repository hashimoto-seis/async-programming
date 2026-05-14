using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            var cts = new CancellationTokenSource();
            var po = new ParallelOptions
            {
                CancellationToken = cts.Token
            };

            Task.Run(() =>  // Launch the task of canceling the loop
            {
                Thread.Sleep(100);
                cts.Cancel();
            });

            try
            {
                Parallel.For(0, 1024, po, (i) =>
                {
                    Thread.Sleep(10);
                    Console.WriteLine("i={0,3}, ThreadID={1,1}",
                                i, Thread.CurrentThread.ManagedThreadId);
                    po.CancellationToken.ThrowIfCancellationRequested();
                });
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine("OperationCanceledException occurs, " + e.Message);
            }
            Console.WriteLine("end of Program.");
        }
    }
}
