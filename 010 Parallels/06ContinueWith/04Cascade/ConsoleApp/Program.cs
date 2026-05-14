using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] _)
        {
            Task<String> task0 = Task.Run(() =>
            {
                return "task0";
            });
            Task<String> task1 = task0.ContinueWith((a) =>
            {
                return a.Result + " + task1";
            });
            Task<String> task2 = task1.ContinueWith((a) =>
            {
                return a.Result + " + task2";
            });
            Console.WriteLine(task2.Result);
        }
    }
}
