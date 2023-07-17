using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoTest.LeetCode.RotateList;

namespace AlgoTest.LeetCode.Add_Two_Numbers_II
{
    internal class Add_Two_Numbers_II
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode res = null;
            Stack<int> s1 = ListNodeToStack(l1), s2 = ListNodeToStack(l2);
            var temp = 0;
            (s1, s2) = s1.Count < s2.Count ? (s2, s1) : (s1, s2);

            while (s1.Count > 0 || s2.Count > 0)
            {
                temp += (s1.TryPop(out int s1_val) ? s1_val : 0) + (s2.TryPop(out int s2_val) ? s2_val : 0);
                res = new ListNode(temp % 10, res);
                temp /= 10;
            }

            res = temp > 0 ? new ListNode(temp % 10, res) : res;

            return res;
        }

        private Stack<int> ListNodeToStack(ListNode node)
        {
            var stack = new Stack<int>();

            while (node != null)
            {
                stack.Push(node.val);
                node = node.next;
            }

            return stack;
        }
    }
}
