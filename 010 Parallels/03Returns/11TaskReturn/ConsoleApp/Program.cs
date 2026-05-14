using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] _)
        {
            string str = await Method();
            Console.WriteLine($"{str}");
        }

        private static async Task<string> Method()
        {
            await Task.Delay(5000);
            return "messages";
        }
    }
}
