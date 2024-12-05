namespace AlgoTest.LeetCode.Make_String_a_Subsequence_Using_Cyclic_Increments;

public class Make_String_a_Subsequence_Using_Cyclic_Increments
{
    public bool CanMakeSubsequence(string str1, string str2) {
        int i = 0, j = 0;

        while (i < str1.Length && j < str2.Length) {
            if (str1[i] == str2[j] || 
                (str1[i] - 'a' + 1) % 26 + 'a' == str2[j]) {
                j++;
            }
            i++;
        }

        return j == str2.Length;
    }
}