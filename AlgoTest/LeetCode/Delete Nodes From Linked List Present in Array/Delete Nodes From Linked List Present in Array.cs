using AlgoTest.LeetCode.RotateList;

namespace AlgoTest.LeetCode.Delete_Nodes_From_Linked_List_Present_in_Array;

public class Delete_Nodes_From_Linked_List_Present_in_Array
{
    public ListNode ModifiedList(int[] nums, ListNode head)
    {
        bool[] used = new bool[100001];

        for (int i = 0; i < nums.Length; i++)
            used[nums[i]] = true;

        var dummy = new ListNode(0, head);
        var pointer = dummy;

        while (pointer.next != null)
        {
            if (used[pointer.next.val])
                pointer.next = pointer.next.next;
            else
                pointer = pointer.next;
        }

        return dummy.next;
    }
}