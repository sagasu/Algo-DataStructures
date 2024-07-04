using AlgoTest.LeetCode.RotateList;

namespace AlgoTest.LeetCode.Merge_Nodes_in_Between_Zeros;

public class Merge_Nodes_in_Between_Zeros
{
    public ListNode MergeNodes(ListNode head)
    {
        var sum = 0;
        var tail = head;
        var curr = head.next;

        while (curr != null)
        {
            if (curr.val == 0)
            {
                tail.next = new(sum);
                tail = tail.next;
                sum = 0;
            }

            sum += curr.val;
            curr = curr.next;
        }

        return head.next;
    }
}