using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.DeleteNodeInLinkedList
{
    [TestClass]
    public class DeleteNodeInLinkedList
    {
        [TestMethod]
        public void Test()
        {
            var nodes = new ListNode(4) { next = new ListNode(5){next = new ListNode(1){next = new ListNode(9)}}};
            DeleteNode(nodes.next);
            var f = 1;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        // Delete node giving the access only to that node;
        public void DeleteNode(ListNode node)
        {
            if (node.next != null)
            {
                if (node.next.next == null)
                {
                    node.val = node.next.val;
                    node.next = null;
                }
                else
                {
                    node.val = node.next.val;
                    DeleteNode(node.next);
                }
            }

            
        }
    }
}
