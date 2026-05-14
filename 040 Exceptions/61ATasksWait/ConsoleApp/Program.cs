using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] _)
        {
            //-----------------------
            //Task[] aT = new[]
            //{
            //    Task.Factory.StartNew(() =>{throw new FormatException("FormatException.");}),
            //    Task.Factory.StartNew(() =>{throw new ArgumentException("ArgumentException.");}),
            //    Task.Factory.StartNew(() =>{throw new DivideByZeroException("DivideByZeroException.");})
            //};
            //-----------------------
            Task[] aT = new[]
            {
                Task.Run(() =>{throw new FormatException("FormatException.");}),
                Task.Run(() =>{throw new ArgumentException("ArgumentException.");}),
                Task.Run(() =>{throw new DivideByZeroException("DivideByZeroException.");})
            };

            try
            {
                Task.WaitAll(aT);
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
