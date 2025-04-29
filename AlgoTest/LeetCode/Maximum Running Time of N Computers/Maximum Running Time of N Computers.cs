using System;
using System.Linq;

public class MaximumRunningTimeofNComputers {
    bool CheckTime(long time, int n, int[] batteries) {
        long sum = 0;
        foreach (var b in batteries) {
            sum += Math.Min(time, b);
        }

        return (sum / n >= time);
    }

    public long MaxRunTime(int n, int[] batteries) {
        long l = 0;
        long r = batteries.Sum(x => (long)x) + 1;

        while (r - l > 1) {
            long t = l + (r - l) / 2;

            if (CheckTime(t, n, batteries)) {
                l = t;
            } else {
                r = t;
            }
        }

        return l;
    }
}