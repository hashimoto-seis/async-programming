using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            Task<String>[] ArrayTask  = new[] {
                Task<String>.Run(() => { return "A"; }),
                Task<String>.Run(() => { return "B"; }),
                Task<String>.Run(() => { return "C"; })
            };
            for (int i = 0; i < ArrayTask .Length; i++)
                Console.WriteLine("Result[{0}] = {1}.", i, ArrayTask [i].Result);
        }
    }
}
