using System.Linq;

public class ScrambleString {
    public bool IsScramble(string s1, string s2) {
        var count = new int[26];
        foreach (var x in s1) ++count[x - 'a'];
        
        foreach (var x in s2) --count[x - 'a'];
        
        if (!count.All(x => x == 0)) return false;

        if (s1.Length <= 1) return true;

        for (var i = 1; i < s1.Length; ++i)
        {
            if (IsScramble(s1.Substring(0, i), s2.Substring(0, i))
                && IsScramble(s1.Substring(i), s2.Substring(i))
                || IsScramble(s1.Substring(0, i), s2.Substring(s2.Length - i))
                && IsScramble(s1.Substring(i), s2.Substring(0, s2.Length - i)))
                    return true;
        }

        return false;
    }
}