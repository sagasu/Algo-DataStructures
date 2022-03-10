using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoTest.LeetCode.RotateList;

namespace AlgoTest.LeetCode.Add_Two_Numbers
{
    internal class Add_Two_Numbers
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {

            var carry = 0;
            var curr = new ListNode(0);
            var head = curr;

            while (l1 != null || l2 != null || carry != 0)
            {
                var val1 = l1?.val ?? 0;
                var val2 = l2?.val ?? 0;
                var sum = val1 + val2 + carry;

                curr.next = new ListNode(sum % 10);
                curr = curr.next;
                carry = sum / 10;

                l1 = l1?.next;
                l2 = l2?.next;
            }

            return head.next;
        }
    }
}
