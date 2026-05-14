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
            var stack = new ConcurrentStack<int>();

            //Enqueue
            const int DataLength = 1024;
            int[] a = Enumerable.Range(1, DataLength).ToArray();
            for (int i = 0; i < a.Length; i++)
                stack.Push(a[i]);

            //parallel dequeue and sum them
            Task<int>[] tasks = new Task<int>[5];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    var localSum = 0;
                    while (!stack.IsEmpty)
                    {
                        while (stack.TryPop(out int dequeueData))
                            localSum += dequeueData;
                    }
                    return localSum;
                });
            }
            var sum = 0;
            for (int i = 0; i < tasks.Length; i++)
                sum += tasks[i].Result;
            Console.WriteLine($"sum  = {sum}.");

            CheckCode(a, sum);
        }

        // check code
        private static void CheckCode(int[] a, int result)
        {
            var csum = 0;
            for (int i = 0; i < a.Length; i++)
                csum += a[i];
            Console.WriteLine($"csum = {csum}.");

            if (result != csum)
                Console.WriteLine($"error, csum = {csum}, result= {result}.");
        }
    }
}
