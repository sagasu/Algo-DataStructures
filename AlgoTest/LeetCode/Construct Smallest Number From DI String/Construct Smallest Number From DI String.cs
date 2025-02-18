using System.Collections.Generic;

namespace AlgoTest.LeetCode.Construct_Smallest_Number_From_DI_String;

public class Construct_Smallest_Number_From_DI_String
{
    public string SmallestNumber(string pattern)
    {
        var list = new List<char>(pattern.Length);
        var stack = new Stack<char>();

        for (var i = 0; i <= pattern.Length; i++)
        {
            stack.Push((char) ('1' + i));
            if (i == pattern.Length || pattern[i] == 'I')
            {
                list.AddRange(stack);
                stack.Clear();
            }
        }

        return new string(list.ToArray());
    }
}