using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Basic_Calculator
{
    class Basic_Calculator
    {
        public int Calculate(string s)
        {
            var sign = 1;
            var res = 0;
            var stack = new Stack<int>();   
            for (var i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    var num = 0;
                    while (i < s.Length && char.IsDigit(s[i]))
                    {
                        num = num * 10 + s[i++] - '0';
                    }
                    i--;
                    res += num * sign;  
                }
                else if (s[i] == '+')
                    sign = 1;
                else if (s[i] == '-')
                    sign = -1;
                else if (s[i] == '(')
                {
                    stack.Push(res);
                    stack.Push(sign);
                    sign = 1;    
                    res = 0;
                }
                else if (s[i] == ')')
                    res = res * stack.Pop() + stack.Pop(); 
            }
            return res;
        }
    }
}
