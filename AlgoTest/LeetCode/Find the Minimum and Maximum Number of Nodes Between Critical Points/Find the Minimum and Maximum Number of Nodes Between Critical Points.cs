using System;
using System.Collections.Generic;
using AlgoTest.LeetCode.RotateList;

namespace AlgoTest.LeetCode.Find_the_Minimum_and_Maximum_Number_of_Nodes_Between_Critical_Points;

public class Find_the_Minimum_and_Maximum_Number_of_Nodes_Between_Critical_Points
{
    public int[] NodesBetweenCriticalPoints(ListNode head) {
        var list = new List<int>();
        var rs = new int[2]{-1, -1};
        while(head != null){
            list.Add(head.val);
            head = head.next;
        }
        
        if(list.Count == 2)
            return rs;
        
        var cp = new List<int>();
        for(var i = 1; i < list.Count - 1; i++){
            if(list[i] > list[i - 1] && list[i] > list[i + 1])
                cp.Add(i);
            else if(list[i] < list[i - 1] && list[i] < list[i + 1])
                cp.Add(i);
        }
        
        if(cp.Count < 2)
            return rs;
         
        rs[0] = int.MaxValue;
        for(var j = 1; j < cp.Count; j++){
            rs[0] = Math.Min(rs[0], cp[j] - cp[j - 1]);
        }
         
        rs[1] = cp[cp.Count - 1] - cp[0];
        return rs;
    }
}