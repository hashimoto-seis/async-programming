using System;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            const int Count = 8;
            int[] a = Enumerable.Range(1, Count).ToArray();
            var c = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                c[i] = a[i] * 2;
            }
            foreach(int it in c)
                Console.Write("{0,3:d}", it);
        }
    }
}
