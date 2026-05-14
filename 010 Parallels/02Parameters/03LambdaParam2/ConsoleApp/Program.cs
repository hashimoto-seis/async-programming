using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            string msg = "1";
            new Task((word) =>
            {
                for (int i = 0; i < 1024; i++)
                {
                    Console.Write(word);
                }
            }, msg).Start();

            Thread.Sleep(1);
            msg = "0";
            for (int i = 0; i < 1024; i++)
            {
                Console.Write("2");
            }
        }
    }
}
