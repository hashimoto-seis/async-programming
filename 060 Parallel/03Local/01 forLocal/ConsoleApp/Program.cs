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
            Parallel.For(0, a.Length,
                                    () => 0,            // スレッドローカルの初期化
                        (i, loopState, localSum) =>
                        {
                            localSum += a[i];
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
//p62
