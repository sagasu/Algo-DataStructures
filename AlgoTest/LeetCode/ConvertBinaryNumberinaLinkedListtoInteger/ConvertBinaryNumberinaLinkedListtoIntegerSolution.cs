using AlgoTest.LeetCode.RotateList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.ConvertBinaryNumberinaLinkedListtoInteger
{
    [TestClass]
    public class ConvertBinaryNumberinaLinkedListtoIntegerSolution
    {
        [TestMethod]
        public void Test()
        {
            var t = new ListNode(1, new ListNode(0, new ListNode(1)));
            Assert.AreEqual(5, GetDecimalValue(t));
        }
        // Idea is to set return dec to 0
        // then we shift to left, and it will create a 0 at the end and we are using masking to mask that 0 with a next head.val
        public int GetDecimalValue(ListNode head)
        {
            
            var dec = 0;
            while (head != null)
            {
                dec = dec << 1 | head.val;
                head = head.next;
            }

            return dec;
        }
    }
}
