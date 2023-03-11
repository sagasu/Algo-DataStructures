using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgoTest.LeetCode.RotateList;

namespace AlgoTest.LeetCode.Convert_Sorted_List_to_Binary_Search_Tree
{
    public class Convert_Sorted_List_to_Binary_Search_Tree
    {
        public TreeNode SortedListToBST(ListNode head)
        {
            ListNode GetMiddle(ListNode head)
            {
                var preHead = new ListNode(-100000000, head);
                var fast = preHead;
                var slow = preHead;
                var pre = slow;

                while (fast != null)
                {
                    fast = fast.next;
                    fast = fast?.next;
                    pre = slow;
                    slow = slow.next;
                }
                return pre;
            }

            TreeNode ToBST(ListNode head)
            {
                if(head == null) return null;
                var middlePointer = GetMiddle(head);

                var middle = middlePointer.next;
                middlePointer.next = null;
                if(middle == null) return new TreeNode(head.val);

                var current = new TreeNode(middle.val);

                if(head != middle) current.left = ToBST(head);
                current.right = ToBST(middle.next);

                return current;
            }

            return ToBST(head);
        }

        


    }
}
