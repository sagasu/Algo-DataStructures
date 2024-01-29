using System.Collections.Generic;

namespace AlgoTest.LeetCode.Implement_Queue_using_Stacks;

public class MyQueue {

    Stack<int> main = new();
    Stack<int> temp = new();

    public MyQueue() {
        
    }
    
    public void Push(int x) {
        while (main.Count > 0) temp.Push(main.Pop());
        main.Push(x);
        while (temp.Count > 0) main.Push(temp.Pop());
    }
    
    public int Pop() => main.Pop();
    
    
    public int Peek() => main.Peek();
    
    public bool Empty() => main.Count == 0;
    
}