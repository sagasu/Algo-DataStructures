namespace AlgoTest.LeetCode.Smallest_Integer_Divisible_by_K;

public class Smallest_Integer_Divisible_by_K
{
    public int SmallestRepunitDivByK(int k)
    {
        if((k&1) == 0 || k%5 == 0)
            return -1;

        int len = 1;
        int rem = 1%k;

        while(rem != 0)
        {
            rem = rem*10 + 1;
            rem = rem%k;
            len++;
        }

        return len;
    }
}