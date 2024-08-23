using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Fraction_Addition_and_Subtraction;

public class Fraction_Addition_and_Subtraction
{
    public string FractionAddition(string expression) {
        int up = 0, down = 1;
        var list = new List<int>();
        var firstAdd = false;
        var first = new StringBuilder();
        
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '/')
            {
                list.Add(int.Parse(first.ToString()));
                first.Clear();
            }
            else if (expression[i] == '+' || expression[i] == '-')
            {
                if (first.Length > 0) list.Add(int.Parse(first.ToString()));
                first.Clear(); first.Append(expression[i]);
            }
            else first.Append(expression[i]);
        }
        
        list.Add(int.Parse(first.ToString()));
        
        for (int i = 0; i < list.Count; i = i + 2)
        {
            int a = list[i], b = list[i + 1];
            up = a * down + up * b;
            down *= b;
            var g = GCD(up, down);
            up /= g;
            down /= g;
        }
        
        if (up * down < 0)
            return "-" + Math.Abs(up) + "/" + Math.Abs(down);
        
        return Math.Abs(up) + "/" + Math.Abs(down);
    }
    
    int GCD(int a, int b) => a % b == 0 ? b : GCD(b, a % b);
    
}