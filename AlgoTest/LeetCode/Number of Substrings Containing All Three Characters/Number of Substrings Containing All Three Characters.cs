namespace AlgoTest.LeetCode.Number_of_Substrings_Containing_All_Three_Characters;

public class Number_of_Substrings_Containing_All_Three_Characters
{
    public int NumberOfSubstrings(string s) {
        int[] vis = new int[3];
        int l = 0 , r = 0 , ans = 0;
        while(r < s.Length)
        {
            vis[s[r]-'a']++;
            while(vis[0] > 0 && vis[1]> 0 && vis[2]> 0)
            {
                ans+= (s.Length - r);
                vis[s[l++]-'a']--;
            }
            r++;
        }
        return ans;
        
    }
}