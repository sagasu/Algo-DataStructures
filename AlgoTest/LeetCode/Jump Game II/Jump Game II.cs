using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Jump_Game_II
{
    [TestClass]
    public class Jump_Game_II
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {2, 3, 1, 1, 4};
            Assert.AreEqual(2, Jump(t));
        }
        [TestMethod]
        public void Test2()
        {
            var t = new int[] { 2, 3, 0, 1, 4 };
            Assert.AreEqual(2, Jump(t));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t = new int[] { 1,2,3 };
            Assert.AreEqual(2, Jump(t));
        }
        
        [TestMethod]
        public void Test4()
        {
            var t = new int[] {2,3,4,0,1 };
            Assert.AreEqual(2, Jump(t));
        }
        public int Jump(int[] nums)
        {
            var cache = new Dictionary<int, int?>();

            int MinJump(int index)
            {
                if (index >= nums.Length - 1)
                    return 0;

                if (cache.ContainsKey(index)) return cache[index].Value;

                var minJumps = int.MaxValue-1;
                for (var i = index + 1; i < Math.Min(index + nums[index] + 1, nums.Length); i++)
                    minJumps = Math.Min(minJumps, MinJump(i) + 1);

                cache[index] = minJumps;
                return minJumps;

            }

            return MinJump(0);
        }
    }
}
