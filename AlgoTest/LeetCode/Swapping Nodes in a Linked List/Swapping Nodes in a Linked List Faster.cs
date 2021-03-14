using AlgoTest.LeetCode.RotateList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Swapping_Nodes_in_a_Linked_List2
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
            var first = head;
            var second= head;
            for (var i = 1; i < k; i++)
            {
                first = first.next;
            }

            var firstPointer = first;
            var firstValue = first.val;

            // Find the second element, based on a first element - we already know that first is shifted from head by the distance we need it from the back.
            while (true)
            {
                first = first.next;
                if (first == null) break;
                second = second.next;
            }

            firstPointer.val = second.val;
            second.val = firstValue;

            return head;
        }
    }
}
