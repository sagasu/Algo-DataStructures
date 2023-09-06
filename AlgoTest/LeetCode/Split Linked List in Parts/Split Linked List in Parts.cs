using System;
using System.Collections.Generic;
using System.Text;
using AlgoTest.LeetCode.RotateList;

namespace AlgoTest.LeetCode.Split_Linked_List_in_Parts
{
    class Split_Linked_List_in_Parts
    {
        public ListNode[] SplitListToParts(ListNode root, int k)
        {
            if (root == null)
                return new ListNode[k];

            var res = new ListNode[k];
            var len = 0;
            var mod = 0;
            var head = root;

            while (head != null)
            {
                len++;
                head = head.next;
            }

            mod = len % k;
            head = root;

            for (var i = 0; i < k; i++)
            {
                var cur = head;
                if (head != null)
                {
                    var curLen = 0;

                    while (mod == 0 && curLen < len / k - 1 || mod != 0 && curLen < len / k)
                    {
                        cur = cur.next;
                        curLen++;
                    }

                    res[i] = head;
                    head = cur.next;
                    cur.next = null;

                    if (mod != 0)
                        mod--;
                }
            }

            return res;
        }
    }
}
