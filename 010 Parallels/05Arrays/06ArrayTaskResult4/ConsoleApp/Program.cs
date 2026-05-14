using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            Func<int[], int, int, int> Add = (int[] la, int start, int length) =>
            {
                var lSum = 0;
                for (int i = start; i < start + length; i++)
                {
                    lSum += la[i];
                }
                return lSum;
            };

            const int ArrayLength = 4096;
            int[] a = Enumerable.Range(1, ArrayLength).ToArray();

            var Elength = a.Length / 4;
            Task<int>[] Ats = {
                        Task<int>.Run(() => Add(a, Elength * 0, Elength)),
                        Task<int>.Run(() => Add(a, Elength * 1, Elength)),
                        Task<int>.Run(() => Add(a, Elength * 2, Elength)),
                        Task<int>.Run(() => Add(a, Elength * 3, Elength))
            };
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
