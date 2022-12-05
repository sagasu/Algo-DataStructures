using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoTest.LeetCode.RotateList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Middle_of_the_Linked_List
{
    [TestClass]
    public class Middle_of_the_Linked_List
    {
        [TestMethod]
        public void Test()
        {
            var t = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            
            Assert.AreEqual(3, MiddleNode(t).val);
        }
        
        [TestMethod]
        public void Test2()
        {
            var t = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6))))));
            
            Assert.AreEqual(4, MiddleNode(t).val);
        }

        [TestMethod]
        public void Test3()
        {
            var t = new ListNode(1, new ListNode(2));

            Assert.AreEqual(2, MiddleNode(t).val);
        }

        [TestMethod]
        public void Test4()
        {
            var t = new ListNode(1);

            Assert.AreEqual(1, MiddleNode(t).val);
        }

        public ListNode MiddleNode(ListNode head)
        {
            var start = head;
            var count = 1;
            while (head.next != null)
            {
                count += 1;
                head = head.next;
            }
            
            var mid = count / 2;
            //if (mid % 2 == 0) 
            mid += 1;
            while (mid != 1)
            {
                mid -= 1;
                start = start.next;
            }

            return start;
        }
    }
}
