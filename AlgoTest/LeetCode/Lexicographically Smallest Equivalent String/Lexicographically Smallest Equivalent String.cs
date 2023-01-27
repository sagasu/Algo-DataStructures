using System;

public class SmallestEquivalentStringSolution
{
    
     //union find;
    //use sets to group the characters and look up the parents;
    
    int[] sets;
    int[] rank;
    
    public string SmallestEquivalentString(string A, string B, string S) {
        int n = A.Length;
        sets = new int[26];
        rank = new int[26];
        for(int i = 0; i < 26; i++)
            sets[i]=i;
        for(int i = 0; i < n; i++)
            union( A[i]-'a' , B[i]-'a');
        char[] ans = new char[S.Length];
        int j = 0;
        foreach(char s in S)
            ans[j++] =  Convert.ToChar((find(s-'a')+'a'));
        return new string(ans);
    }
    public int find(int x)
    {
        if (sets[x]==x)
            return x;
        else
            sets[x] = find(sets[x]);
        return sets[x]; 
    }
    public void union(int x, int y)
    {
        int px = find(x);
        int py = find(y);
        if (px!=py)
        {
            if (px < py)
                sets[py] = px;
            else
                sets[px] = py;
        }
    }
}