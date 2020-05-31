using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.FirstBadVersion
{
    [TestClass]
    public class FirstBadVersion1
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(4, FirstBadVersion(5));
        }

        public int FirstBadVersion(int n)
        {
            if (n == 1)
                return 1;

            var nextCheck = n / 2;
            while (true)
            {
                if (!isBadVersion(nextCheck))
                {
                    if(nextCheck == n)
                        return nextCheck;

                    if (isBadVersion(nextCheck + 1))
                        return nextCheck + 1;

                    nextCheck = nextCheck + (n - nextCheck) / 2;
                }
                else
                {
                    nextCheck = nextCheck / 2;
                }
                
            }

            return 0;
        }


        public bool isBadVersion(int version)
        {
            return new int[] {4, 5}.Any(x => x == version);
        }
    }
}
