using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AlgoTest.LeetCode.ReverseLinkedList
{
    class ReverseLinkedList
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
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return null;
            if (head.next == null)
                return head;

            var curent = head;
            var stack = new Stack<int>();

            while (curent != null)
            {
                stack.Push(curent.val);
                curent = curent.next;
            }

            ListNode ret = new ListNode();
            ListNode next = ret;
            while (stack.Count > 0)
            {
                next.next = new ListNode(stack.Pop());
                next = next.next;
            }
            return ret.next;
        }

        // Different solution, by repointing next to previous
        public ListNode ReverseList2(ListNode head)
        {
            if (head == null)
                return null;
            if (head.next == null)
                return head;

            var current = head;
            ListNode previous = null;
            while (true)
            {
                var next = current.next;
                current.next = previous;
                previous = current;
                current = next;
                if (current == null)
                    break;
            }
            return previous;
        }
    }
}
