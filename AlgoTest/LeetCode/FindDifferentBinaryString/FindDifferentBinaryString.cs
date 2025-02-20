using System.Linq;

namespace AlgoTest.LeetCode.FindDifferentBinaryString;

public class FindDifferentBinaryStringSolution
{
    public string FindDifferentBinaryString(string[] nums) =>
        string.Concat(nums.Select((n, i) => n[i] == '0' ? '1' : '0'));
}