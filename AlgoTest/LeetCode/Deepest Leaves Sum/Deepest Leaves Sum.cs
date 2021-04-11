using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Deepest_Leaves_Sum
{
    public class Deepest_Leaves_Sum
    {

        public void Test()
        {
        }


        // Runtime: 120 ms, Memory Usage: 34.9 MB
        public int DeepestLeavesSum(TreeNode root)
        {

            var leavesSum = new List<int>();

            void BuildDeepestLeavesSum(TreeNode tn, int level)
            {
                if (tn == null) return;

                if (leavesSum.Count <= level)
                    leavesSum.Add(tn.val);
                else
                    leavesSum[level] += tn.val;

                BuildDeepestLeavesSum(tn.left, level + 1);

                BuildDeepestLeavesSum(tn.right, level + 1);
            }

             BuildDeepestLeavesSum(root, 0);

             return leavesSum[leavesSum.Count - 1];
        }
    }

}
