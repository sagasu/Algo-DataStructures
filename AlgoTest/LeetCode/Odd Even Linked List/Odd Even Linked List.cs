using System;
using System.Collections.Generic;
using System.Text;
using AlgoTest.LeetCode.RotateList;

namespace AlgoTest.LeetCode.Odd_Even_Linked_List
{
    public class Odd_Even_Linked_List
    {
        public ListNode OddEvenList(ListNode head)
        {
            var oddHead = new ListNode();
            var oddCurrent = oddHead;
            var evenHead = new ListNode();
            var evenCurrent = evenHead;

            var current = head;
            while (current != null)
            {
                oddCurrent.next = current;
                oddCurrent = oddCurrent.next;

                current = current.next;

                if (current != null)
                {
                    evenCurrent.next = current;
                    evenCurrent = evenCurrent.next;
                    current = current.next;
                }

            }

            oddCurrent.next = evenHead.next;
            evenCurrent.next = null;
            return oddHead.next;
        }
    }
}
