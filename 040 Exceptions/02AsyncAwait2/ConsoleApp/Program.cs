using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] _)
        {
            try
            {
                await Task.Run(Task1);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"catch: {e.GetType().Name} - {e.Message}");
            }
        }

        static Task Task1()
        {
            throw new FormatException("test.");
        }
    }
}
