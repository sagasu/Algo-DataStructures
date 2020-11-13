using AlgoTest.LeetCode.RotateList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.InsertionSortList
{
    [TestClass]
    public class InsertionSortListSolution
    {
        [TestMethod]
        public void Test()
        {
            //var t = new ListNode(4, new ListNode(2, new ListNode(1, new ListNode(3))));
            //var t = new ListNode(-1, new ListNode(5, new ListNode(3, new ListNode(4, new ListNode(0)))));
            var t = new ListNode(3, new ListNode(4, new ListNode(1)));
            InsertionSortList(t);
        }

        private ListNode headPointer;
        public ListNode InsertionSortList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            headPointer = new ListNode();
            headPointer.next = new ListNode(head.val);
            headPointer.next.next = null;

            Sort(head.next);
            return headPointer.next;
        }

        private void Sort(ListNode element)
        {
            var sortedList = headPointer;
            while (element != null)
            {
                var isElementFound = false;
                while (sortedList.next != null)
                {
                    if (element.val < sortedList.next.val)
                    {
                        var temp = sortedList.next;
                        sortedList.next = new ListNode(element.val);
                        sortedList.next.next = temp;
                        sortedList = headPointer;
                        isElementFound = true;
                        break;
                    }

                    sortedList = sortedList.next;
                }

                if (!isElementFound)
                {
                    sortedList.next = new ListNode(element.val);
                    sortedList = headPointer;
                }

                element = element.next;
            }
        }
    }
}
