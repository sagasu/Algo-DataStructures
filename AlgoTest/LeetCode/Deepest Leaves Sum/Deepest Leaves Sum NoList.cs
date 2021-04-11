using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Deepest_Leaves_Sum
{
    public class Deepest_Leaves_Sum_NoList
    {

        public void Test()
        {
        }


        // Runtime: 124 ms, Memory Usage: 34.5 MB
        // It is slower a little bit I guess that because of extra elseIf statement.
        public int DeepestLeavesSum(TreeNode root)
        {
            int maxLevel = 0;
            int maxSum = 0;

            void BuildDeepestLeavesSum(TreeNode tn, int level)
            {
                if (tn == null) return;

                if (maxLevel == level)
                    maxSum += tn.val;
                else if(maxLevel < level)
                {
                    maxSum = tn.val;
                    maxLevel = level;
                }

                level++;
                BuildDeepestLeavesSum(tn.left, level);

                BuildDeepestLeavesSum(tn.right, level);
            }

             BuildDeepestLeavesSum(root, 0);

             return maxSum;
        }
    }

}
