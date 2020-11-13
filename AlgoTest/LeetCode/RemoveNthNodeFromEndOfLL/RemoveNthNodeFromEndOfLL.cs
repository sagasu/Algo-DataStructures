using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace AlgoTest.LeetCode.RemoveNthNodeFromEndOfLL
{
    class RemoveNthNodeFromEndOfLL
    {

        public class ListNode {
              public int val;
              public ListNode next;
              public ListNode(int val=0, ListNode next=null) {
                  this.val = val;
                 this.next = next;
             }
         }
 

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head.next == null && n == 1)
                return null;

            var accessList = new List<ListNode>();
            var lLenght = 1;
            accessList.Add(head);
            var current = head.next;

            while (true)
            {

                if (current == null)
                {
                    if (lLenght - n - 1 < 0)
                        return head.next;

                    var previousNode = accessList[lLenght - n - 1];
                    previousNode.next = previousNode.next.next;
                    break;
                }
                accessList.Add(current);
                lLenght += 1;
                current = current.next;

            }

            return head;
        }
    }
}
