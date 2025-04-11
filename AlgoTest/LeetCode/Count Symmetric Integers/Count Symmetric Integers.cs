namespace AlgoTest.LeetCode.Count_Symmetric_Integers;

public class Count_Symmetric_Integers
{
    public int CountSymmetricIntegers(int low, int high) {
        int cnt = 0;
        for (int i = low; i <= high; i++) {
            string s = i.ToString();
            if (s.Length % 2 == 0) {
                int mid = s.Length / 2;
                int sum1 = 0, sum2 = 0;
                for (int j = 0; j < mid; j++) sum1 += s[j] - '0';
                for (int j = mid; j < s.Length; j++) sum2 += s[j] - '0';
                if (sum1 == sum2) cnt++;
            }
        }
        return cnt;
    }
}