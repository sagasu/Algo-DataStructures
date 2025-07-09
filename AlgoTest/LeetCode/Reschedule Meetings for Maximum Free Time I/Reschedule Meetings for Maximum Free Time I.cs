using System;

namespace AlgoTest.LeetCode.Reschedule_Meetings_for_Maximum_Free_Time_I;

public class Reschedule_Meetings_for_Maximum_Free_Time_I
{
    public int MaxFreeTime(int eventTime, int k, int[] startTime, int[] endTime) {
        int n = startTime.Length, res = 0;
        int[] sum = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            sum[i + 1] = sum[i] + endTime[i] - startTime[i];
        }
        for (int i = k - 1; i < n; i++)
        {
            int right = i == n - 1 ? eventTime : startTime[i + 1];
            int left = i == k - 1 ? 0 : endTime[i - k];
            res = Math.Max(res, right - left - (sum[i + 1] - sum[i - k + 1]));
        }
        return res;
    }
}