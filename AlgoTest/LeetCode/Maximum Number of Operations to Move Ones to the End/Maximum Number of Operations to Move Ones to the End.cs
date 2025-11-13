namespace AlgoTest.LeetCode.Maximum_Number_of_Operations_to_Move_Ones_to_the_End;

public class Maximum_Number_of_Operations_to_Move_Ones_to_the_End
{
    public int MaxOperations(string s) {
        var count = 0;
        var current = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '1')
            {
                current++;
            }
            else if (s[i] == '0')
            {
                while (i < s.Length && s[i] == '0')
                {
                    i++;
                }

                i--;
                count += current;
            }
        }

        return count;
    }
}