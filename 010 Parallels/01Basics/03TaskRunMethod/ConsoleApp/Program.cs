using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        private static void WriteOne()
        {
            for (int i = 0; i < 1024; i++)
            {
                Console.Write("1");
            }
        }

        static void Main(string[] _)
        {
            //Task.Run(new Action(WriteOne));
            Task.Run(WriteOne);
            for (int i = 0; i < 1024; i++)
            {
                Console.Write("2");
            }
        }
    }
}
