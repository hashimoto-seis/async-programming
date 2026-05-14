using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            Parallel.Invoke(() =>
            {
                Thread.Sleep(1);
                Console.WriteLine("Parallel.Invoke-0");
            },
            () =>
            {
                Thread.Sleep(1);
                Console.WriteLine("Parallel.Invoke-1");
            }
            );
            Console.WriteLine("Done.");
        }
    }
}
