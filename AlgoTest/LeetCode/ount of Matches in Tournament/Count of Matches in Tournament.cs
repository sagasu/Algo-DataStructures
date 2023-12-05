namespace AlgoTest.LeetCode.ount_of_Matches_in_Tournament;

public class Count_of_Matches_in_Tournament
{
    public int NumberOfMatches(int n) {
        var ans = 0;
        while (n > 1) {
            if (n % 2 == 0) {
                ans += n / 2;
                n = n / 2;
            } else {
                ans += (n - 1) / 2;
                n = (n - 1) / 2 + 1;
            }
        }
        
        return ans;
    }
}