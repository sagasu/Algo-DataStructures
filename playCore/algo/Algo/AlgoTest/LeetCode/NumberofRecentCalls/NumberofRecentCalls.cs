using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.NumberofRecentCalls
{

    [TestClass]
    public class NumberofRecentCalls
    {
        [TestMethod]
        public void Test()
        {
            var rc = new RecentCounter();
            Assert.AreEqual(1, rc.Ping(1));
            Assert.AreEqual(2, rc.Ping(100));
            Assert.AreEqual(3, rc.Ping(3001));
            Assert.AreEqual(3, rc.Ping(3002));
        }


        public class RecentCounter
        {
            IList<int> time = new List<int>();
            private int index = 0;
            private int count = 0;
            public RecentCounter()
            {

            }

            public int Ping(int t)
            {
                time.Add(t);
                while (t - time[0] > 3000)
                {
                    time.RemoveAt(0);
                }

                return time.Count;
            }
        }

    }
}
