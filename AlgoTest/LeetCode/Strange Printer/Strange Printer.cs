using System;

public class StrangePrinters {
    public int StrangePrinter(string s) 
    {
        if(s.Length < 2) return s.Length;
        var dp = new int [s.Length, s.Length];
        
        return this.Print(dp, 0, s.Length - 1, s);        
    }
    
    private int Print(int[,] dp, int lo, int hi, string s)
    {
        if(lo > hi) return 0;
        
        if(dp[lo, hi] == 0)
        {
            dp[lo, hi] = this.Print(dp, lo, hi - 1, s) + 1;
            
            for(int i = lo; i < hi; i++)
                if(s[hi] == s[i])
                    dp[lo, hi] = Math.Min(dp[lo, hi], this.Print(dp, lo, i - 1, s) + this.Print(dp, i, hi - 1, s));
        }
        
        return dp[lo, hi];
    }
}