using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Design_a_Stack_With_Increment_Operation;

public class CustomStack
{
    private List<int> stack;
    private int MAXSIZE;
    
    public CustomStack(int maxSize) {
        stack = new List<int>();
        MAXSIZE=maxSize;
    }
    
    public void Push(int x) {
        if(stack.Count<MAXSIZE)
            stack.Add(x);
    }
    
    public int Pop()
    {
        if(stack.Count==0)
            return -1;
        
        var cur = stack[stack.Count-1];
        stack.RemoveAt(stack.Count-1);
        return cur;
    }
    
    public void Increment(int k, int val) {
        for(int i=0; i<Math.Min(k,stack.Count); i++)
            stack[i]+=val;
    }
}