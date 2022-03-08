using AlgoTest.LeetCode.RotateList;

namespace AlgoTest.LeetCode.Linked_List_Cycle
{
    internal class Linked_List_Cycle
    {
        public bool HasCycle(ListNode head)
        {
            if (head == null) return false;

            var slow = head;
            var fast = head.next;

            while (slow != fast)
            {
                if (fast == null || fast.next == null)
                {
                    return false;
                }
                slow = slow.next;
                fast = fast.next.next;
            }

            return true;
        }
    }
}
