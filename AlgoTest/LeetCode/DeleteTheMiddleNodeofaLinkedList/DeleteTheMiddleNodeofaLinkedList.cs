using AlgoTest.LeetCode.RotateList;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode
{
    public class DeleteTheMiddleNodeofaLinkedList
    {
        public ListNode DeleteMiddle(ListNode head)
        {
            var c = 0;
            var t = head;
            while (t != null)
            {
                t = t.next;
                c++;
            }

            if (c == 1) return null;

            c = c / 2;
            var i = 0;
            t = head;

            while (i++ < c - 1) t = t.next;

            if (t.next != null) t.next = t.next.next;

            return head;
        }
    }
}