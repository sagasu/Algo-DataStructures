using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Kids_With_the_Greatest_Number_of_Candies
{
    [TestClass]
    public class Kids_With_the_Greatest_Number_of_Candies
    {
        [TestMethod]
        public void Test() => Assert.IsTrue(
            KidsWithCandies(new int[] { 2, 3, 5, 1, 3 }, 3) is [true, true, true, false, true]);
        
        [TestMethod]
        public void Test2() => Assert.IsTrue(
            KidsWithCandies(new int[] { 4, 2, 1, 1, 2 }, 1) is [true, false, false, false, false]);

        [TestMethod]
        public void Test3() => Assert.IsTrue(
            KidsWithCandies(new int[] { 12, 1, 12 }, 10) is [true, false, true]);

        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            var max = candies.Max();
            var isGreatest = candies.Select(x => x + extraCandies >= max);
            return isGreatest.ToList();
        }
    }
}
