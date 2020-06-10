using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AlgoTest.LeetCode.RotateList
{
    class RotateLinkedList
    {
        public class ListNode
        {
      public int val;
      public ListNode next;
      public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
                     }
  }

        public ListNode RotateRight(ListNode head, int k)
        {
            if (k == 0 || head == null || head.next == null)
                return head;
            var elements = new List<int>();
            var curr = head;
            while (true)
            {
                if (curr == null)
                    break;
                elements.Add(curr.val);
                curr = curr.next;
            }

            var ret = new ListNode();
            curr = ret;
            var iter = 0;
            var first = elements.Count - (k % elements.Count);
            while (iter < elements.Count)
            {
                var position = (first + iter) % elements.Count;
                curr.next = new ListNode(elements[position]);
                iter += 1;
                curr = curr.next;
            }


            return ret.next;
        }
    }
}
