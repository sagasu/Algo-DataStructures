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
            
            SetWidthOfBinaryTree(root, 0);
            int? maxWidth = 0;
            foreach (var row in nodes)
            {
                int? leftMost = null;
                int? rightMost = null;
                for (var i=0; i < row.Count;i++)
                {
                    if (row[i] != null && leftMost == null)
                        leftMost = i;
                    else if (row[i] != null && leftMost != null)
                        rightMost = i;
                }

                if (rightMost.HasValue && leftMost.HasValue)
                {
                    var max = rightMost - leftMost +1;
                    if (max > maxWidth)
                        maxWidth = max;
                }
                
            }

            return maxWidth ?? 0;
        }

        List<IList<int?>> nodes = new List<IList<int?>>();

        public void SetWidthOfBinaryTree(TreeNode root, int index)
        {
            while (nodes.Count <= index)
            {
                nodes.Add(new List<int?>());
            }

            if (root == null)
            {
                nodes[index].Add(null);
                return;
            }

            SetWidthOfBinaryTree(root.left, index + 1);

            nodes[index].Add(root.val);

            SetWidthOfBinaryTree(root.right, index + 1);
        }
    }
}
