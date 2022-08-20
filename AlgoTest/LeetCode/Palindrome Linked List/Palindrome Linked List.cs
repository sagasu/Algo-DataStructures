using System.Collections.Generic;
using AlgoTest.LeetCode.RotateList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Palindrome_Linked_List
{
    [TestClass]
    public class Palindrome_Linked_List
    {
        [TestMethod]
        public void Test()
        {
            var t  = new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1))));
            Assert.AreEqual(true, IsPalindrome(t));
        }
        
        [TestMethod]
        public void Test2()
        {
            var t  = new ListNode(1, new ListNode(2));
            Assert.AreEqual(false, IsPalindrome(t));
        }

        public bool IsPalindrome(ListNode head)
        {
            var current = head;
            var nodes = new List<int>();

            while (current != null)
            {
                nodes.Add(current.val);
                current = current.next;
            }

            var i = 0;
            var j = nodes.Count-1;
            
            while (i < j)
            {
                if (nodes[i] != nodes[j]) return false;
                i += 1;
                j -= 1;
            }

            return true;
        }
    }
}
