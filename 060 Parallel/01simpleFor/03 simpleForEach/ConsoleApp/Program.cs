using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            const int Count = 8;
            int[] a = Enumerable.Range(1, Count).ToArray();

            Parallel.ForEach(a, c =>
            {
                Console.Write("{0,3:d}", c * 2);
            });
        }
    }
}
