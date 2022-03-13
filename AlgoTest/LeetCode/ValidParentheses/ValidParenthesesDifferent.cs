using System.Collections.Generic;

namespace AlgoTest.LeetCode.ValidParentheses
{
    public class ValidParenthesesDifferent
    {
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            foreach (var c in s)
            {
                switch (stack.Count)
                {
                    case > 0 when c == ')' && stack.Peek() == '(':
                    case > 0 when c == '}' && stack.Peek() == '{':
                    case > 0 when c == ']' && stack.Peek() == '[':
                        stack.Pop();
                        break;
                    default:
                        stack.Push(c);
                        break;
                }
            }

            return stack.Count == 0;
        }
    }
}
