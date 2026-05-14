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
            var c = new int[a.Length];

            Parallel.For(0, a.Length, i =>
            {
                c[i] = a[i] * 2;
            });
            foreach (int it in c)
                Console.Write("{0,3:d}", it);
        }
    }
}

