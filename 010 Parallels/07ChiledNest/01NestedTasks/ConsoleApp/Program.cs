using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] _)
        {
            var outer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Start the outer task.");

                var nested = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("  Start the inner task.");
                    Thread.SpinWait(5000000);
                    Console.WriteLine("  Inner task finished.");
                });

                Thread.SpinWait(1000000);
                Console.WriteLine("The outer task is about to finish.");
            });
            outer.Wait();
            Console.WriteLine("Outer task finished.");
        }
    }
}
