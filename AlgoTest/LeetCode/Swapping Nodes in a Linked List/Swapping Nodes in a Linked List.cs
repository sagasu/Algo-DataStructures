using System.Collections.Generic;
using AlgoTest.LeetCode.RotateList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Swapping_Nodes_in_a_Linked_List
{
    [TestClass]
    public class Swapping_Nodes_in_a_Linked_List
    {

        [TestMethod]
        public void Test()
        {
            var t = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            SwapNodes(t, 2);

        }

        public ListNode SwapNodes(ListNode head, int k)
        {
            var elements = new List<ListNode>();

            var node = head;
            while (node != null)
            {
                elements.Add(node);
                node = node.next;
            }

            var temp = elements[k - 1].val;
            elements[k - 1].val = elements[elements.Count - k].val;
            elements[elements.Count - k].val = temp;

            return head;
        }
    }
}
