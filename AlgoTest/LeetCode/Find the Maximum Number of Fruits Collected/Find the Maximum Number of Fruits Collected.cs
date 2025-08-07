namespace AlgoTest.LeetCode.Find_the_Maximum_Number_of_Fruits_Collected;

public class Find_the_Maximum_Number_of_Fruits_Collected
{
    public int MaxCollectedFruits(int[][] fruits)
    {
        var result = 0;
        var len = fruits.Length;
        for (int id = 0; id < len; id++)
            result += fruits[id][id];

        var dp = new int[len];
        for (int rowId = len - 2; rowId > 0; rowId--) 
        {
            var new_dp = new int[len];
            for (int colId = rowId + 1; colId < len; colId++)
            {
                new_dp[colId] = Math.Max(GetCellAmount(dp, colId - 1), GetCellAmount(dp, colId));
                new_dp[colId] = Math.Max(new_dp[colId], GetCellAmount(dp, colId + 1));
                new_dp[colId] += fruits[rowId][colId];
            }

            dp = new_dp;
        }
        result += Math.Max(dp[len - 2], dp[len - 1]) + fruits[0][len - 1];


        dp = new int[len];
        for (int colId = len - 2; colId > 0; colId--) 
        {
            var new_dp = new int[len];
            for (int rowId = colId + 1; rowId < len; rowId++)
            {
                new_dp[rowId] = Math.Max(GetCellAmount(dp, rowId - 1), GetCellAmount(dp, rowId));
                new_dp[rowId] = Math.Max(new_dp[rowId], GetCellAmount(dp, rowId + 1));
                new_dp[rowId] += fruits[rowId][colId];
            }

            dp = new_dp;
        }
        result += Math.Max(dp[len - 2], dp[len - 1]) + fruits[len - 1][0];


        return result;
    }

    private int GetCellAmount(int[] dp, int index) => (index >= dp.Length) ? 0 : dp[index];

}