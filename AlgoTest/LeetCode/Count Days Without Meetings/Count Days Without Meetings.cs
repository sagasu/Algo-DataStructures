using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Count_Days_Without_Meetings;

public class Count_Days_Without_Meetings
{
    public int CountDays(int days, int[][] meetings) {
        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));

        var mergedMeetings = new List<int[]>();
        foreach (var meeting in meetings) {
            if (mergedMeetings.Count == 0 || mergedMeetings[mergedMeetings.Count - 1][1] < meeting[0]) {
                mergedMeetings.Add(meeting);
            } else {
                mergedMeetings[mergedMeetings.Count - 1][1] = Math.Max(mergedMeetings[mergedMeetings.Count - 1][1], meeting[1]);
            }
        }

        long busyDays = 0;
        foreach (var meeting in mergedMeetings) {
            busyDays += (long)(meeting[1] - meeting[0] + 1);
        }
        return (int)(days - busyDays);
    }
}