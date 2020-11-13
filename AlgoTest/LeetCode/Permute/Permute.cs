using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AlgoTest.LeetCode.Permute
{
    [TestClass]
    public class PermuteProblem
    {
        [TestMethod]
        public void Test() {
            var t = new int[] {1,2,3 };
            Permute(t);
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            Perm(nums, 0, new List<int>());
            return ret;
        }

        IList<IList<int>> ret = new List<IList<int>>();
        private void Perm(int[] nums, int index, List<int> cur) {
            if (index == nums.Length)
            {
                ret.Add(new List<int>(cur));
                return;
            }

            for (var i = 0; i < nums.Length; i++) {
                if (cur.Contains(nums[i]))
                    continue;

                cur.Add(nums[i]);
                Perm(nums, index + 1, cur);
                cur.RemoveAt(cur.Count - 1);
            }
        }
    }
}
