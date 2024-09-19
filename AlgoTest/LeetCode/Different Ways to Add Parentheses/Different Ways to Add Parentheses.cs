using System.Collections.Generic;

namespace AlgoTest.LeetCode.Different_Ways_to_Add_Parentheses;

public class Different_Ways_to_Add_Parentheses
{
    public IList<int> DiffWaysToCompute(string expression) {
        var result = new List<int>();

        var isNumber = true;
        for (int i = 0; i < expression.Length; i++) {
            var cur = expression[i];
            if (cur == '-' || cur == '+' || cur == '*') {
                isNumber = false;
                var leftList = DiffWaysToCompute(expression.Substring(0, i));
                var rightList = DiffWaysToCompute(expression.Substring(i + 1));

                foreach (var left in leftList) {
                    foreach (var right in rightList) {
                        if (cur == '-')
                            result.Add(left - right);
                        else if (cur == '+') 
                            result.Add(left + right);
                        else
                            result.Add(left * right);
                    }
                }
            }
        }

        if (isNumber) 
            result.Add(int.Parse(expression));
        
        return result;
    }
}