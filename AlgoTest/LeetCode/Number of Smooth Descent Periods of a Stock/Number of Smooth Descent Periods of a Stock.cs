namespace AlgoTest.LeetCode.Number_of_Smooth_Descent_Periods_of_a_Stock;

public class Number_of_Smooth_Descent_Periods_of_a_Stock
{
    public long GetDescentPeriods(int[] prices) {
        long len = 1;
        long totalLength = 1;
        for(int right = 1; right < prices.Length; right++) {
            if(prices[right] == prices[right - 1] - 1)
                len++;
            else
                len = 1;
            
            totalLength += len;
        }
        return totalLength;
    }
}