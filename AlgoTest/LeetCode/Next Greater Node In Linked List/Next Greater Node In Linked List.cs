using System.Collections.Generic;

namespace AlgoTest.LeetCode.Next_Greater_Node_In_Linked_List;

public class Next_Greater_Node_In_Linked_List
{
    public static int[] NextLargerNodes(DeleteNodeInLinkedList.DeleteNodeInLinkedList.ListNode head)
    {
        var list = new List<int>();
        for (var curr = head; curr != null; curr = curr.next)
            list.Add(curr.val);

        var indexes=new Stack<int>();
        var res = new int[list.Count];
        
        for (var i = 0; i < list.Count; i++)
        {
            while (indexes.Count != 0 && list[indexes.Peek()] < list[i])
                res[indexes.Pop()] = list[i];
            
            indexes.Push(i);
        }

        return res;
    }
}