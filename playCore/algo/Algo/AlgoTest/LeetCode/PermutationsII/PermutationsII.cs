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
            BuildPermutation(nums, 0, new List<int>(), new List<int>());
            return ret;
        }

        IList<IList<int>> ret = new List<IList<int>>();

        void BuildPermutation(int[] nums, int index, IList<int> curr, IList<int> indexVisited) {
            if (index == nums.Length) {
                var same = false;
                for (var i = 0; i < ret.Count; i++) {
                    same = true;
                    var ar = ret[i].ToArray();
                    var curar = curr.ToArray();
                    for (var j = 0; j < ar.Length; j++) {
                        if (ar[j] != curar[j])
                        {
                            same = false;
                            break;
                        }
                    }
                    if (same)
                        return;
                }
                
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
            }
        }
    }
}
