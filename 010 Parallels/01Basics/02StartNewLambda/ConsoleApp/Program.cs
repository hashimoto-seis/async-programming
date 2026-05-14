using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            Task.Factory.StartNew(() => {
                for (int i = 0; i < 1024; i++)
                {
                    Console.Write("1");
                }
            });
            for (int i = 0; i < 1024; i++)
            {
                Console.Write("2");
            }
        }
    }
}
