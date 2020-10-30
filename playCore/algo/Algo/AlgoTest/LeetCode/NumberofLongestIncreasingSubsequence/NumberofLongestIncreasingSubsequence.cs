using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.NumberofLongestIncreasingSubsequence
{
    [TestClass]
    public class NumberofLongestIncreasingSubsequence
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] { 1, 3, 5, 4, 7 };
            Assert.AreEqual(2, FindNumberOfLIS(t));


            max = 0;
            nrOfSubs = 0;
            t = new int[] { 2, 2, 2, 2, 2};
            Assert.AreEqual(5, FindNumberOfLIS(t));
            
            max = 0;
            nrOfSubs = 0;
            t = new int[] { 1, 2, 4, 3, 5, 4, 7, 2};
            Assert.AreEqual(3, FindNumberOfLIS(t));
        }


        private int max = 0;
        private int nrOfSubs = 0;
        private int usedNr;


        public int FindNumberOfLIS(int[] nums)
        {
            SetNumberOfLIS(nums, 0, new List<int>(), new List<int>());

            if (max == 1)
            {
                return nums.Count(x => x == usedNr);
            }

            return nrOfSubs;
        }

        private void SetNumberOfLIS(int[] nums, int index, List<int> taken, List<int> used)
        {
            if (index == nums.Length)
            {
                if (taken.Count == max)
                {
                    nrOfSubs += 1;
                }
                else if (taken.Count > max)
                {
                    max = taken.Count;
                    usedNr = taken[0];
                    nrOfSubs = 1;
                }
                return;
            }

            for (var i = index; i < nums.Length; i++)
            {
                if (taken.Count == 0 || (taken[taken.Count - 1] < nums[i]))
                {
                    taken.Add(nums[i]);
                    //used.Add(i);
                    SetNumberOfLIS(nums, i + 1, taken, used);
                    taken.RemoveAt(taken.Count - 1);
                    //used.RemoveAt(used.Count - 1);
                }
            }
        }
    }
}
