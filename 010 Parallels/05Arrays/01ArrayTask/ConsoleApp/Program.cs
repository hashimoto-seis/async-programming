using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            //Task[] ArrayTask = new Task[]
            Task[] ArrayTask = new[]
            {
                Task.Run(() => { Console.Write("0"); }),
                Task.Run(() => { Console.Write("1"); }),
                Task.Run(() => { Console.Write("2"); }),
            };
            Task.WaitAll(ArrayTask);
            //Task.WaitAny(ArrayTask);
        }
    }
}

