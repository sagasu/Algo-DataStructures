using System;
using NUnit.Framework;

namespace Playground.AsyncAwait
{
    [TestFixture]
    public class GeneralTest : AsyncHelper
    {
        [Test]
        public void TestAsync_WithoutWaitingForLongRunningOperationToFinish_NotDisplayResultsAndFinishWaiting()
        {
            //Expected behaviour:
            //start test
            //starts waiting
            //finish test

            Console.WriteLine("start test");
            ReturnOneAfterThreeSecondsAsync();
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
            await ReturnOneAfterThreeSecondsAsync();
            Console.WriteLine("finish test");
        }


        [Test]
        public void TestAsync_WaitForTask_DisplayResultsAndFinishWaiting()
        {
            //Expected behaviour:
            //start test
            //starts waiting
            // *** Majority of time spend here
            //finished waiting
            //1
            //finish test


            Console.WriteLine("start test");
            var task = ReturnOneAfterThreeSecondsAsync();
            task.Wait();
            Console.WriteLine("finish test");
        }

        [Test]
        public void TestAsync_ReceiveTask_DisplayResultsAndFinishWaiting()
        {
            //Expected behaviour:
            //start test
            //starts waiting
            //finish test


            Console.WriteLine("start test");
            var task = ReturnOneAfterThreeSecondsAsync();
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
            ReturnOneAfterThreeSecondsAsync();
            WaitAndDontBlockThread(4);


            Console.WriteLine("finish test");
        }


        protected override void DoAfterWork(){}
    }
}
