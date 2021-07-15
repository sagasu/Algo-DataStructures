using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Valid_Triangle_Number
{
    [TestClass]
    public class Valid_Triangle_Number_TimeLimitExc
    {
        [TestMethod]
        public void Test()
        {
            var t = new[] {2, 2, 3, 4};
            Assert.AreEqual(3, TriangleNumber(t));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new[] { 4, 2, 3, 4 };
            Assert.AreEqual(4, TriangleNumber(t));
        }

        public int TriangleNumber(int[] nums)
        {
            var dic = new Dictionary<int, int>();
            Array.Sort(nums);
            foreach (var num in nums)
            {
                if (!dic.TryAdd(num, 1)) dic[num] += 1;
            }

            var count = 0;
            for(var i =0;i<nums.Length;i++)
            {
                for (var j = i + 1; j < nums.Length-1; j++)
                {
                    var index = 1;
                    while (j + index < nums.Length && nums[j + index] < nums[i] + nums[j])
                    {
                        count += 1;
                        index += 1;
                    }
                }
            }

            return count;
        }
    }
}
