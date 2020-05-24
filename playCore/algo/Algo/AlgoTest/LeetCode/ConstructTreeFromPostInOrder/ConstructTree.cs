using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.ConstructTreeFromPostInOrder
{
    [TestClass]
    public class ConstructTree
    {
        [TestMethod]
        public void Test()
        {
            var inorder = new[]{9, 3, 15, 20, 7};
            var postorder = new[]{9, 15, 7, 20, 3};
            BuildTree(inorder, postorder);

        }

        private List<int> reversedPostOrder;
        private bool firstRun = true;
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder.Length == 0)
                return null;

            reversedPostOrder = postorder.Reverse().ToList();
            var root = new TreeNode();
            BuildTree(root, inorder.ToList());
            return root;
        }

        private int GetNextRoot(List<int> inorder)
        {
            if (firstRun)
            {
                firstRun = false;
                return reversedPostOrder.First();
            }


            var nextRoot = reversedPostOrder.First(x=> inorder.Contains(x));
            return nextRoot;
        }

        public void BuildTree(TreeNode node, List<int> inorder)
        {
            var root = GetNextRoot(inorder);
            var leftNodes = new List<int>();
            var rightNodes = new List<int>();
            var isLeftNode = true;
            foreach (var inorderValue in inorder)
            {
                if (inorderValue == root)
                {
                    isLeftNode = false;
                }
                else
                {
                    if (isLeftNode)
                    {
                        leftNodes.Add(inorderValue);
                    }
                    else
                    {
                        rightNodes.Add(inorderValue);
                    }
                }
            }

            node.val = root;
            if (leftNodes.Any())
            {
                node.left = new TreeNode();
                BuildTree(node.left, leftNodes);
            }
            if (rightNodes.Any())
            {
                node.right = new TreeNode();
                BuildTree(node.right, rightNodes);
            }
        }
    }
}
