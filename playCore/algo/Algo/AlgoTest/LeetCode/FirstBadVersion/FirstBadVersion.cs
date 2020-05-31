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
            //Assert.AreEqual(4, FirstBadVersion(5));
            //Assert.AreEqual(1702766719, FirstBadVersion(2126753390));
            //Assert.AreEqual(1150769282, FirstBadVersion(1420736637));
            Assert.AreEqual(1, FirstBadVersion(2));
            //Assert.AreEqual(3, FirstBadVersion(3));
        }

        public int FirstBadVersion(int n)
        {
            if (n == 1)
                return 1;

            var nextCheck = n / 2;
            var delta = nextCheck;
            while (true)
            {
                if (!isBadVersion(nextCheck))
                {
                    if(nextCheck == n)
                        return nextCheck;

                    if (isBadVersion(nextCheck + 1))
                        return nextCheck + 1;
                    delta = Math.Max(delta / 2, 1);
                    nextCheck = nextCheck + delta;
                }
                else
                {
                    if (nextCheck == 1)
                    {
                        return 1;
                    }

                    delta = Math.Max(delta / 2, 1);
                    nextCheck = nextCheck - delta;
                }
                
            }

            return 0;
        }


        public bool isBadVersion(int version)
        {
            //return version >= 1702766719;
            //return version >= 1150769282;
            return version >= 1;
            //return version >= 3;
        }
    }
}
