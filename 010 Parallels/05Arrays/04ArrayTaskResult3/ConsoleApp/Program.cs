using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            Task<Int32>[] Ats = new Task<Int32>[10];

            var total = 0;
            for (int i = 0; i < Ats.Length; i++)
            {
                Ats[i] = Task.Run(() => Interlocked.Increment(ref total));
            }

            for (int i = 0; i < Ats.Length; i++)
                Console.WriteLine($"Result[{i}] = {Ats[i].Result}.");
            Console.WriteLine($"total = {total}.");
        }
    }
}
