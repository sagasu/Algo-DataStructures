using System.Collections.Generic;

namespace AlgoTest.LeetCode.Lexicographically_Smallest_String_After_Applying_Operations;

public class Lexicographically_Smallest_String_After_Applying_Operations
{
    public string FindLexSmallestString(string s, int a, int b) {
        var vis = new HashSet<string>();
        string smallest = s;
        var q = new Queue<string>();
        q.Enqueue(s);
        vis.Add(s);

        while (q.Count > 0) {
            string cur = q.Dequeue();
            if (string.Compare(cur, smallest) < 0) smallest = cur;

            char[] chars = cur.ToCharArray();
            for (int i = 1; i < chars.Length; i += 2)
                chars[i] = (char)(((chars[i] - '0' + a) % 10) + '0');
            string added = new string(chars);
            if (vis.Add(added)) q.Enqueue(added);

            string rotated = cur.Substring(cur.Length - b) + cur.Substring(0, cur.Length - b);
            if (vis.Add(rotated)) q.Enqueue(rotated);
        }
        return smallest;
    }
}