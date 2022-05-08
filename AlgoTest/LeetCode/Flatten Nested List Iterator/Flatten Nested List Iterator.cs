using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Flatten_Nested_List_Iterator
{
    public class NestedIterator
    {
        private Stack<NestedInteger> stack = new Stack<NestedInteger>();
        private void pushList(IList<NestedInteger> list)
        {
            for (int i = list.Count - 1; i >= 0; --i)
            {
                if (list[i].IsInteger() || list[i].GetList().Count > 0)
                {
                    stack.Push(list[i]);
                }
            }
        }

        private void skipToNextInteger()
        {
            while (stack.Count > 0 && !stack.Peek().IsInteger())
            {
                var t = stack.Pop();
                pushList(t.GetList());
            }
        }

        public NestedIterator(IList<NestedInteger> nestedList)
        {
            pushList(nestedList);
            skipToNextInteger();
        }

        public bool HasNext()
        {
            return stack.Count > 0;
        }

        public int Next()
        {
            var v = stack.Pop();
            skipToNextInteger();
            return v.GetInteger();
        }
    }

    public interface NestedInteger
    {

           bool IsInteger(); 
           int GetInteger();
           IList<NestedInteger> GetList();
    }
}
