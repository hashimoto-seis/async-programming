using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            Task<int> task = Task.Run(new Func<int>(() =>
            //var task = Task.Run(new Func<int>(() =>
            //Task<int> task = Task.Run((() =>
            {
                var sum = 0;
                for (int i = 0; i < 16; i++)
                {
                    sum += i;
                    Console.Write($"{i}+");
                }
                Console.Write("\b \b");
                return sum;
            }));
            Console.WriteLine($" = {task.Result}.");
        }
    }
}
