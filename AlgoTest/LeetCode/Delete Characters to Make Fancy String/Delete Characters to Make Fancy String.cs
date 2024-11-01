using System.Text;

namespace AlgoTest.LeetCode.Delete_Characters_to_Make_Fancy_String;

public class Delete_Characters_to_Make_Fancy_String
{
    public string MakeFancyString(string s)
    {
        StringBuilder stringBuilder = new();
        for (int index = 0; index < s.Length; index++)
            if (index < 2 || s[index - 1] != s[index] || s[index - 2] != s[index])
                stringBuilder.Append(s[index]);

        return stringBuilder.ToString();
    }
}