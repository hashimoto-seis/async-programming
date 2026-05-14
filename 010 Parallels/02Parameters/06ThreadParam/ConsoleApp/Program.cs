using System;
using System.Threading;

namespace ConsoleApp
{
    public class CThread
    {
        private readonly string msg;

        public CThread(string msg)
        {
            this.msg = msg;
        }

        public void WThread()
        {
            for (int i = 0; i < 1024; i++)
            {
                Console.Write(msg);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] _)
        {
            var msg = "1";
            CThread PThread = new CThread(msg);
            new Thread(new ThreadStart(PThread.WThread)).Start();

            CThread SThread = new CThread("2");
            Thread.Sleep(1);
            msg = "0";
            SThread.WThread();
        }
    }
}
