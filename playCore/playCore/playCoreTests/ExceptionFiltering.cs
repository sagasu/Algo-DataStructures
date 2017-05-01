using NUnit.Framework;
using System;
using System.Diagnostics;

namespace playCoreTests
{    
    [TestFixture]
    public class ExceptionFiltering
    {
        [Test]
        public void Filter() {
            Debug.WriteLine("test start");
            Trace.WriteLine("test start");
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
            }
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
