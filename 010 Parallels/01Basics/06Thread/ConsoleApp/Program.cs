using System;
using System.Threading;

namespace ConsoleApp
{
    internal class Program
    {
        private static void WriteOne()
        {
            for (int i = 0; i < 1024; i++) Console.Write("1");
        }

        static void Main(string[] _)
        {
            //Thread t = new Thread(new ThreadStart(WriteOne));
            var t = new Thread(WriteOne);
            t.Start();         // start worker thread.

            for (int i = 0; i < 1024; i++)
            {
                Console.Write("2");
            }
        }
    }
}
