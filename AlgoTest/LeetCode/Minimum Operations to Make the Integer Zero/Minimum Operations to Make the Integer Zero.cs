namespace AlgoTest.LeetCode.Minimum_Operations_to_Make_the_Integer_Zero;

public class Minimum_Operations_to_Make_the_Integer_Zero
{
    public int MakeTheIntegerZero(int num1, int num2) {
        if (num1 == 0) return 0;
        for (int t = 0; t <= 60; t++) {
            long s = (long)num1 - (long)t * num2;
            if (s < 0) continue;
            if (s < t) continue;
            int ones = CountBits(s);
            if (ones <= t) return t;
        }
        return -1;
    }

    private int CountBits(long x) {
        int cnt = 0;
        while (x > 0) {
            cnt += (int)(x & 1L);
            x >>= 1;
        }
        return cnt;
    }
}