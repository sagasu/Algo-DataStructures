namespace AlgoTest.LeetCode.Shortest_Common_Supersequence;

public class Shortest_Common_Supersequence
{
    public string ShortestCommonSupersequence(string str1, string str2) {
        int l1 = str1.Length, l2 = str2.Length;
        string[] prv = new string[l2+1], cur = null;
        for(int c=0;c<l2;c++)  
            prv[c] = str2.Substring(c);
        
        for(int r=l1-1;r>=0;r--)
        {
            cur = new string[l2+1];
            cur[l2] = str1.Substring(r);

            for(int c=l2-1;c>=0;c--)
                if(str1[r]==str2[c])
                    cur[c] = str1[r] + prv[c+1];
                else
                {
                    if (cur[c + 1].Length < prv[c].Length)
                        cur[c] = str2[c] + cur[c + 1];
                    else
                        cur[c] = str1[r] + prv[c];
                }
            prv = cur;
        }
        return cur[0];
    }
}