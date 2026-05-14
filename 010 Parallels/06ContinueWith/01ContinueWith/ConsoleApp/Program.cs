using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] _)
        {
            Task<String> atask = Task.Run(() =>             // antecedent task
            {
                return "antecedent";   // to task.ContinueWith
            });
            Task<String> ctask = atask.ContinueWith((a) =>  // continuation Task
            {
                return a.Result + " + continuation";
            });
            Console.WriteLine(ctask.Result);
        }
    }
}
