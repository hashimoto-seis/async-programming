using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            Task<String>[] aT = new[]
            {
                Task<String>.Run(() =>{throw new FormatException("FormatException.");return "A";}),
                Task<String>.Run(() =>{throw new ArgumentException("ArgumentException.");return "B";}),
                Task<String>.Run(() =>{throw new DivideByZeroException("DivideByZeroException.");return "C";})
            };

            try
            {
                Console.WriteLine("{0}{1}{2}.", aT[0].Result, aT[1].Result, aT[2].Result);  //参照のみ捕捉できる
            }
            catch (AggregateException e)
            {
                Console.WriteLine($"catch: {e.GetType().Name} - {e.Message}");
                foreach (Exception it in e.InnerExceptions)
                    Console.WriteLine($"  {it.GetType().Name} - {it.Message}");
            }
        }
    }
}
