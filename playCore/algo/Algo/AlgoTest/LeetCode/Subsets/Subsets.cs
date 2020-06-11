using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AlgoTest.LeetCode.Subsets
{
    [TestClass]
    public class SubsetsProblem
    {
        [TestMethod]
        public void Test() {
            var t = new int[] { 1, 2, 3 };
            var ret = Subsets(t);
        }

        public IList<IList<int>> Subsets(int[] nums)
        {
            Subsets(nums, 0, new List<int>());
            return ret;
        }

        IList<IList<int>> ret = new List<IList<int>>();
        public void Subsets(int[] nums, int index, List<int> values) {
            //if (nums.Length == index)
            //{
            //    ret.Add(new List<int>(values));
            //    return;
            //}

            ret.Add(new List<int>(values));
            for (var i = index; i < nums.Length; i++) {
                //var vals = new List<int>(values);
                values.Add(nums[i]);
                Subsets(nums, i + 1, values);
                values.RemoveAt(values.Count - 1);
                //Subsets(nums, index + 1, vals);
            }
        }
    }
}
