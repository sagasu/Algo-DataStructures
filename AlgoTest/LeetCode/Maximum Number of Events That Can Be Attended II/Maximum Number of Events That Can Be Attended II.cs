using System;

public class MaximumNumberofEventsThatCanBeAttendedII {
    public int MaxValue(int[][] events, int k) {
        var dp = new int[events.Length][];

        for(int i=0; i<events.Length; i++){
            dp[i] = new int[k+1];
            Array.Fill(dp[i], -1);
        }

        Array.Sort(events, (a, b) => {
            if(a[0] != b[0])
                return a[0] - b[0];
            
            return a[1] - b[1];
        });

        return DFS(events, dp, 0, k, 0);
    }

    private int DFS(int[][] events, int[][] dp, int idx, int k, int eventEndDay){
        while(idx < events.Length && events[idx][0] <= eventEndDay)
           idx++;
        
        if(idx >= events.Length || k == 0) return 0;
        
        if(dp[idx][k] != -1) return dp[idx][k];
        
        dp[idx][k] = Math.Max(dp[idx][k], DFS(events, dp, idx+1, k, eventEndDay));

        if(events[idx][0] > eventEndDay) 
            dp[idx][k] = Math.Max(dp[idx][k], events[idx][2] + DFS(events, dp, idx+1, k-1, events[idx][1]));
        
        return dp[idx][k];
    }
}