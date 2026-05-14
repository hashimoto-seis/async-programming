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
                await Task.Run(() => 
                {
                    throw new FormatException("test.");
                });
            }
            catch (FormatException e)
            {
                Console.WriteLine($"catch: {e.GetType().Name} - {e.Message}");
            }
        }
    }
}
