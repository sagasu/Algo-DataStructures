using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.MaximumWidthOfBinaryTree
{
    [TestClass]
    public class MaximumWidthOfBinaryTree
    {
        [TestMethod]
        public void Test()
        {
            //var t = new TreeNode{val = 1, left = new TreeNode{val = 3, left = new TreeNode{val = 5}, right = new TreeNode{val = 3}}, right = new TreeNode{val = 2, right = new TreeNode{val = 9}}};
            //Assert.AreEqual(4, WidthOfBinaryTree(t));
            var t = new TreeNode
            {
                val = 1, left = new TreeNode {val = 1, left = new TreeNode {val = 1, left = new TreeNode {val = 1}}},
                right = new TreeNode {val = 1, right = new TreeNode {val = 1, right = new TreeNode {val = 1}}}
            };
            Assert.AreEqual(8, WidthOfBinaryTree(t));
        }

        public int WidthOfBinaryTree(TreeNode root)
        {

            max = 0;
            SetWidthOfBinaryTree(root, 0, 1);
            return max;
        }

        Dictionary<int, int> leftMost = new Dictionary<int, int>();
        private int max;
        public void SetWidthOfBinaryTree(TreeNode root, int depth, int position)
        {

            if(root == null) return;

            
            leftMost.TryAdd(depth, position);
            max = Math.Max(max, position - leftMost[depth] + 1);

            SetWidthOfBinaryTree(root.left, depth + 1, position * 2);
            SetWidthOfBinaryTree(root.right, depth + 1, position * 2 + 1);
        }
    }
}
