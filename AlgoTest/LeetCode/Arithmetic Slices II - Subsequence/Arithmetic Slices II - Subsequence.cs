using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Arithmetic_Slices_II___Subsequence
{
    [TestClass]
    public class Arithmetic_Slices_II___Subsequence
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {7, 7, 7, 7, 7};
            Assert.AreEqual(16, NumberOfArithmeticSlices(t));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new int[] {0, 2000000000, -294967296};
            Assert.AreEqual(0, NumberOfArithmeticSlices(t));
        }
        public int NumberOfArithmeticSlices(int[] nums)
        {
            long ans = 0;
            var maps = new Dictionary<long, long>[nums.Length];

            for (var i = 0; i < nums.Length; i++) maps[i] = new Dictionary<long, long>();
            
            for (var i = 1; i < maps.Length; i++)
            for (var j = 0; j < i; j++){
                long cd = (long)nums[i] - (long)nums[j];

                    if (cd <= int.MinValue|| cd >= int.MaxValue) continue;

                    long val = 0;
                    var apsEndingOnJ = maps[j].TryGetValue(cd, out val) ? val : 0;
                    var apsEndingOnI = maps[i].TryGetValue(cd, out val) ? val : 0;
                    
                    ans += apsEndingOnJ;
                    if(!maps[i].TryAdd((int)cd, apsEndingOnI + apsEndingOnJ + 1))
                        maps[i][(int)cd] = apsEndingOnI + apsEndingOnJ + 1;
            }
            
            return (int)ans;
        }
    }
}
