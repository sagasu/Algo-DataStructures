public class Solution {
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit) {
        var jobs = new Job[startTime.Length];
        for(int i = 0; i < startTime.Length; i++)
        {
            jobs[i] = new Job(startTime[i], endTime[i], profit[i]);            
        }
        Array.Sort(jobs, (a,b) => a.End.CompareTo(b.End));

        int[] dp = new int[jobs.Length + 1];
        for(int i = 0; i < jobs.Length; i++)
        {
            int pre = BinarySearch(jobs, -1, i-1, jobs[i].Start);
            dp[i+1] = dp[pre+1] + jobs[i].Profit;
            dp[i+1] = Math.Max(dp[i+1], dp[i]);
        }

        return dp[jobs.Length];
    }
    
    public int BinarySearch(Job[] jobs, int low, int high, int target) 
    {
        while (low < high) 
        {
            int mid = high - (high - low) / 2;
            if(jobs[mid].End > target)
                high = mid - 1;
            else
                low = mid;
        }
        return low;
    }
}

public class Job
{
    public int Start;
    public int End;
    public int Profit;
    public Job(int start, int end, int profit)
    {
        Start = start;
        End = end;
        Profit = profit;
    }
}