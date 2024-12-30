namespace AlgoTest.LeetCode.Maximum_Sum_of_3_Non_Overlapping_Subarrays;

public class Maximum_Sum_of_3_Non_Overlapping_Subarrays
{
    public int[] MaxSumOfThreeSubarrays(int[] nums, int k) {
        var n=nums.Length;
        var sums = new int[n];

        for(var i=0; i<k; i++)
            sums[0] += nums[i];

        for(var i=k; i<n; i++)
            sums[i-k+1] = sums[i-k] - nums[i-k] + nums[i];

        var maxSum = 0;
        var res = new int[3];
        var dp = new int[n][];

        for(int i=0; i<n; i++){
            dp[i] = new int[3];

            for(int j=i+k; j<n; j++){
                var sum = sums[i] + sums[j];

                if (sum <= dp[i][0]) continue;
                dp[i][0] = sum; 
                dp[i][1] = i; 
                dp[i][2] = j;
            }
        }

        for(var i=0; i<n; i++){
            for(var j=i+k; j<n; j++){
                var sum = sums[i] + dp[j][0];

                if(sum > maxSum){
                    maxSum = sum;
                    res[0] = i;
                    res[1] = dp[j][1];
                    res[2] = dp[j][2];
                }
            }
        }

        return res;
    }
}