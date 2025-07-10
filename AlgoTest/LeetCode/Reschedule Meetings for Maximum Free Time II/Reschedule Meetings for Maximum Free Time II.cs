using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Reschedule_Meetings_for_Maximum_Free_Time_II;

public class Reschedule_Meetings_for_Maximum_Free_Time_II
{
    public int MaxFreeTime(int eventTime, int[] startTime, int[] endTime) {
        var freeTime = new List<int>();
        int currEnd = 0,n=startTime.Length;
        for(int i=0;i<n;i++){
            freeTime.Add(startTime[i]-currEnd);
            currEnd=endTime[i];
        }
        freeTime.Add(eventTime-endTime[n-1]);
        int m=freeTime.Count;
        var leftMax = new int[m];
        var rightMax = new int[m];

        for(int i=1;i<m;i++){
            leftMax[i] = Math.Max(leftMax[i-1], freeTime[i-1]);
        }
        for(int i=m-2;i>=0;i--){
            rightMax[i] = Math.Max(rightMax[i+1], freeTime[i+1]);
        }
        int res=0;
        for(int i=1;i<m;i++){
            var duration = endTime[i-1] - startTime[i-1];
            if(duration <= Math.Max(leftMax[i-1],rightMax[i])){
                res = Math.Max(res,freeTime[i-1] + duration + freeTime[i]);
            }
            res = Math.Max(res,freeTime[i-1] + freeTime[i]);
        }
        return res;
    }
}