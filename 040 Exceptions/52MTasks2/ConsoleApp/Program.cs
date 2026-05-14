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
                    throw new ArgumentException("t1.");
                });
                await Task.Run(() =>
                {
                    throw new FormatException("t2.");
                });
                await Task.Run(() =>
                {
                    throw new IndexOutOfRangeException("t3.");
                });
                await Task.Run(() =>
                {
                    throw new OverflowException("t4.");
                });
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType().Name} - {e.Message}");
            }
        }
    }
}
