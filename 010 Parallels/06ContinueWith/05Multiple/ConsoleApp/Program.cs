using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            var total = 0;

            Task<Int32>[] aT = new Task<Int32>[10];
            for (int i = 0; i < aT.Length; i++)
            {
                aT[i] = Task.Run(() => Interlocked.Increment(ref total));
            }
            Task cTask = Task.Factory.ContinueWhenAll(aT, cT =>
            {
                for (int i = 0; i < cT.Length; i++)
                    Console.WriteLine("Result[{0}] = {1}.", i, cT[i].Result);
                Console.WriteLine("total = {0}", total);
            });
            cTask.Wait();
        }
    }
}
