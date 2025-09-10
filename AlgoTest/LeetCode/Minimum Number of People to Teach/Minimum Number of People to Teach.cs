using System.Collections.Generic;

namespace AlgoTest.LeetCode.Minimum_Number_of_People_to_Teach;

public class Minimum_Number_of_People_to_Teach
{
    public int MinimumTeachings(int n, int[][] languages, int[][] friendships) {
        var bad = new HashSet<int>();
        
        foreach (var f in friendships) {
            int u = f[0] - 1;
            int v = f[1] - 1;

            var setU = new HashSet<int>(languages[u]);
            bool ok = false;
            foreach (int lang in languages[v]) {
                if (setU.Contains(lang)) {
                    ok = true;
                    break;
                }
            }

            if (!ok) {
                bad.Add(u);
                bad.Add(v);
            }
        }

        if (bad.Count == 0) return 0;

        int[] cnt = new int[n + 1];
        foreach (int u in bad) {
            foreach (int lang in languages[u]) {
                cnt[lang]++;
            }
        }

        int maxKnown = 0;
        foreach (int c in cnt) {
            if (c > maxKnown) maxKnown = c;
        }

        return bad.Count - maxKnown;
    }
}