using System;
using System.Text;
using AlgoTest.LeetCode.RotateList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.ConvertBinaryNumberinaLinkedListtoInteger
{
    [TestClass]
    public class ConvertBinaryNumberinaLinkedListtoInteger
    {
        [TestMethod]
        public void Test()
        {
            var t = new ListNode(1, new ListNode(0, new ListNode(1)));
            Assert.AreEqual(5, GetDecimalValue(t));
        }

        public int GetDecimalValue(ListNode head)
        {
            
            var sb = new StringBuilder();
            sb.Append(head.val);

            while (true)
            {
                var n = head.next;
                if (n == null)
                    break;
                
                sb.Append(n.val);
                head = head.next;
            }

            return Convert.ToInt32(sb.ToString(), 2);
        }
    }
}
