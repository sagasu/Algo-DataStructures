using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoTest.LeetCode.RotateList;

namespace AlgoTest.LeetCode.Merge_k_Sorted_Lists
{
    internal class Merge_k_Sorted_Lists
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            ListNode dummyHead, p;
            dummyHead = p = new ListNode(0);
            var pq = new PriorityQueue<ListNode,int>();
            
            foreach (var headList in lists)
            {
                if (headList != null)
                    pq.Enqueue(headList, headList.val);
            }

            while (pq.Count > 0)
            {
                var el = pq.Dequeue();
                p.next = new ListNode(el.val);
                p = p.next;

                if (el.next != null)
                    pq.Enqueue(el.next, el.next.val);
            }

            return dummyHead.next;
        }
    }
}
