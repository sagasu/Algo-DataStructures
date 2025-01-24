public class BuddyString {
    public bool BuddyStrings(string s, string t) =>
    s == t && s.ToHashSet().Count < s.Length ||
    s.Length == t.Length &&
    new Func<int[], bool>(diffs =>
        diffs.Length == 2 &&
        s[diffs[0]] == t[diffs[1]] &&
        s[diffs[1]] == t[diffs[0]]
    )(
        Enumerable
            .Range(0, s.Length)
            .Where(i => s[i] != t[i])
            .ToArray()
    );
}