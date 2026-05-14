using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            Task<int> task = Task.Run(new Func<int>(() =>
            {
                throw new FormatException("test.");
                return -10;
            }));

            try
            {
                Console.WriteLine("\nreturn code = {0}.", task.Result);
            }
            catch (AggregateException e)
            {
                Console.WriteLine($"{e.GetType().Name} - {e.Message}");
                foreach (Exception it in e.InnerExceptions)
                    Console.WriteLine($"  {it.GetType().Name} - {it.Message}");
            }
        }
    }
}
