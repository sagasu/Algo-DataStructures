public class Solution20 {
    public int SumSubarrayMins(int[] A) {
            const int mode = 1000000007;
            var len = A.Length;
            var before = new int[len];
            var after = new int[len];
            long res = 0;
            for (var i = 0; i < len; i++) {
                var s = i - 1;
                while (s >= 0 && A[s] >= A[i]) s -= before[s];
                before[i] = i - s;
            }
            for (var i = len - 1; i >= 0; i--) {
                var s = i + 1;
                while (s < len && A[s] > A[i]) s += after[s];
                after[i] = s - i;
                res = (res + ((long)before[i]) * after[i] * A[i]) % mode;
            }
            return (int)res;
        }
}