using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Koko_Eating_Bananas
{
    [TestClass]
    public class Koko_Eating_Bananas
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(4, MinEatingSpeed(new int[]{ 3, 6, 7, 11 }, 8));
        }
        
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(30, MinEatingSpeed(new int[]{ 30, 11, 23, 4, 20 }, 5));
        }

        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(23, MinEatingSpeed(new int[]{ 30, 11, 23, 4, 20 }, 6));
        }
        
        [TestMethod]
        public void Test4()
        {
            //2147483647
            //312884470
            //968709470
            Assert.AreEqual(1, MinEatingSpeed(new int[]{ 312884470 }, 968709470));
        }

        public int MinEatingSpeed(int[] piles, int h)
        {
            bool IsGood(long mid)
            {

                var sum = 0L;
                foreach (long pile in piles) sum += (pile + mid -1) / mid;
                
                return sum <= h;
            }

            var left = 1L;
            long right = int.MaxValue;
                        

            while (left < right)
            {
                var mid = left + (right - left) / 2;
                if (IsGood(mid)) right = mid;
                else left = mid + 1;
            }

            return (int)left;
        }
    }
}
