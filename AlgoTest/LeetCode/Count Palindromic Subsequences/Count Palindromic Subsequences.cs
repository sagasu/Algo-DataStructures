namespace AlgoTest.LeetCode.Count_Palindromic_Subsequences;

public class Count_Palindromic_Subsequences
{
    private const int M = 1_000_000_000 + 7;

    public int CountPalindromes(string s)
    {
        int n = s.Length;
        long totalCount = 0;

        for (char c = '0'; c <= '9'; c++)
        {
            for (char d = '0'; d <= '9'; d++)
            {
                long[] startCount = new long[n];

                long cBeforeD = 0;

                long cCount = 0;

                for (int i = 0; i < n; i++)
                {
                    startCount[i] = cBeforeD;

                    char ch = s[i];
                    if (ch == d)
                    {
                        cBeforeD += cCount;
                    }
                    if (ch == c)
                    {
                        cCount++;
                    }
                }

                cBeforeD = 0;
                cCount = 0;

                for (int i = n - 1; i >= 3; i--)
                {
                    char ch = s[i];
                    if (ch == d)
                    {
                        cBeforeD += cCount;
                    }
                    if (ch == c)
                    {
                        cCount++;
                    }
                    
                    totalCount = (totalCount + cBeforeD * startCount[i - 1]) % M;
                }
            }
        }

        return (int)totalCount;
    }
}