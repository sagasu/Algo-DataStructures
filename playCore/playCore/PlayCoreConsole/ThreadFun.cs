using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace PlayCoreConsole
{
    class ThreadFun
    {
        public void Run()
        {
            new Thread(PrintHiEvery5Seconds).Start();
        }

        private void PrintHiEvery5Seconds()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(5000);
                Action a = () => Console.WriteLine("Hi");
                this.BeginInvoke(a);
            }
        }
    }
}
