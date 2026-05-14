using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            const int DataLength = 1024;
            int[] a = Enumerable.Range(-(DataLength/2), DataLength).ToArray();

            Parallel.Invoke(
                () =>
                {
                    var sum = 0;
                    for (int i = 0; i < a.Length; i++)
                    {
                        sum += a[i];
                    }
                    Console.WriteLine($"sum = {sum,5}");
                },
                () =>
                {
                    var max = int.MinValue;
                    for (int i = 0; i < a.Length; i++)
                    {
                        max = Math.Max(max, a[i]);
                    }
                    Console.WriteLine($"max = {max,5}");
                },
                () =>
                {
                    var min = int.MaxValue;
                    for (int i = 0; i < a.Length; i++)
                    {
                        min = Math.Min(min, a[i]);
                    }
                    Console.WriteLine($"min = {min,5}");
                },
                () =>
                {
                    var sum = 0;
                    for (int i = 0; i < a.Length; i++)
                    {
                        sum += a[i];
                    }
                    var ave = (float)sum / (float)a.Length;
                    Console.WriteLine($"ave = {ave,5:f2}");
                }
            );
            Console.WriteLine("Done.");
        }
    }
}
