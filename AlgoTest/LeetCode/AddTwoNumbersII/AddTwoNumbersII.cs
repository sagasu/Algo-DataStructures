using System.Collections.Generic;
using AlgoTest.LeetCode.RotateList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.AddTwoNumbersII
{
    [TestClass]
    public class AddTwoNumbersII
    {
        [TestMethod]
        public void Test()
        {
            var t = new ListNode(7, new ListNode(2, new ListNode(4, new ListNode(3))));
            var n = new ListNode(5, new ListNode(6, new ListNode(4)));
            AddTwoNumbers(t, n);

            
            t = new ListNode(5);
            n = new ListNode(5);
            AddTwoNumbers(t, n);
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var l1Stack = new Stack<int>();
            var nextl1 = l1;
            while (nextl1 != null)
            {
                l1Stack.Push(nextl1.val);
                nextl1 = nextl1.next;
            }

            var l2Stack = new Stack<int>();
            var nextl2 = l2;
            while (nextl2 != null)
            {
                l2Stack.Push(nextl2.val);
                nextl2 = nextl2.next;
            }

            
            int v1 = 0;
            int v2 = 0;
            var carry = 0;
            var stack = new Stack<int>();
            ListNode head = null;
            while (true)
            {
                var v1Has = l1Stack.TryPop(out v1);
                var v2Has = l2Stack.TryPop(out v2);

                if (!v1Has && !v2Has)
                    break;
                
                var sum = v1 + v2 + carry;
                carry = 0;
                if (sum >= 10)
                {
                    carry += 1;
                    sum -= 10;
                }

                stack.Push(sum);
            }

            if(carry == 1)
                stack.Push(1);

            ListNode res = null;
            foreach (var re in stack)
            {
                if (res == null)
                {
                    res = new ListNode();
                    head = res;
                }
                else
                {
                    res.next = new ListNode();
                    res = res.next;
                }

                res.val = re;
            }

            return head;
        }
    }
}
