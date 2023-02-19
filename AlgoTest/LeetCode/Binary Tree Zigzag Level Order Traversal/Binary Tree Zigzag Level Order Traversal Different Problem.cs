using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Binary_Tree_Zigzag_Level_Order_Traversal
{
    [TestClass]
    // This is solution when we understand zigzag per level, and not per node.
    public class Binary_Tree_Zigzag_Level_Order_Traversal_PerLevel_Solution
    {
        [TestMethod]
        public void Test()
        {
            var node = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
            ZigzagLevelOrder(node);
            var expected = new List<List<int>>(){ new List<int>() { 3 } , new List<int>() { 20, 9 }, new List<int>() { 15, 7 } };
            
        }
        
        [TestMethod]
        public void Test2()
        {
            var node = new TreeNode();
            ZigzagLevelOrder(node);
            var expected = new List<List<int>>(){ new List<int>() { 3 } , new List<int>() { 20, 9 }, new List<int>() { 15, 7 } };
            
        }

        private IList<IList<int>> order = new List<IList<int>>();
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            if (root == null) return order;
            var head = root;
            var current = new List<TreeNode>();
            current.Add(root);

            var next = new List<TreeNode>();

            ZigzagLevelOrder(current, next, 1);
            return order;
        }

        private void ZigzagLevelOrder(List<TreeNode> current, List<TreeNode> next, int level)
        {
            order.Add(new List<int>());
            TreeNode node;
            var start = level % 2 == 0 ? current.Count-1 : 0;
            var stop= level % 2 == 0 ? -1 : current.Count;
            var i = start;
            while (level % 2 == 0 ? i> stop : i < stop)
            {
                node = current[i];
                order[level-1].Add(node.val);
                if(node.left != null) next.Add(node.left);
                if(node.right != null) next.Add(node.right);
                i = level % 2 == 0 ? i-1 : i+1;
            }

            if(next.Count>0) ZigzagLevelOrder(next, new List<TreeNode>(), level + 1);
        }
    }
}
