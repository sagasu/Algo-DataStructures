namespace AlgoTest.LeetCode.Minimum_Number_of_Flips_to_Make_the_Binary_String_Alternating;

public class Minimum_Number_of_Flips_to_Make_the_Binary_String_Alternating
{
    public int MinFlips(string s) {
        int n = s.Length;
        int diff = 0;
        
        for (int i = 0; i < n; i++) {
            if (s[i] - '0' != (i & 1)) diff++;
        }
        
        int res = diff < n - diff ? diff : n - diff;
        if (res == 0 || (n & 1) == 0) return res;
        
        for (int i = 0; i < n; i++) {
            if (s[i] - '0' != (i & 1)) diff--;
            else diff++;
            
            int cur = diff < n - diff ? diff : n - diff;
            if (cur < res) {
                res = cur;
                if (res == 0) return 0;
            }
        }
        
        return res;
    }
}