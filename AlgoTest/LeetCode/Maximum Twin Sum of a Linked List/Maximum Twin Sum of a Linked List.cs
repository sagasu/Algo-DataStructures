using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoTest.LeetCode.RotateList;

namespace AlgoTest.LeetCode.Maximum_Twin_Sum_of_a_Linked_List
{
    internal class Maximum_Twin_Sum_of_a_Linked_List
    {
        public int PairSum(ListNode head)
        {
            var res = 0;
            var lst = new List<int>();

            var node = head;

            while (node != null)
            {
                lst.Add(node.val);
                node = node.next;
                lst.Add(node.val);
                node = node.next;
            }

            for (var i = 0; i < lst.Count / 2; i++)
                res = Math.Max(res, lst[i] + lst[lst.Count - i - 1]);
            
            return res;
        }
    }
}
