using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            Parallel.For(0, 128, (i, state) =>
            {
                Console.WriteLine("i={0,3},  tId={1,2}, state.IsStopped={2}",
                        i, Thread.CurrentThread.ManagedThreadId, state.IsStopped);

                if (i == 10)
                    state.Stop();

                if (state.IsStopped)        // チェックを行う
                {
                    Console.WriteLine("i={0,3},  tId={1,2}, state.IsStopped={2}:[return]",
                        i, Thread.CurrentThread.ManagedThreadId, state.IsStopped);
                    return;
                }
            });
        }
    }
}
