using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            const int DataLength = 1024;
            int[] a = Enumerable.Range(1, DataLength).ToArray();

            var Ssum = SumSequential(a);
            var Psum = SumParallel(a);

            Console.WriteLine($"sum by Sequential = {Ssum}");
            Console.WriteLine($"sum by Parallel   = {Psum}");
        }

        // Sequential
        private static int SumSequential(int[] a)
        {
            var sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
            }
            return sum;
        }

        // Parallel
        private static int SumParallel(int[] a)
        {
            var sum = 0;
            var rangePartitioner = Partitioner.Create(0, a.Length);
            Parallel.ForEach(rangePartitioner, (range, loopState) =>
            {
                Console.WriteLine("range = ({0,4},{1,4})", range.Item1, range.Item2 - 1);
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    sum += a[i];
                }
            });
            return sum;
        }
    }
}
