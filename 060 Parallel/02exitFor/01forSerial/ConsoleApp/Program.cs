using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            for (int i = 0; i < 128; i++)
            {
                Console.WriteLine("i={0,3}", i);

                if (i == 10)
                    break;
            }
        }
    }
}
