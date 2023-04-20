using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Longest_ZigZag_Path_in_a_Binary_Tree
{
    [TestClass]
    public class Longest_ZigZag_Path_in_a_Binary_Tree
    {
        [TestMethod]
        public void Test() => Assert.AreEqual(3, LongestZigZag(new TreeNode(1,null, new TreeNode(1, new TreeNode(1), new TreeNode(1, new TreeNode(1,null, new TreeNode(1, null, new TreeNode(1))), new TreeNode(1))))));
        
        public int LongestZigZag(TreeNode root)
        {
            var max = 0;
            void DFS(TreeNode node, bool isLeft, int localMax)
            {
                max = Math.Max(max, localMax);
                if (node.left != null) DFS(node.left, true, isLeft ? 1 : localMax+1);
                if (node.right != null) DFS(node.right, false, isLeft ? localMax+1 : 1);
            }

            if (root.left != null) DFS(root.left, true, 1);
            if (root.right != null) DFS(root.right, false, 1);

            return max;
        }
    }
}
