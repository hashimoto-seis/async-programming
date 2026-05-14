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
                Console.WriteLine("i={0,3},  tId={1,2}",
                    i, Thread.CurrentThread.ManagedThreadId);

                if (i == 10)
                    state.Break();

                if (state.LowestBreakIteration != null) // チェックを行う
                {
                    if (i >= state.LowestBreakIteration)
                    {
                        Console.WriteLine("*return*: {0,3} >= {1}",
                            i, state.LowestBreakIteration);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("i={0,3},  tId={1,2}: continue",
                            i, Thread.CurrentThread.ManagedThreadId);
                    }
                }
                // 処理
            });
        }
    }
}
