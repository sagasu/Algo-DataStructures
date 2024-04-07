namespace AlgoTest.LeetCode.Valid_Parenthesis_String;

public class Valid_Parenthesis_String
{
    public bool CheckValidString(string s) {
        int left = 0, any = 0,needRight = 0;

        foreach (var c in s)
        {
            if (c == '(')
            {
                left++;
                needRight++;
            }
            else if (c == '*')
            {
                any++;
                if (needRight > 0)
                    needRight--;
            }
            else
            {
                if (left > 0)
                {
                    left--;
                    if (needRight > 0)
                        needRight--;
                }
                else if (any > 0) any--;
                else return false;
            }
        }

        return needRight == 0;
    }
}