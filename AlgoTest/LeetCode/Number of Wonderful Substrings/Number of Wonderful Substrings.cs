namespace AlgoTest.LeetCode.Number_of_Wonderful_Substrings;

public class Number_of_Wonderful_Substrings
{
    public long WonderfulSubstrings(string word) {
        long result = 0;
        var count = new int[1024];
        count[0] = 1;
        var mask = 0;

        foreach (var c in word) {
            mask ^= 1 << (c - 'a');
            result += count[mask];
            for (var i = 0; i < 10; i++) 
                result += count[mask ^ (1 << i)];
            
            count[mask]++;
        }

        return result;
    }
}