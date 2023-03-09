using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoTest.LeetCode.RotateList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.LinkedListCycleII
{
    [TestClass]
    public class Linked_List_Cycle_II
    {
        [TestMethod]
        public void Test()
        {
            var head = new ListNode(3);
            head.next = new ListNode(2, new ListNode(0, new ListNode(-4, head)));

            Assert.AreEqual(2, DetectCycleNoRecursionApproach(head).val);
        }
        
        [TestMethod]
        public void Test1()
        {
            var head = new ListNode(1);
            head.next = new ListNode(2, head);
            Assert.AreEqual(0, DetectCycleNoRecursionApproach(head).val);
        }
        [TestMethod]
        public void Test2()
        {
            Assert.IsNull(DetectCycleNoRecursionApproach(new ListNode(1)));
        }
        
        [TestMethod]
        public void TestRec()
        {
            var head = new ListNode(3);
            head.next = new ListNode(2, new ListNode(0, new ListNode(-4, head)));

            Assert.AreEqual(2, DetectCycle(head).val);
        }
        
        [TestMethod]
        public void TestRec1()
        {
            var head = new ListNode(1);
            head.next = new ListNode(2, head);
            Assert.AreEqual(0, DetectCycle(head).val);
        }
        [TestMethod]
        public void TestRec2()
        {
            Assert.IsNull(DetectCycle(new ListNode(1)));
        }

        public ListNode DetectCycleNoRecursionApproach(ListNode head)
        {
            var newHead = new ListNode(-1, head); // this is needed for an algorithm that finds where to loop start to work

            var fast = newHead;
            var slow = newHead;
            while (fast.next != null)
            {
                fast = fast.next;
                if(fast.next != null) fast = fast.next;
                slow = slow.next;

                if (fast.next == slow.next) break;
            }

            if (fast.next == null) return null;

            // there is a cycle so find where it starts
            slow = newHead;
            while (slow.next != fast.next)
            {
                slow = slow.next;
                fast = fast.next;
            }
            return slow.next;
        }
        
        public ListNode DetectCycle(ListNode head)
        {
            ListNode DetectCycle(ListNode fast, ListNode slow)
            {
                if (fast == null || fast.next == null || fast.next.next == null) return null;
                if (fast == slow) return fast;
                return DetectCycle(fast.next.next, slow.next);
            }

            var newHead = new ListNode(-1, head); // this is needed for an algorithm that finds where to loop start to work
            var meetingNode = DetectCycle(newHead, newHead);
            if (meetingNode == null) return null;

            // there is a cycle so find where it starts
            var slow = newHead;
            while (slow.next != meetingNode.next)
            {
                slow = slow.next;
                meetingNode = meetingNode.next;
            }
            return slow.next;
        }
    }
}
