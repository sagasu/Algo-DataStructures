namespace AlgoTest.LeetCode.Minimum_Add_to_Make_Parentheses_Valid;

public class Minimum_Add_to_Make_Parentheses_Valid
{
    public int MinAddToMakeValid(string s) {
        if(string.IsNullOrEmpty(s))
            return 0;
        
        int open = 0, close = 0;
        foreach(var c in s)
        {
            if(c == '(')
                close++;
            else if(close > 0)
                close--;
            else
                open++; 
        }
        
        return open + close;
    }
}