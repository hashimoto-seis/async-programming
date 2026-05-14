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
                var t1 = Task.Run(() =>
                {
                    throw new ArgumentException("t1.");
                });
                var t2 = Task.Run(() =>
                {
                    throw new FormatException("t2.");
                });
                var t3 = Task.Run(() =>
                {
                    throw new IndexOutOfRangeException("t3.");
                });
                var t4 = Task.Run(() =>
                {
                    throw new OverflowException("t4.");
                });

                await Task.WhenAll(t4, t3, t2, t1);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType().Name} - {e.Message}");
            }
        }
    }
}
