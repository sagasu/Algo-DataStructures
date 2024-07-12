using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Maximum_Score_From_Removing_Substrings;

public class Maximum_Score_From_Removing_Substrings
{
    public int MaximumGain(string s, int x, int y) {
        var str = x >= y ? "ab" : "ba";
        var max_gain = Math.Max(x, y);
        var min_gain = Math.Min(x, y);
        return CalculateMaxGain(s, str, max_gain, min_gain);
    }

    private static int CalculateMaxGain(string s, string str, int firstGain, int secondGain) {
        var ans = 0;
        var stack = new Stack<char>();
        var auxStack = new Stack<char>();

        foreach (var chr in s) {
            if (stack.Count > 0 && stack.Peek() == str[0] && chr == str[1]) {
                ans += firstGain;
                stack.Pop();
            }
            else
                stack.Push(chr);
        }

        while (stack.Count > 0) {
            if (auxStack.Count > 0 && auxStack.Peek() == str[0] && stack.Peek() == str[1]) {
                stack.Pop();
                auxStack.Pop();
                ans += secondGain;
            }
            else
                auxStack.Push(stack.Pop());
        }

        return ans;
    }
}