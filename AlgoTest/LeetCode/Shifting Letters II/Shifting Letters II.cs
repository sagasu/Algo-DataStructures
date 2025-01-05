using System.Text;

namespace AlgoTest.LeetCode.Shifting_Letters_II;

public class Shifting_Letters_II
{
    public string ShiftingLetters(string s, int[][] shifts)
    {
        var prefix = new int[s.Length + 1];
        foreach (var shift in shifts)
        {
            prefix[shift[0]] = (prefix[shift[0]] + (shift[2] == 1 ? 1 : 25)) % 26;
            prefix[shift[1] + 1] = (prefix[shift[1] + 1] + (shift[2] == 1 ? 25 : 1)) % 26;
        }

        for (var i = 1; i < prefix.Length; i++)
            prefix[i] = (prefix[i - 1] + prefix[i]) % 26;

        var sb = new StringBuilder();
        for (var i = 0; i < s.Length; i++)
        {                    
            var currentSymbol = (char)((s[i] - 'a' + prefix[i]) % 26 + 'a');
            sb.Append(currentSymbol);
        }

        return sb.ToString();
    }
}