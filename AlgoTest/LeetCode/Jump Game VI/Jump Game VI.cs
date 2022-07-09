using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Jump_Game_VI
{
    internal class Jump_Game_VI
    {
        public int MaxResult(int[] nums, int k)
        {
            var list = new LinkedList<int>(new[] { 0 });

            for (var i = 1; i < nums.Length; ++i)
            {
                nums[i] += nums[list.First.Value];
                while (list.Last != null && nums[list.Last.Value] <= nums[i]) list.RemoveLast();
                list.AddLast(i);
                if (i - list.First.Value >= k) list.RemoveFirst();
            }

            return nums[^1];
        }
    }
}
