using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Playground.AsyncAwait
{
    [TestFixture]
    public class GeneralTest
    {
        [Test]
        public void TestAsync_WithoutWaitingForLongRunningOperationToFinish_NotDisplayResultsAndFinishWaiting()
        {
            //Expected behaviour:
            //start test
            //starts waiting
            //finish test

            Console.WriteLine("start test");
            MyMethod();
            Console.WriteLine("finish test");
        }

        [Test]
        // Interesting that NUnit runs async tests
        public async void TestAsync_WaitingForLongRunningOperationToFinish_DisplayResultsAndFinishWaiting()
        {
            //Expected behaviour:
            //start test
            //starts waiting
            // *** Majority of time spend here
            //finished waiting
            //1
            //finish test


            Console.WriteLine("start test");
            await MyMethod();
            Console.WriteLine("finish test");
        }


        [Test]
        public void TestAsync_NotWaitingForLongRunningOperationToFinish_ButCodeInMainThreadWillRunLongEnoughtForLongRunningTaskToFinish_DisplayResultsAndFinishWaiting()
        {
            //Expected behaviour:
            //start test
            //starts waiting
            // *** Majority of time spend here
            //finished waiting
            //1
            //finish test


            Console.WriteLine("start test");
            MyMethod();
            WaitAndDontBlockThread(4);


            Console.WriteLine("finish test");
        }


        // It will use CPU
        void WaitAndDontBlockThread(int x)
        {
            DateTime t = DateTime.Now;
            DateTime tf = DateTime.Now.AddSeconds(x);

            while (t < tf)
            {
                t = DateTime.Now;
            }
        }

        public async Task MyMethod()
        {
            Task<int> longRunningTask = LongRunningOperation();
            //indeed you can do independent to the int result work here 

            int result = 0;

            //and now we call await on the task 
            result = await longRunningTask;
            //use the result 
            Console.WriteLine(result);
        }

        public async Task<int> LongRunningOperation() // assume we return an int from this long running operation 
        {
            Console.WriteLine("starts waiting");
            await Task.Delay(3000); //1 seconds delay
            Console.WriteLine("finished waiting");
            return 1;
        }
    }
}
