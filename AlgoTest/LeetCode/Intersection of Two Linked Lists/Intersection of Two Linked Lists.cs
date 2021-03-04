using System;
using System.Collections.Generic;
using System.Text;
using AlgoTest.LeetCode.RotateList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Intersection_of_Two_Linked_Lists
{
    [TestClass]
    public class Intersection_of_Two_Linked_Lists
    {
        [TestMethod]
        public void Test()
        {
            var nodes = new ListNode(8, new ListNode(4, new ListNode(5)));
            var a = new ListNode(4, new ListNode(1, nodes));
            var b = new ListNode(5, new ListNode(6, new ListNode(1, nodes)));
            Assert.AreEqual(8, GetIntersectionNode(a,b).val);
        }


        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode ret = null;
            var head = headA;
            while (head != null)
            {
                head.val = -head.val;
                head = head.next;
            }

            head = headB;
            while (head != null)
            {
                if (head.val < 0)
                {
                    ret = head;
                    break;
                }
                head = head.next;
            }

            head = headA;
            while (head != null)
            {
                head.val = Math.Abs(head.val);
                head = head.next;
            }


            return ret;
        }
    }
}
