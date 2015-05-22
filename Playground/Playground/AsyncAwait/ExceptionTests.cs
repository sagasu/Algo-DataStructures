using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Playground.AsyncAwait
{
    [TestFixture]
    public class ExceptionTest : AsyncHelper
    {
        [Test]
        public void TestAsync_WithoutWaitingForLongRunningOperationToFinish_ShouldntThrowException()
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
        [ExpectedException(typeof(Exception))]
        public async void TestAsync_WaitingForLongRunningOperationToFinish_ShouldThrowException()
        {
            //Expected behaviour:
            //start test
            //starts waiting
            //*exception being thrown


            Console.WriteLine("start test");
            await ReturnOneAfterThreeSecondsAsync();
            Console.WriteLine("finish test");
        }

        [Test]
        // Notice that It is a different Exception than with async, it is AggregateException not Exception
        [ExpectedException(typeof(AggregateException))]
        public void TestAsync_WaitForTask_ShouldThrowDifferentExceptionThanOneThatWasThrown()
        {
            //Expected behaviour:
            //start test
            //starts waiting
            //*exception being thrown


            Console.WriteLine("start test");
            var task = ReturnOneAfterThreeSecondsAsync();
            task.Wait();
            Console.WriteLine("finish test");
        }

        [Test]
        public void TestAsync_ReceiveTask_DontThrowException()
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
        public void TestAsync_NotWaitingForLongRunningOperationToFinish_ButCodeInMainThreadWillRunLongEnoughtForLongRunningTaskToFinish_ShouldntThrowException()
        {
            //Expected behaviour:
            //start test
            //starts waiting
            //finish test
            
            Console.WriteLine("start test");
            ReturnOneAfterThreeSecondsAsync();
            WaitAndDontBlockThread(4);


            Console.WriteLine("finish test");
        }

        protected override void DoAfterWork()
        {
            throw new Exception();
        }

        public new async Task<int> LongRunningOperation() // assume we return an int from this long running operation 
        {
            Console.WriteLine("starts waiting");
            await Task.Delay(3000); //1 seconds delay
            throw new Exception("Ex");
        }
    }
}
