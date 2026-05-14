using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            var msg = "1";
            Task.Factory.StartNew(() => proc(msg));

            Thread.Sleep(1);
            msg = "0";
            proc("2");
        }

        private static void proc(object param)
        {
            for (int i = 0; i < 1024; i++)
            {
                Console.Write(param);
            }
        }
    }
}
