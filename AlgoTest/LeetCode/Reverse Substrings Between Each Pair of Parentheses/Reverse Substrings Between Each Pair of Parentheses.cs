using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Reverse_Substrings_Between_Each_Pair_of_Parentheses;

public class Reverse_Substrings_Between_Each_Pair_of_Parentheses
{
    public string ReverseParentheses(string s) {
        var result = "";
        var stack = new Stack<int>();
        
        foreach (var current in s)
        {
            if (current != '(' && current != ')')
                result += current;
            else switch (current)
            {
                case '(':
                    stack.Push(result.Length);
                    break;
                case ')':
                {
                    var start = stack.Pop();
                    var length = ((result.Length) - 1) - start + 1;
                    var reversed = new string(result.Substring(start, length).Reverse().ToArray());
                    result = result.Remove(start, length);
                    result += reversed;
                    break;
                }
            }
        }
        
        return result;
    }
}