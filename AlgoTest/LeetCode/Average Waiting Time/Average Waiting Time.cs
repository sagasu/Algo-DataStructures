using System;
using System.Linq;

namespace AlgoTest.LeetCode.Average_Waiting_Time;

public class Average_Waiting_Time
{
    public double AverageWaitingTime(int[][] customers) => customers
        .Aggregate(
            (currTime: 0.0, totalWait: 0.0),
            (acc, next) => (
                acc.currTime = Math.Max(acc.currTime, next[0]) + next[1],
                acc.totalWait + acc.currTime - next[0]
            ),
            acc => acc.totalWait / customers.Length
        );
}