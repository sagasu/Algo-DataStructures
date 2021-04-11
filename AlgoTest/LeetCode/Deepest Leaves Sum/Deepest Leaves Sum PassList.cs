using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Deepest_Leaves_Sum
{
    public class Deepest_Leaves_Sum_PassingList
    {

        public void Test()
        {
        }

        // Runtime: 120 ms, Memory Usage: 34.2 MB
        public int DeepestLeavesSum(TreeNode root)
        {

            var leavesSum = new List<int>();

            void BuildDeepestLeavesSum(TreeNode tn, List<int> sums,int level)
            {
                if (tn == null) return;

                if (sums.Count <= level)
                    sums.Add(tn.val);
                else
                    sums[level] += tn.val;

                BuildDeepestLeavesSum(tn.left, sums,level + 1);

                BuildDeepestLeavesSum(tn.right, sums, level + 1);
            }

             BuildDeepestLeavesSum(root, leavesSum, 0);

             return leavesSum[leavesSum.Count - 1];
        }
    }

}
