using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoTest.LeetCode.RotateList;

namespace AlgoTest.LeetCode.Reverse_Nodes_in_k_Group
{
    internal class Reverse_Nodes_in_k_Group
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            var kList = new List<ListNode>();
            var counter = 0;
            while (head != null)
            {
                if (counter == 0) kList.Add(head);
                
                counter++;

                var temp = head.next;
                
                if (counter == k)
                {
                    counter = 0;
                    head.next = null;
                }

                head = temp;
            }

            if (kList.Count == 0) return head;
            
            var dummy = new ListNode(0);
            var runner = dummy;

            for (var i = 0; i < kList.Count - 1; i++)
            {
                var temp = kList[i];
                runner.next = ReverseList(kList[i]);
                runner = temp;
            }

            runner.next = counter > 0 ? kList[^1] : ReverseList(kList[^1]);
            
            return dummy.next;
        }


        private ListNode ReverseList(ListNode head)
        {
            ListNode pre = null;
            while (head != null)
            {
                var temp = head.next;
                head.next = pre;
                pre = head;
                head = temp;
            }
            return pre;
        }
    }
}
