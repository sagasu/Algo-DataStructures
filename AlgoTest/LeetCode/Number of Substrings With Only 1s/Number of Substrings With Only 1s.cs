namespace AlgoTest.LeetCode.Number_of_Substrings_With_Only_1s;

public class Number_of_Substrings_With_Only_1s
{
    public int NumSub(string s) {
        const int MODULO = 1000000007;
        long total = 0;
        long consecutive = 0;
        foreach (char c in s) {
            if (c == '0') {
                total += consecutive * (consecutive + 1) / 2;
                total %= MODULO;
                consecutive = 0;
            } else {
                consecutive++;
            }
        }
        total += consecutive * (consecutive + 1) / 2;
        total %= MODULO;
        return (int)total;
    }
}