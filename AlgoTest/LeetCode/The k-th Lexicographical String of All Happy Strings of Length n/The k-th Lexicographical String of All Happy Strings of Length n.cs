using System.Text;

namespace AlgoTest.LeetCode.The_k_th_Lexicographical_String_of_All_Happy_Strings_of_Length_n;

public class The_k_th_Lexicographical_String_of_All_Happy_Strings_of_Length_n
{
    public string GetHappyString(int n, int k) {
        StringBuilder result = new();
        Backtracking();
        return result.ToString();
        
        bool Backtracking()
        {
            if(result.Length == n)
            {
                if (k == 1)
                    return true;
                k--;
                return false;
            }
            for(int i = 0; i < 3; i++)
            {
                char c = (char)(i+'a');
                if(result.Length == 0 || result[^1] != c)
                {
                    result.Append(c);
                    if(Backtracking() == true)
                        return true;
                    result.Length = result.Length-1;
                }
            }
            return false;
        }
    }
}