using System;
using System.Threading.Tasks;

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
            //var t = new Task(new Action(WriteOne));
            var t = new Task(WriteOne);    //省略形
            t.Start();
            for (int i = 0; i < 1024; i++)
            {
                Console.Write("2");
            }
        }
    }
}
