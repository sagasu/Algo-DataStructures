using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.Predict_the_Winner
{
    internal class Predict_the_Winner
    {
        public bool PredictTheWinner(int[] nums) => helper(nums, 1, nums.Length - 1, nums[0], 0, false)
                   || helper(nums, 0, nums.Length - 2, nums[nums.Length - 1], 0, false);
        
        private bool helper(int[] nums, int l, int r, int p1, int p2, bool left)
        {
            if (l > r) return p1 >= p2;

            if (left)
                return helper(nums, l + 1, r, p1 + nums[l], p2, false) || helper(nums, l, r - 1, p1 + nums[r], p2, false);
            
            return helper(nums, l + 1, r, p1, p2 + nums[l], true) && helper(nums, l, r - 1, p1, p2 + nums[r], true);
        }
    }
}
