using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Special_Permutations
{
    [TestClass]
    public class Special_Permutations
    {
        [TestMethod]
        public void Test() => Assert.AreEqual(2, SpecialPerm(new int[] { 2, 3, 6 }));

        [TestMethod]
        public void Test1() => Assert.AreEqual(2, SpecialPerm(new int[] { 1,4,3}));

        public int SpecialPerm(int[] nums)
        {
            var n = nums.Length;
            var mall = (1 << n) - 1;
            var Mod = Math.Pow(10, 9) + 7;
            var cache = new Dictionary<(int, int), double>();
            double Count(int last, int mask)
            {
                var key = (last, mask);
                if(cache.ContainsKey(key)) return cache[key];
                if (mask == mall) return 1;

                double total = 0;
                for (var i = 0; i < n; i++)
                {
                    if((mask & (1 << i)) == 0 && ((nums[i] % nums[last] == 0) || (nums[last] % nums[i] == 0)))
                    {
                        total += Count(i, mask | (1 << i));
                        total %= Mod;
                    }
                }
                cache[key] = total;
                return total;
            }

            double total = 0;
            for (var i = 0; i < n; i++)
            {
                total += Count(i, 1 << i);
                total %= Mod;
            }
            return (int)total;
        }
    }
}
