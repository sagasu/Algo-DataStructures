using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.MaximizeDistancetoClosestPerson
{
    [TestClass]
    public class MaximizeDistancetoClosestPerson
    {
        [TestMethod]
        public void Test()
        {
            //var t = new int[] {1, 0, 0, 0, 1, 0, 1};
            //Assert.AreEqual(2, MaxDistToClosest(t));

            var t = new int[] { 1, 0, 0, 0 };
            Assert.AreEqual(3, MaxDistToClosest(t));

            t = new int[] { 0, 1 };
            Assert.AreEqual(1, MaxDistToClosest(t));

        }

        public int MaxDistToClosest(int[] seats)
        {
            var maxLeftCount = 0;
            var maxRightCount = 0;
            var currCount = 0;
            var leftCount = 0;
            var firstRun = true;
            

            foreach (var seat in seats.Append(1))
            {
                if (seat == 1 && !firstRun)
                {
                    var min = Math.Min(maxLeftCount, maxRightCount);
                    if (min == maxLeftCount)
                    {
                        if (leftCount >= maxLeftCount && currCount >= maxLeftCount)
                        {
                            maxLeftCount = leftCount;
                            maxRightCount = currCount;
                        }
                    }
                    else if (min == maxRightCount)
                    {
                        if (currCount >= maxRightCount && leftCount >= maxRightCount)
                        {
                            maxLeftCount = leftCount;
                            maxRightCount = currCount;
                        }
                    }

                    leftCount = currCount;
                    currCount = 0;
                    continue;
                }
                else if(seat == 1 && firstRun)
                {
                    firstRun = false;
                    leftCount = currCount;
                    currCount = 0;
                    continue;
                }

                currCount += 1;
            }

            var maxDistance = Math.Min(maxLeftCount, maxRightCount);
            return maxDistance + 1;
        }
    }
}
