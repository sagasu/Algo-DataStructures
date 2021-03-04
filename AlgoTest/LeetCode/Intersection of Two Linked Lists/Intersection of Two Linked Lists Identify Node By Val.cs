using System;
using System.Collections.Generic;
using System.Text;
using AlgoTest.LeetCode.RotateList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Intersection_of_Two_Linked_Lists
{
    [TestClass]
    public class Intersection_of_Two_Linked_Lists_Identify_Node_By_Val
    {
        [TestMethod]
        public void Test()
        {
            var a = new ListNode(4, new ListNode(1, new ListNode(8, new ListNode(4, new ListNode(5)))));
            var b = new ListNode(5, new ListNode(6, new ListNode(1, new ListNode(8, new ListNode(4, new ListNode(5))))));
            // In my solution it is 1, because it is first val of node that is common between a and b
            Assert.AreEqual(8, GetIntersectionNode(a,b).val);
        }

        // This is a solution for a different problem. It makes an assumption that we can identify a node by a val, it means that if both of them have a val of 1 then it is this same node.
        // This is not true in this problem. In problem that LC is presenting both nodes may have last node val set to 5, and still this is not this same node.
        // In a problem from LC to identify a common node we need to change a val, to check if the val will change then in both node a and b to be sure that it is this same node.
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var head = headA;
            var stackA = new Stack<ListNode>();
            while (head != null)
            {
                stackA.Push(head);
                head = head.next;
            }

            var stackB = new Stack<ListNode>();
            head = headB;
            while (head != null)
            {
                stackB.Push(head);
                head = head.next;
            }

            ListNode a;
            ListNode b;
            ListNode ret = null;
            while (stackA.TryPop(out a) && stackB.TryPop(out b))
            {
                if (a.val == b.val) ret = a;
                else break;
            }

            return ret;
        }
    }
}
