using AlgoTest.LeetCode.RotateList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.LinkedListCycleII
{
    [TestClass]
    public class LinkedListCycleII
    {
        [TestMethod]
        public void Test()
        {

        }

        public ListNode DetectCycle(ListNode head)
        {
            var fast = head;
            var slow = head;

            while (fast?.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;

                if (fast == slow)
                {
                    return GetCycleStartingPoint(head, fast);
                }
            }

            return null;
        }

        private ListNode GetCycleStartingPoint(ListNode head, ListNode fast)
        {
            var slow = head;
            while (true)
            {
                if (slow == fast)
                    return slow;

                slow = slow.next;
                fast = fast.next;
            }
        }
    }
}
