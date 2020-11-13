using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.FlattenMultilevelDoublyLinkedList
{
    class FlattenMultilevelDoublyLinkedList
    {
        public Node Flatten(Node head)
        {
            if (head == null || (head.next == null && head.child == null))
                return head;


            tail = new Node();
            var newHead = tail;
            BuildFlat(head);
            return newHead;
        }
        Node tail = new Node();
        public void BuildFlat(Node head)
        {
            tail.val = head.val;

            if (head.child != null)
            {
                tail.next = new Node();
                tail.next.prev = tail;
                tail = tail.next;
                BuildFlat(head.child);
            }

            if (head.next != null)
            {
                tail.next = new Node();
                tail.next.prev = tail;
                tail = tail.next;
                BuildFlat(head.next);
            }
        }
    }

    public class Node
    {
        public int val;
        public Node prev;
        public Node next;
        public Node child;
    }
}
