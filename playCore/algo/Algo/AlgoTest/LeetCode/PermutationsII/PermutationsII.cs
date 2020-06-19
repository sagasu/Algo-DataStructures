using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.PermutationsII
{
    class PermutationsII
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            Array.Sort(nums);
            BuildPermutation(nums, 0, new List<int>(), new List<int>());
            return ret;
        }

        IList<IList<int>> ret = new List<IList<int>>();

        void BuildPermutation(int[] nums, int index, IList<int> curr, IList<int> indexVisited) {
            if (index == nums.Length) {
                
                ret.Add(new List<int>(curr));
                return;
            }

            for (var i = 0; i < nums.Length; i++) {
                if (indexVisited.Contains(i))
                    continue;

                curr.Add(nums[i]);
                indexVisited.Add(i);
                BuildPermutation(nums, index + 1, curr, indexVisited);
                curr.RemoveAt(curr.Count - 1);
                indexVisited.RemoveAt(indexVisited.Count - 1);
                while (i+1 < nums.Length && nums[i] == nums[i+1])
                    i++;
            }
        }
    }
}
