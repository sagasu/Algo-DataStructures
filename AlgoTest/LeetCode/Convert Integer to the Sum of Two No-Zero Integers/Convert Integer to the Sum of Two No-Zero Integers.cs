namespace AlgoTest.LeetCode.Convert_Integer_to_the_Sum_of_Two_No_Zero_Integers;

public class Convert_Integer_to_the_Sum_of_Two_No_Zero_Integers
{
    public int[] GetNoZeroIntegers(int n) {
        bool Check(int x) {
            return !x.ToString().Contains('0');
        }
        for (int i = 1; i < n; i++) {
            int j = n - i;
            if (Check(i) && Check(j)) {
                return new int[] { i, j };
            }
        }
        return new int[0];
    }
}