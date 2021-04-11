using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Deepest_Leaves_Sum
{
    public class Deepest_Leaves_Sum_Faster
    {

        public void Test()
        {
        }


        // Runtime: 108 ms, Memory Usage: 34.4 MB
        // It is interesting that it is faster, because we are iterating 2 times over tree.
        public int DeepestLeavesSum(TreeNode root)
        {
            BuilMaxLevel(root, 0);
            SumMaxLevelNodes(root, 0);

            return maxSum;
        }
        int maxLevel = 0;
        int maxSum = 0;

        void BuilMaxLevel(TreeNode tn, int level)
        {
            if (level > maxLevel) maxLevel = level;

            if (tn.left != null) BuilMaxLevel(tn.left, level + 1);

            if (tn.right != null) BuilMaxLevel(tn.right, level + 1);
        }
        void SumMaxLevelNodes(TreeNode node, int level)
        {
            if (level == maxLevel) maxSum += node.val;

            if (node.left != null) SumMaxLevelNodes(node.left, level + 1);

            if (node.right != null) SumMaxLevelNodes(node.right, level + 1);
        }
    }

}
