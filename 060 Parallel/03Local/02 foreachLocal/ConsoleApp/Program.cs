using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
            Parallel.ForEach<int, int>(a,
                                    () => 0,            // スレッドローカルの初期化
                        (n, loopState, localSum) =>     // body
                        {
                            localSum += n;
                            return localSum;
                        },
                (localSum) =>                           // 最後のアクション
                {
                    Interlocked.Add(ref sum, localSum);
                }
            );
            return sum;
        }
    }
}
