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
                Task task1 = Task.Run(() =>
                {
                    throw new FormatException("test.");
                });

                task1.Wait();
            }
            catch (AggregateException e)
            {
                Console.WriteLine($"catch: {e.GetType().Name} - {e.Message}");

                foreach (Exception it in e.InnerExceptions)
                    Console.WriteLine($"{it.GetType().Name} - {it.Message}");
            }
        }
    }
}
