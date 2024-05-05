using System.Collections.Generic;
using AlgoTest.LeetCode.RotateList;

namespace AlgoTest.LeetCode.Remove_Nodes_From_Linked_List;

public class Remove_Nodes_From_Linked_List
{
    public ListNode RemoveNodes(ListNode head) {
        var l = new List<ListNode>();
        var curr = head;
        
        while(curr!=null){
            if(l.Count!=0)
                while(l.Count!=0 && l[l.Count-1].val<curr.val)
                    l.RemoveAt(l.Count-1);
            
            l.Add(curr);
            curr=curr.next;
        }
        
        var dummyhead=new ListNode();
        var trav=dummyhead;
        
        foreach (var t in l)
        {
            trav.next=t;
            trav=trav.next;
        }
        
        return dummyhead.next;
    }
}