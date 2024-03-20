using AlgoTest.LeetCode.RotateList;

namespace AlgoTest.LeetCode.Merge_In_Between_Linked_Lists;

public class Merge_In_Between_Linked_Lists
{
    public ListNode? MergeInBetween(ListNode list1, int a, int b, ListNode list2)
    {
        var start = list1;
        
        for (var i = 0; i < a - 1; i++)
            start = start?.next;

        var end = start;
        for (var i = a; i <= b; i++)
            end = end?.next;

        start.next = list2;

        while (list2.next != null)
            list2 = list2.next;
        
        list2.next = end?.next;

        return list1;
    }
}