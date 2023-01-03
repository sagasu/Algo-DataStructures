public class Solution {
    public int MinDeletionSize(string[] strs) {
        return Enumerable
		.Range(0, strs[0].Length)
		.Select(i => new string(strs.Select(s => s[i]).ToArray()))
		.Count(col => new string(col.OrderBy(c => c).ToArray()) != col);
    }
}