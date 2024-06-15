using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Maximum_Elegance_of_a_K_Length_Subsequence;

public class Maximum_Elegance_of_a_K_Length_Subsequence
{
    public long FindMaximumElegance(int[][] items, int k) {
        var sortedItems = items.OrderBy(item=>-item[0]).ToArray();
        HashSet<int> C = new ();         
        Stack<int> S = new (); /*index of repeated category*/
        long P = 0; 
        for(var i=0; i<k; i++)
        {
            if(C.Contains(sortedItems[i][1]))
                S.Push(i);
            else
                C.Add(sortedItems[i][1]);
            
            P += sortedItems[i][0];
        }
        
        var E = P + (long)C.Count * C.Count;
        if(C.Count==k || k== items.Length) return E;
        
        var p = k;
        while(S.Count>0 && p<sortedItems.Length)
        {
            if(C.Contains(sortedItems[p][1]))
            {
                p++;
                continue;
            }

            C.Add(sortedItems[p][1]); 
            var idx = S.Pop();
            P  = P - sortedItems[idx][0] + sortedItems[p][0];
            E = Math.Max(E,P + (long)C.Count * C.Count); 
            p++;
        }
        
        return E;
    }
}