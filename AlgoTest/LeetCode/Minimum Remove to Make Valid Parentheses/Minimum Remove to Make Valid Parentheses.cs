using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Minimum_Remove_to_Make_Valid_Parentheses
{
    internal class Minimum_Remove_to_Make_Valid_Parentheses
    {
        public string MinRemoveToMakeValid(string s)
        {
            var stack = new Stack<(char c, int index)>();

            var n = s.Length;
            for (var i = 0; i < n; i++)
            {
                var c = s[i];
                if (stack.Count > 0 && stack.Peek().c == '(' && c == ')') stack.Pop();
                else if (c == '(' || c == ')') stack.Push((c, i));
            }

            var sb = new StringBuilder(s);
            foreach (var kv in stack) sb = sb.Remove(kv.index, 1);
            
            return sb.ToString();
        }
    }
}
