using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Maximum_Level_Sum_of_a_Binary_Tree
{
    [TestClass]
    public class Maximum_Level_Sum_of_a_Binary_Tree
    {
    //1,7,0,7,-8,null,null
        [TestMethod]

    public void Test() => Assert.AreEqual(2,
        MaxLevelSum(new TreeNode(1, new TreeNode(7, new TreeNode(7), new TreeNode(-8)), new TreeNode(0))));

        public int MaxLevelSum(TreeNode root)
        {
            var levels = new List<int>();

            void Traverse(TreeNode node, int level)
            {
                if(node == null) return;

                if(levels.Count == level)
                    levels.Add(0);

                levels[level] += node.val;
                Traverse(node.left, level + 1);
                Traverse(node.right, level + 1);
            }

            Traverse(root, 0);
            var max = int.MinValue;
            var maxLevel = 0;
            for (var i = 0; i < levels.Count; i++)
            {
                if (levels[i] > max)
                {
                    max = levels[i];
                    maxLevel = i;
                }
            }
            return maxLevel+1;
        }
    }
}
