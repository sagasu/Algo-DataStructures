using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.PathSum
{
    [TestClass]
    public class PathSum
    {
        [TestMethod]
        public void Test()
        {
            var root = new TreeNode{val = -2, right = new TreeNode{val = -3}};
            Assert.AreEqual(true, HasPathSum(root, -5));
        }

        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
                return sum == 0 ? true : false;

            return HasPathSum(root, sum, 0);
        }

        public bool HasPathSum(TreeNode root, int sum, int count)
        {
            var val = count + root.val;
            if (sum == val && root.left == null && root.right == null)
                return true;
            
            if (root.left != null && HasPathSum(root.left, sum, val))
                return true;

            if (root.right != null && HasPathSum(root.right, sum, val))
                return true;

            return false;
        }
    }
}
