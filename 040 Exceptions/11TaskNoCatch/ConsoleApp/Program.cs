using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            try
            {
                Task.Run(() =>
                {
                    throw new FormatException("test.");
                });
            }
            catch (FormatException e)
            {
                Console.WriteLine($"catch: {e.GetType().Name} - {e.Message}");
            }
            Console.WriteLine("Done.");
        }
    }
}
