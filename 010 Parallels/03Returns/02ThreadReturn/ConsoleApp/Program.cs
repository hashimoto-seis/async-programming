using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    // スレッドクラス
    public class CThread
    {
        private readonly Action<int> callback;

        // コンストラクタ
        public CThread(Action<int> callbackProcDelegate)
        {
            callback = callbackProcDelegate;
        }

        public void WThread()
        {
            try
            {
                var sum = 0;
                for (int i = 0; i < 16; i++)
                {
                    sum += i;
                    Console.Write($"{i}+");
                }
                Console.Write("\b \b");
                callback(sum);
            }
            catch (ThreadAbortException)
            {
                Console.WriteLine("failed ThreadAbortException occuer.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] _)
        {
            CThread PThread = new CThread(new Action<int>(CompleteCode));
            Thread thread = new Thread(new ThreadStart(PThread.WThread));
            //CThread PThread = new CThread(CompleteCode);
            //Thread thread = new Thread(PThread.WThread);
            thread.Start();
        }

        // call back
        public static void CompleteCode(int completeCode)
        {
            Console.WriteLine($" = {completeCode}.");
        }
    }
}
