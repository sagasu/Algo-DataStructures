using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Odd_Even_Jump;

public class Odd_Even_Jump
{
    public int OddEvenJumps(int[] A) {
        var count = 0;
        
        var n = A.Length;
        if(n==0)
            return count;
        
        var higher = new bool[n];
        var lower = new bool[n];
        var nextHighers = GetNextJumps(A, true);
        var nextLowers = GetNextJumps(A, false);
        
        higher[n-1] = true;
        lower[n-1] = true;
        count++;
        
        for(var i=n-2;i>=0;i--){
            var hi = nextHighers[i];
            var low = nextLowers[i];
            
            if(hi > -1) higher[i] = lower[hi];
            if(low > -1) lower[i] = higher[low];
            
            if(higher[i])
                count++;
        }
         
        return count;
    }
    
    private int[] GetNextJumps(int[] A, bool high){
        var next = Enumerable.Repeat(-1, A.Length).ToArray();
        
        var sortedList = A.Select((x, i) => new KeyValuePair<int, int>(x, i));
        
        sortedList = high ? sortedList.OrderBy(x => x.Key).ToList() : sortedList.OrderByDescending(x => x.Key).ToList();
                            
        var stack = new Stack<int>();
        foreach (var e in sortedList)
        {
            while (stack.Count > 0 && stack.Peek() < e.Value)
                next[stack.Pop()] = e.Value;
            stack.Push(e.Value);
        }
        return next;
    }
}