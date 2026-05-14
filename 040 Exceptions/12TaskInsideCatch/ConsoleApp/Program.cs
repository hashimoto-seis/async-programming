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
                    try
                    {
                        throw new FormatException("test.");
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine($"inside:{e.GetType().Name} - {e.Message}");
                    }
                });
                //Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine($"catch: {e.GetType().Name} - {e.Message}");
            }
            Console.WriteLine("Done.");
        }
    }
}
