using System.Collections.Generic;
using System.Linq;
using AlgoTest.LeetCode.RotateList;

namespace AlgoTest.LeetCode.Reverse_Linked_List_II;

public class Reverse_Linked_List_II
{
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        if(left==right) return head;
        var dummy = new ListNode(-1,head);
        var counter = 0;
        var temp = dummy;
        while (counter < left-1)
        {
            temp = temp.next;
            counter++;
        }
        var stack = new Stack<ListNode>();  
        var n1 = temp.next;
        while(counter<right)
        {
            stack.Push(n1);
            n1 = n1.next;
            counter++;
        }

        while (stack.Count()>0)
        {
            temp.next = stack.Pop();
            temp = temp.next;
        }

        temp.next = n1;
        return dummy.next;
    }
}