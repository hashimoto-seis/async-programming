using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        private static int Add(int[] la, int start, int length)
        {
            var lSum = 0;
            for (int i = start; i < start + length; i++)
            {
                lSum += la[i];
            }
            return lSum;
        }

        static void Main(string[] _)
        {
            const int ArrayLength = 4096;
            int[] a = Enumerable.Range(1, ArrayLength).ToArray();

            Task<int>[] Ats = new Task<int>[4];
            int Elength = a.Length / Ats.Length;
            for (int i = 0; i < Ats.Length; i++)
            {
                int Start = Elength * i;
                Ats[i] = Task<int>.Run(() => Add(a, Start, Elength));
            }
            //var Ssum = a.Sum();
            var Ssum = Add(a, 0, a.Length);

            var Psum = 0;
            for (int i = 0; i < Ats.Length; i++)
            {
                Psum += Ats[i].Result;
            }
            Console.WriteLine($"Ssum = {Ssum}.");
            Console.WriteLine($"Psum = {Psum}.");
        }
    }
}
