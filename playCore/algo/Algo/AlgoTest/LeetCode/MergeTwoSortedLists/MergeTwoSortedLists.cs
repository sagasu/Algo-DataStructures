using System;
using System.Collections.Generic;
using System.Text;
using AlgoTest.LeetCode.RotateList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.MergeTwoSortedLists
{
    [TestClass]
    public class MergeTwoSortedLists
    {
        [TestMethod]
        public void Test()
        {
            //var t1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            //var t2 = new ListNode(1, new ListNode(3, new ListNode(4)));

            var t1 = new ListNode(1);
            ListNode t2 = null;

            MergeTwoLists(t1, t2);
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var dummy = new ListNode(-1);

            var cur = dummy;
            var cur1 = l1;
            var cur2 = l2;

            while (cur1 != null && cur2 != null)
            {
                if (cur1.val <= cur2.val)
                {
                    cur.next = cur1;
                    cur1 = cur1.next;
                }
                else
                {
                    cur.next = cur2;
                    cur2 = cur2.next;
                }

                cur = cur.next;
            }

            while (cur1 != null)
            {
                cur.next = cur1;
                cur = cur.next;
                cur1 = cur1.next;
            }

            while (cur2 != null)
            {
                cur.next = cur2;
                cur = cur.next;
                cur2 = cur2.next;
            }

            var newHead = dummy.next;
            dummy.next = null;

            return newHead;
        }
    }
}
