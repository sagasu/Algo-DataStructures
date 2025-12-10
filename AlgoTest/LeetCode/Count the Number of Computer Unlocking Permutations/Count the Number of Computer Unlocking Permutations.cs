namespace AlgoTest.LeetCode.Count_the_Number_of_Computer_Unlocking_Permutations;

public class Count_the_Number_of_Computer_Unlocking_Permutations
{
    public int CountPermutations(int[] complexity) {
        int n = complexity.Length;
        for (int i = 1; i < n; i++) {
            if (complexity[i] <= complexity[0]) {
                return 0;
            }
        }

        int ans = 1;
        int mod = 1000000007;
        for (int i = 2; i < n; i++) {
            ans = (int)((long)ans * i % mod);
        }
        return ans;
    }
}