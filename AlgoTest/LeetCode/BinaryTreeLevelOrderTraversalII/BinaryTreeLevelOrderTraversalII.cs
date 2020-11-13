using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.BinaryTreeLevelOrderTraversalII
{
    [TestClass]
    public class BinaryTreeLevelOrderTraversalII
    {
        [TestMethod]
        public void Test()
        {
            var t = new TreeNode{val = 3, left = new TreeNode{val = 9}, right = new TreeNode{val = 20, left = new TreeNode{val = 15},right = new TreeNode{val = 7}}};
            LevelOrderBottom(t);
        }

        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            if (root == null)
                return res;
            GetLevelOrder(root, 0);
            return res.Reverse().ToList();
        }

        IList<IList<int>> res = new List<IList<int>>();

        public void GetLevelOrder(TreeNode root, int index)
        {
            if (root.left != null)
                GetLevelOrder(root.left, index + 1);

            if (res.Count <= index)
            {
                while (res.Count <= index)
                {
                    res.Add(new List<int>());
                }
                res[index].Add(root.val);
            }
            else
            {
                res[index].Add(root.val);
            }

            if(root.right != null)
                GetLevelOrder(root.right, index + 1);
        }
    }
}
