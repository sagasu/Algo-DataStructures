using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Special_Binary_String;

public class Special_Binary_String
{
    public string MakeLargestSpecial(string s) {
        var count = 0;
        var i = 0;
        var list = new List<string>();
        var result = string.Empty;
        for(var j = 0; j < s.Length; j++)
        {
            count += (s[j] == '1') ? 1 : -1;
            if (count == 0)
            {
                list.Add('1' + MakeLargestSpecial(s.Substring(i + 1, j - i - 1))+'0');
                i = j + 1;
            }
        }
        
        list.Sort((x, y) => -x.CompareTo(y));
        
        return list.Aggregate(result, (current, item) => current + item);
    }   
}