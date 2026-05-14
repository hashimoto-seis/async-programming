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
                var t = Task.WhenAll(t1, t2, t3, t4);
                t.Wait();
            }
            catch (AggregateException e)
            {
                Console.WriteLine($"{e.GetType().Name} - {e.Message}");
                foreach (Exception ex in e.InnerExceptions)
                    Console.WriteLine($"  {ex.GetType().Name} - {ex.Message}");
            }
        }
    }
}
