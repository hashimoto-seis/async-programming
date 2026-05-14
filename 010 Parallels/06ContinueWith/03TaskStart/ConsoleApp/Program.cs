using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] _)
        {
            Task<String> atask = new Task<String>(() =>
            {
                return "antecedent";
            });
            Task<String> ctask = atask.ContinueWith((a) =>
            {
                return a.Result + " + continuation";
            });
            atask.Start();

            Console.WriteLine(ctask.Result);
        }
    }
}
