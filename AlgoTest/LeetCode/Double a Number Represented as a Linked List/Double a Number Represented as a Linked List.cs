using AlgoTest.LeetCode.RotateList;

namespace AlgoTest.LeetCode.Double_a_Number_Represented_as_a_Linked_List;

public class Double_a_Number_Represented_as_a_Linked_List
{
    public ListNode DoubleIt(ListNode head) {
        head = head.val >= 5 ? new ListNode(0, head) : head;

        for (var node = head; node != null; node = node.next)
        {
            var carry = node.next is { val: >= 5 } ? 1 : 0;

            node.val = node.val * 2 % 10 + carry;
        }

        return head;
    }
}