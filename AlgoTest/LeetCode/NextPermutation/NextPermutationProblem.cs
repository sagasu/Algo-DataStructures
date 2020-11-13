using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.NextPermutation
{
    [TestClass]
    public class NextPermutationProblem
    {
        [TestMethod]
        public void Test() {
            var t = new int[] { 1, 2, 3 };
            //var t = new int[] { 9, 5, 4, 3, 1 };
            //var t = new int[] { 1, 5, 8, 4, 7, 6, 5, 3, 1 };
            //var t = new int[] { 2, 1, 3 };
            //var t = new int[] { 3, 2, 1 };
            NextPermutation(t);
        }

        public void NextPermutation(int[] nums)
        {
            if (nums.Length == 1)
                return;

            if (nums.Length == 2) {
                Array.Reverse(nums, 0, nums.Length);
                return;
            }
                

            var previous = nums[nums.Length - 1];
            var swapIndex = 0;
            for (var i = nums.Length - 2; i >= 0; i--) {
                if (previous > nums[i]) {
                    swapIndex = i;
                    previous = nums[i];
                    break;
                }
                previous = nums[i];
            }
            if (swapIndex == 0)
                previous = nums[0];

            for (var i = swapIndex; i < nums.Length-1; i++) { 
                if(previous >= nums[i+1])
                {
                    Swap(nums, swapIndex, i);
                    break;
                }
                if (i == nums.Length - 2) {
                    Swap(nums, swapIndex, i+1);
                    break;
                }

            }
            var start = swapIndex == 0 ? 0 : swapIndex + 1;
            var end = swapIndex == 0 ? swapIndex : -swapIndex - 1;
            Array.Reverse(nums, start, nums.Length + end);

        }

        private void Swap(int[] nums, int swapIndex, int i)
        {
            var temp = nums[i];
            nums[i] = nums[swapIndex];
            nums[swapIndex] = temp;
        }
    }
}
