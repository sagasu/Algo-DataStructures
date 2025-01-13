namespace AlgoTest.LeetCode.Minimum_Length_of_String_After_Operations;

public class Minimum_Length_of_String_After_Operations
{
    public int MinimumLength(string s) {
        var charFrequency = new int[26];
        var totalLength = 0;

        foreach(char currentChar in s.ToCharArray()) 
            charFrequency[currentChar - 'a']++;

        foreach (int frequency in charFrequency) {
            if (frequency == 0) continue;
            if (frequency % 2 == 0) 
                totalLength += 2;
            else 
                totalLength += 1;
        }

        return totalLength;
    }
}