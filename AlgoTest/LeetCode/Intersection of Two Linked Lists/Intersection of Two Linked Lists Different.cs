using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoTest.LeetCode.RotateList;

namespace AlgoTest.LeetCode.Intersection_of_Two_Linked_Lists
{
    internal class Intersection_of_Two_Linked_Lists_Different
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var listA = headA;
            var listB = headB;

            var lengthA = GetListLength(listA);
            var lengthB = GetListLength(listB);

            for (var i = 0; i < lengthA - lengthB; i++) listA = listA!.next;
            

            for (var i = 0; i < lengthB - lengthA; i++) listB = listB!.next;
            

            while (listA != null)
            {
                if (listA == listB) return listA;

                listA = listA.next;
                listB = listB!.next;
            }

            return null;
        }

        public int GetListLength(ListNode? listNode)
        {
            var length = 0;
            while (listNode != null)
            {
                listNode = listNode.next;
                length++;
            }

            return length;
        }
    }
}
