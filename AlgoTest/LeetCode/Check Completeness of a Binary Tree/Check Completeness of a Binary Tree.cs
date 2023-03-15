using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Check_Completeness_of_a_Binary_Tree
{
    [TestClass]
    public class Check_Completeness_of_a_Binary_Tree
    {
        [TestMethod]
        public void Test()
        {
            var t = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)),
                new TreeNode(3, new TreeNode(6)));
            Assert.IsTrue(IsCompleteTree(t));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)),
                new TreeNode(3,null, new TreeNode(6)));
            Assert.IsFalse(IsCompleteTree(t));
        }
        
        [TestMethod]
        public void Test4()
        {
            var t = new TreeNode(1, new TreeNode(2, new TreeNode(5), new TreeNode(6)),
                new TreeNode(3));
            Assert.IsTrue(IsCompleteTree(t));
        }
        
        [TestMethod]
        public void Test5()
        {
            var t = new TreeNode(1, new TreeNode(2, new TreeNode(5)),
                new TreeNode(3, new TreeNode(7), new TreeNode(8)));
            Assert.IsFalse(IsCompleteTree(t));
        }
        
        [TestMethod]
        public void Test6()
        {
            var t = new TreeNode(1, new TreeNode(2, new TreeNode(4, new TreeNode(8)),new TreeNode(5)),
                new TreeNode(3, new TreeNode(6), new TreeNode(7)));
            Assert.IsTrue(IsCompleteTree(t));
        }
        [TestMethod]
        public void Test7()
        {
            var t = new TreeNode(1, new TreeNode(2, new TreeNode(4, new TreeNode(8)),new TreeNode(5)),
                new TreeNode(3, new TreeNode(6)));
            Assert.IsFalse(IsCompleteTree(t));
        }
        
        [TestMethod]
        public void Test3()
        {
            var t = new TreeNode(1);
            Assert.IsTrue(IsCompleteTree(t));
        }

        private int? treeLevel = null;
        private bool canBeSmaller = true;
        public bool IsCompleteTree(TreeNode root)
        {
            bool IsComplete(TreeNode root, int level)
            {
                if (root.left == null && root.right == null)
                {
                    if (treeLevel == null)
                    {
                        treeLevel = level;
                        return true;
                    }
                    else
                    {
                        if(level == treeLevel) return true;
                        if (level + 1 == treeLevel && canBeSmaller)
                        {
                            treeLevel -= 1;
                            canBeSmaller = false;
                            return true;
                        }

                        return false;
                    }
                }

                if (root.left == null && root.right != null) return false;
                

                var isValid = false;
                if (root.left != null) isValid = IsComplete(root.left, level + 1);
                if (root.right == null && root.left != null)
                {
                    if (canBeSmaller)
                    {
                        canBeSmaller = false;
                        treeLevel -= 1;
                    }
                    else return false;
                    
                }
                
                if (root.right != null) isValid = isValid && IsComplete(root.right, level + 1);

                return isValid;
            }

            return IsComplete(root, 0);
        }
    }
}
