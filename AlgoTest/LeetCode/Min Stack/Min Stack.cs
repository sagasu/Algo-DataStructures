using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.Min_Stack
{
    class MinStack
    {
        Stack<int> minStack = new Stack<int>();
        Stack<int> stack = new Stack<int>();

        /** initialize your data structure here. */
        public MinStack()
        {

        }

        public void Push(int x)
        {
            stack.Push(x);

            if (!minStack.Any()) minStack.Push(x);
            else if (minStack.Peek() >= x)  minStack.Push(x);
        }

        public void Pop()
        {
            var x = stack.Pop();
            if (minStack.Peek() == x) minStack.Pop();
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return minStack.Peek();
        }
    }
}
