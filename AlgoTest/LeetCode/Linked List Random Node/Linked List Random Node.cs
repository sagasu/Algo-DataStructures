using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoTest.LeetCode.RotateList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Linked_List_Random_Node
{
    [TestClass]
    public class Linked_List_Random_Node
    {
        [TestMethod]
        public void Test()
        {
            var sol = new Solution(new ListNode(1,
                new ListNode(2,
                    new ListNode(3,
                        new ListNode(4,
                            new ListNode(5,
                                new ListNode(6,
                                    new ListNode(7, new ListNode(8, new ListNode(9, new ListNode(10)))))))))));
            Console.Out.WriteLine(sol.GetRandom());
            Console.Out.WriteLine(sol.GetRandom());
            Console.Out.WriteLine(sol.GetRandom());
            Console.Out.WriteLine(sol.GetRandom());
            Console.Out.WriteLine(sol.GetRandom());
        }

        public class Solution
        {
            public int count = 0;
            private ListNode LNode;
            public Solution(ListNode head)
            {
                LNode = head;
                if (head == null) return;
                count++;
                while (head.next != null)
                {
                    head = head.next;
                    count++;
                }
            }

            public int GetRandom()
            {
                var head = LNode;
                var rand= new Random().Next(count);
                while (rand > 0)
                {
                    head = head.next;
                    rand--;
                }
                return head.val;
            }
        }


    }
}
