public class Solution {
    public int SumSubarrayMins(int[] A) {
            const int mode = 1000000007;
            int len = A.Length;
            int[] before = new int[len];
            int[] after = new int[len];
            long res = 0;
            for (int i = 0; i < len; i++) {
                int s = i - 1;
                while (s >= 0 && A[s] >= A[i]) s -= before[s];
                before[i] = i - s;
            }
            for (int i = len - 1; i >= 0; i--) {
                int s = i + 1;
                while (s < len && A[s] > A[i]) s += after[s];
                after[i] = s - i;
                res = (res + ((long)before[i]) * after[i] * A[i]) % mode;
            }
            return (int)res;
        }
}