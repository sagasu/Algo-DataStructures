using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Minimum_Time_to_Complete_Trips
{
    [TestClass]
    public class Minimum_Time_to_Complete_Trips
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(3, MinimumTime(new int[]{ 1, 2, 3 }, 5));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(2, MinimumTime(new int[] { 2 }, 1));
        }
        
        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(25, MinimumTime(new int[] { 5, 10, 10 }, 9));
        }
        
        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual(100000000000, MinimumTime(new int[] { 1000 }, 10000000));
        }

        public long MinimumTime(int[] time, int totalTrips)
        {
            bool IsTooLarge(long mid)
            {
                long sum = 0;
                foreach (long t in time)
                {
                    sum += mid / t;
                    if (sum >= totalTrips) break;
                }
                
                return totalTrips <= sum;
            }
            
            long left = 0;
            long right = int.MaxValue;

            while (left < right)
            {
                long mid = left + (right - left) / 2;
                
                if (IsTooLarge(mid)) right = mid; // if it is bigger (which is good) we want to check if there is a smaller number to do it
                else left = mid + 1;// if it is too small still we want to try a bigger number
            }
            return left;

        }
        
    }
}
