using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            var po = new ParallelOptions
            {
                MaxDegreeOfParallelism = 10
            };

            Parallel.For(0, 64, po, i =>
            {
                Console.WriteLine("i={0,2}, ThreadId={1}",
                        i, Thread.CurrentThread.ManagedThreadId);
            });
        }
    }
}
