﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Pseudo_Palindromic_Paths_in_a_Binary_Tree
{
    [TestClass]
    // Ttime out naive implementation
    public class Pseudo_Palindromic_Paths_in_a_Binary_Tree
    {

        [TestMethod]
        public void Test1()
        {
            //[2,3,1,3,1,null,1]
            var t = new TreeNode(2, new TreeNode(3, new TreeNode(3), new TreeNode(1)), new TreeNode(1, null, new TreeNode(1)));
            Assert.AreEqual(2, PseudoPalindromicPaths(t));
        }
        
        [TestMethod]
        public void Test2()
        {
            // [8, 8,null, 7,7,null,null, 2,4,null,8,null,7,null,1 ]
            var t = new TreeNode(8, new TreeNode(8, new TreeNode(7), new TreeNode(7, new TreeNode(2, null, new TreeNode(8, null, new TreeNode(1))), new TreeNode(4, null, new TreeNode(7)))));
            Assert.AreEqual(2, PseudoPalindromicPaths(t));
        }

        public int PseudoPalindromicPaths(TreeNode root)
        {
            Traverse(root);
            return foundPalindromes;
        }

        private int foundPalindromes = 0;
        int[] count = new int[10];

        public void Traverse(TreeNode root)
        {
            if (root == null) return;

            count[root.val] += 1;
            if (root.left == null && root.right == null)
            {
                if(IsPandrome()) foundPalindromes += 1;
                count[root.val] -= 1;
                return;
            }

            Traverse(root.left);

            Traverse(root.right);

            count[root.val] -= 1;
        }

        private bool IsPandrome()
        {
            var isFirstOddFound = false;
            for (var i = 1; i < count.Length; i++)
            {
                if (count[i] % 2 == 1)
                {
                    if (isFirstOddFound) return false;
                    isFirstOddFound = true;
                }
            }

            return true;
        }
    }
}
