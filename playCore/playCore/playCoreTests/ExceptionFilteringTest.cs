using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace playCoreTests
{
    [TestClass]
    public class ExceptionFilteringTest
    {
        [TestMethod]
        public void Filter() {
            Console.WriteLine("start");
            Debug.WriteLine("test start");
            Trace.WriteLine("test start");
            bool isExceptionThrown;
            var per = new Person2();
            try
            {
                using (per)
                {
                    throw new Exception("valid exception");
                }
            }
            catch (Exception e) when (WhenMethod(e))
            {
                Trace.WriteLine("exception catch");
                isExceptionThrown = true;
            }

            Assert.IsTrue(isExceptionThrown);
        }

        private bool WhenMethod(Exception exception)
        {
            Trace.WriteLine("when method");
            return true;
        }
    }

    class Person2 : IDisposable
    {
        public Person2()
        {
            Debug.WriteLine("constructor");
        }

        public void Dispose()
        {
            Trace.WriteLine("I am disposed");
        }
    }

}
