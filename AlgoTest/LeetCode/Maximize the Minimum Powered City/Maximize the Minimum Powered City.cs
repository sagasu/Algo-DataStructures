using System;
using System.Linq;

namespace AlgoTest.LeetCode.Maximize_the_Minimum_Powered_City;

public class Maximize_the_Minimum_Powered_City
{
    public long MaxPower(int[] stations, int r, int k) {
        int n = stations.Length;
        long[] cnt = new long[n + 1];

        for (int i = 0; i < n; i++) {
            int left = Math.Max(0, i - r);
            int right = Math.Min(n, i + r + 1);
            cnt[left] += stations[i];
            cnt[right] -= stations[i];
        }

        long lo = stations.Min();
        long hi = stations.Sum(x => (long)x) + k;
        long res = 0;

        while (lo <= hi) {
            long mid = lo + (hi - lo) / 2;
            if (Check(cnt, mid, r, k)) {
                res = mid;
                lo = mid + 1;
            } else {
                hi = mid - 1;
            }
        }
        return res;
    }

    private bool Check(long[] cnt, long val, int r, int k) {
        int n = cnt.Length - 1;
        long[] diff = (long[])cnt.Clone();
        long sum = 0;
        long remaining = k;

        for (int i = 0; i < n; i++) {
            sum += diff[i];
            if (sum < val) {
                long add = val - sum;
                if (remaining < add) {
                    return false;
                }
                remaining -= add;
                int end = Math.Min(n, i + 2 * r + 1);
                diff[end] -= add;
                sum += add;
            }
        }
        return true;
    }
}