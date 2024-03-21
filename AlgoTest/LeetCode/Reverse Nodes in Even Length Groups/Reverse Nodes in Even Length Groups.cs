using System.Collections.Generic;
using AlgoTest.LeetCode.RotateList;

namespace AlgoTest.LeetCode.Reverse_Nodes_in_Even_Length_Groups;

public class Reverse_Nodes_in_Even_Length_Groups
{
    public ListNode ReverseEvenLengthGroups(ListNode head) {
        var count = 1;
        
        var saved = head;
        
        List<int> group = new();
        
        for (ListNode node = head; node != null; node = node.next) {
            group.Add(node.val);
            
            if (group.Count == count || node.next == null) {
                if (saved != null && group.Count % 2 == 0) {
                    group.Reverse();
                    
                    for (int i = 0; i < group.Count; ++i, saved = saved.next) 
                        saved.val = group[i];
                }
                
                group.Clear();
                
                count += 1;
                saved = node.next;
            }
        }
        
        return head;
    }
}