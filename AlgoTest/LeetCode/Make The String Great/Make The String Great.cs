using System;

public class Solution10 {
    public string MakeGood(string s) {
        
        var i = 0;

        while (i < s.Length - 1)
        {
            if (Math.Abs(s[i] - s[i + 1]) == 32)
            {
                s = s.Remove(i, 2);
                i = 0;
            }
            else i++;
        }


        return s;
        
    }
}