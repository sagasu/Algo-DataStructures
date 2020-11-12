using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.PermutationsII
{
    [TestClass]
    public class Permutations2TLE
    {
        [TestMethod]
        public void Test()
        {
            var t = new int[] {1, 1, 2};
            PermuteUnique(t);
            /*
               [[1,1,2],
                [1,2,1],
                [2,1,1]]
             */
        }

        // Time limit exceeded
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> ret = new List<IList<int>>();

            void SetPermutations(IList<int> permutations, IList<int> used)
            {
                if (permutations.Count == nums.Length)
                { 
                    foreach (var setPermutation in ret)
                    {
                        var isNewOne = false;
                        for (int i = 0; i < setPermutation.Count; i++)
                        {
                            if (setPermutation[i] != permutations[i])
                                isNewOne = true;
                        }
                        if (!isNewOne) return;
                    }

                    var perm = new int[nums.Length];
                    permutations.CopyTo(perm, 0);
                    ret.Add(perm);
                    return;
                }

                for (var i = 0; i < nums.Length; i++)
                {
                    if (!used.Contains(i))
                    {
                        permutations.Add(nums[i]);
                        used.Add(i);
                        SetPermutations(permutations, used);
                        used.RemoveAt(used.Count -1);
                        permutations.RemoveAt(permutations.Count-1);
                    }
                }
            }

            SetPermutations(new List<int>(), new List<int>());
            return ret;
        }
    }
}
