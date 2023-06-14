using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Minimum_Absolute_Difference_in_BST
{
    [TestClass]
    public class Minimum_Absolute_Difference_in_BST
    {
        //[236,104,701,null,227,null,911]

        [TestMethod]
        public void Test() => Assert.AreEqual(9,
            GetMinimumDifference(new TreeNode(236, new TreeNode(104, null, new TreeNode(227)),
                new TreeNode(701, null, new TreeNode(911)))));


        List<int> list = new();
        public int GetMinimumDifference(TreeNode root)
        {
            DFS(root);
            list.Sort();
            var min = int.MaxValue;
            for (var i = 1; i < list.Count; i++)
                min = Math.Min(min, list[i] - list[i - 1]);

            return min;
        }

        private void DFS(TreeNode root)
        {
            if (root == null) return;
            list.Add(root.val);
            DFS(root.left);
            DFS(root.right);
        }

        public int GetMinimumDifferenceDifferentProblem(TreeNode root)
        {
            if(root is null || (root.left is null && root.right is null)) return 0;
            int Traverse(TreeNode node, int parentValue)
            {
                if(node is null) return int.MaxValue;
                var min= Math.Min(Traverse(node.left, node.val), Traverse(node.right, node.val));
                return Math.Min(min, Math.Abs(parentValue - node.val));
            }

            return Math.Min(Traverse(root.left, root.val), Traverse(root.right, root.val));
        }
    }
}
