public class ReducingDishes {
    public int MaxSatisfaction(int[] satisfaction) {
        Array.Sort(satisfaction);
        var  n = satisfaction.Length;
        var dp = new int[n+1];
        var prevDep0 = 0;

        for (var i = n - 1; i >= 0; i--) {
            var thisSatisfaction = 0;
            for (var times = 0; times <= i;  times++) {
                thisSatisfaction += satisfaction[i];
                dp[times] = Math.Max(thisSatisfaction + dp[times + 1], dp[times]);
            }      
            if (dp[0] == prevDep0) break;
            
            prevDep0 = dp[0];
        }

        return dp[0];
    }
}