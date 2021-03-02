using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Set_Mismatch
{
    [TestClass]
    public class Set_Mismatch_When_Next
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(new int[]{ 2, 3 }, FindErrorNums(new int[]{ 1, 2, 2, 4 }));
        }
        
        [TestMethod]
        public void Test2()
        {
            CollectionAssert.AreEqual(new int[]{ 4, 5 }, FindErrorNums(new int[]{ 1, 2, 3, 4, 4 }));
        }
        
        [TestMethod]
        public void Test3()
        {
            CollectionAssert.AreEqual(new int[]{ 1, 2 }, FindErrorNums(new int[]{ 1, 1 }));
        }

        // This is an answer for slightly different problem, when missing number is next after the dup number.
        public int[] FindErrorNums(int[] nums)
        {
            var j = 0;
            for (var i = 1; i < nums.Length; i++)
            {
                j += 1;
                if (nums[i] == nums[i - 1]) break;
            }

            return new[] { nums[j], nums[j] + 1 };
        }
    }
}
