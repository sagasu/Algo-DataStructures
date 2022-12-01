using System;

public class Solution18 {
    public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H) 
    {
        var overlap = 0;
        if( Math.Min(C,G) > Math.Max(A,E)  && Math.Min(D,H) > Math.Max(B,F) )
            overlap = (Math.Min(C,G)-Math.Max(A,E))*(Math.Min(D,H)-Math.Max(B,F));
        
        return (C-A)*(D-B)+(G-E)*(H-F)-overlap;
    }
}