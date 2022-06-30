using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Valid_Triangle_Number
{

    // This is a solution for a different problem, I assumed that it is a right triangle :)
    [TestClass]
    public class Valid_Triangle_Number_RightTriangle
    {
        [TestMethod]
        public void Test()
        {
            var t = new[] {2, 2, 3, 4};
            Assert.AreEqual(3, TriangleNumber(t));
        }

        public int TriangleNumber(int[] nums)
        {
            var dic = new Dictionary<int, int>();
            Array.Sort(nums);
            foreach (var num in nums)
                if (!dic.TryAdd(num, 1)) dic[num] += 1;
            

            var count = 0;
            for(var i =0;i<nums.Length;i++)
                for (var j = i + 1; j < nums.Length; j++)
                {
                    var sqrt = Math.Sqrt(Math.Pow(nums[i], 2) + Math.Pow(nums[j], 2));
                    if (sqrt % 1 == 0 && dic.ContainsKey((int)sqrt)) count += 1;
                }
            

            return count;
        }
    }
}
