using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        private static void WriteOne(String msg)
        {
            for (int i = 0; i < 1024; i++)
            {
                Console.Write(msg);
            }
        }

        static void Main(string[] _)
        {
            Task.Run(() => WriteOne("1"));
            WriteOne("2");
        }
    }
}
