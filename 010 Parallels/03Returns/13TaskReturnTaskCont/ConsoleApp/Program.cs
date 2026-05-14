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

        private static Task<string> Method()
        {
            return Task.Delay(5000)
                    .ContinueWith(_ => "messages");
        }
    }
}
