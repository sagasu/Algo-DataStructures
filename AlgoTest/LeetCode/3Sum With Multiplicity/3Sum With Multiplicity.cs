using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode._3Sum_With_Multiplicity
{
    [TestClass]
    public class _3Sum_With_Multiplicity
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {1, 1, 2, 2, 2, 2};
            Assert.AreEqual(12, ThreeSumMulti(t, 5));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new int[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
            Assert.AreEqual(20, ThreeSumMulti(t, 8));
        }

        public int ThreeSumMulti(int[] arr, int target)
        {
            var mod = (int)Math.Pow(10, 9) + 7;

            var pdp = new int[4,target + 1];
            var dp = new int[4, target + 1];

            pdp[0, 0] = 1;

            foreach (var x in arr)
            {
                for (var i = 0; i < 4; i++)
                for (var j = 0; j < target+1; j++)
                {
                    dp[i, j] += pdp[i, j];
                    dp[i, j] %= mod;

                    if (pdp[i, j] > 0 && x + j <= target && i + 1 < 4)
                    {
                        dp[i + 1, j + x] += pdp[i, j];
                        dp[i + 1, j] %= mod;
                    }
                }
                pdp = dp;
                dp = new int[4, target + 1];
            }


            return pdp[3, target] % mod;

        }
    }
}
