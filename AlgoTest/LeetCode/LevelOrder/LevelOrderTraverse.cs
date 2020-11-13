using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.LevelOrder
{

    


    class NodeWithLevel
    {
        public TreeNode node;
        public int level;
    }
    [TestClass]
    public class LevelOrderTraverse
    {

        [TestMethod]
        public void test()
        {
            var root = new TreeNode
            {
                val = 3,
                left = new TreeNode{val = 9},
                right = new TreeNode{val = 20, left = new TreeNode{val = 15}, right = new TreeNode{val = 7}},

            };
            var order = LevelOrder(root);
            for (var i=0;i<order.Count; i++)
            {
                var lev = order[i];
                foreach (var va in lev)
                {
                    Console.Out.WriteLine($"{va}, {i}");   
                }
            }
        }

        List<IList<int>> orderPrint = new List<IList<int>>();
        Queue<NodeWithLevel> queue = new Queue<NodeWithLevel>();

        public void OrderPrintAddWithLevel(int val, int level)
        {
            if (orderPrint.Count > level)
            {
                var value = orderPrint[level];
                if (value == null)
                {
                    orderPrint[level] = new List<int>() { val };
                }
                else
                {
                    orderPrint[level].Add(val);
                }
            }
            else
            {
                orderPrint.Add(new List<int>() { val });
            }
        }

        private void QueueAddWIthLevel(TreeNode node, int level)
        {
            queue.Enqueue(new NodeWithLevel{node = node, level = level});
        }

        
        IList<IList<int>> LevelOrder(TreeNode root)
        {
            if (root == null)
                return orderPrint;

            QueueAddWIthLevel(root, 0);
            ProduceLevelOrder(root, queue, 0);

            return orderPrint;
        }

        void ProduceLevelOrder(TreeNode root, Queue<NodeWithLevel> queue, int level)
        {
            while (queue.Any())
            {
                var nodeWithLevel = queue.Dequeue();
                OrderPrintAddWithLevel(nodeWithLevel.node.val, nodeWithLevel.level);
                level = nodeWithLevel.level;
                root = nodeWithLevel.node;

                if (root.left != null)
                    QueueAddWIthLevel(root.left, level+1);

                if (root.right != null)
                    QueueAddWIthLevel(root.right, level+1);

            }
        }
    }
}
