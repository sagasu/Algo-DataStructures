using System;
using System.Threading.Tasks;

namespace Playground.AsyncAwait
{
    public abstract class AsyncHelper
    {
        // It will use CPU
        public void WaitAndDontBlockThread(int x)
        {
            DateTime t = DateTime.Now;
            DateTime tf = DateTime.Now.AddSeconds(x);

            while (t < tf)
            {
                t = DateTime.Now;
            }
        }

        public async Task ReturnOneAfterThreeSecondsAsync()
        {
            Task<int> longRunningTask = LongRunningOperation();
            //indeed you can do independent to the int result work here 

            int result = 0;

            //and now we call await on the task 
            result = await longRunningTask;
            //use the result 
            Console.WriteLine(result);
        }

        protected abstract void DoAfterWork();

        public async Task<int> LongRunningOperation() // assume we return an int from this long running operation 
        {
            Console.WriteLine("starts waiting");
            await Task.Delay(3000); //1 seconds delay
            Console.WriteLine("finished waiting");
            DoAfterWork();
            return 1;
        }
    }
}
