using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.ValidParentheses
{
    public class ValidParentheses
    {
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            var dic = new Dictionary<char,char>
            {
                {'{', '}'},
                {'[', ']'},
                {'(', ')'}
            };

            foreach (var character in s)
            {
                if (dic.ContainsKey(character))
                    stack.Push(dic[character]);
                else if (dic.ContainsValue(character))
                    if (stack.Count == 0 || stack.Pop() != character)
                        return false;
                
            }

            return stack.Count == 0 ? true : false;
        }
    }
}
