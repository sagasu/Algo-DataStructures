namespace AlgoTest.LeetCode.Student_Attendance_Record_II;

public class Student_Attendance_Record_II
{
    public int CheckRecord(int n) {
        if (n == 0) return 0;
        const int mod = 1000_000_007;

        var next = new int[4][];
        for (var i = 0; i < 4; i++)
            next[i] = new int[3];

        next[0][0] = 3;
        next[1][0] = 3;
        next[2][0] = 2;
        next[0][1] = 2;
        next[1][1] = 2;
        next[2][1] = 1;

        for (var i = n - 2; i >= 0; i--)
        {
            var curr = new int[4][];
            for (var j = 0; j < curr.Length; j++) curr[j] = new int[3];
            for (var aCount = 0; aCount < 2; aCount++)
            for (var lCount = 0; lCount < 3; lCount++)
                curr[lCount][aCount] = (next[0][aCount] + (next[lCount + 1][aCount] + next[0][aCount + 1]) % mod) % mod;
            
            next = curr;
        }

        return next[0][0];
    }
}