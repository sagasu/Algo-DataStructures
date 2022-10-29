public class Solution {
    public int EarliestFullBloom(int[] plantTime, int[] growTime) {
        int n = growTime.Length;
        int[][] days = new int[n][];
        
        for(int i = 0; i < n; i++)
        {
            days[i] = new int[2] { plantTime[i], growTime[i] };
        }
        
        days = days.OrderByDescending(x => x[1]).ToArray();
        
        int max = 0, plantSum = 0;
        
        for(int i = 0; i < n; i++)
        {
            int plant = days[i][0], grow = days[i][1];
            plantSum += plant;
            max = Math.Max(max, plantSum + grow);
        }
        
        return max;
    }
}