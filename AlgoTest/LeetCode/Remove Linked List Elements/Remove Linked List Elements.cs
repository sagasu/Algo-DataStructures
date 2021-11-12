using System;
using System.Collections.Generic;
using System.Text;
using AlgoTest.LeetCode.RotateList;

namespace AlgoTest.LeetCode.Remove_Linked_List_Elements
{
    public class Remove_Linked_List_Elements
    {
        public void Test()
        {

        }
        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null) return null;

            head.next = RemoveElements(head.next, val);

            return head.val == val ? head.next : head;
        }
    }
}
