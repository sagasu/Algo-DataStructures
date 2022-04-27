using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Smallest_String_With_Swaps
{
    internal class Smallest_String_With_Swaps
    {
        int N;

        int[] parents;
        int[] ranks;
        
        public int Find(int root)
        {
            if (root == parents[root])
            {
                return root;
            }
            else
            {
                var found = Find(parents[root]);
                parents[root] = found;
                return found;
            }
        }

        public void Union(int i, int j)
        {
            var pi = Find(i);
            var pj = Find(j);
            var ranki = ranks[pi];
            var rankj = ranks[pj];
            if (ranki < rankj)
            {
                parents[pi] = pj;
            }
            else if (ranki > rankj)
            {
                parents[pj] = pi;
            }
            else
            {
                parents[pi] = pj;
                ranks[pj]++;
            }
        }

        public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
        {
            N = s.Length;
            parents = new int[N];
            ranks = new int[N];

            for (int i = 0; i < N; i++)
            {
                parents[i] = i;
            }

            foreach (var pair in pairs)
            {
                Union(pair[0], pair[1]);
            }

            var unions = new Dictionary<int, (List<char>, List<int>)>();

            for (int i = 0; i < N; i++)
            {
                var union = Find(i);
                if (!unions.ContainsKey(union)) unions[union] = (new List<char>(), new List<int>());
                unions[union].Item1.Add(s[i]);
                unions[union].Item2.Add(i);
            }

            foreach (var union in unions)
            {
                union.Value.Item1.Sort();
            }

            var S = new StringBuilder(s);

            foreach (var union in unions)
            {
                for (int j = 0; j < union.Value.Item1.Count; j++)
                {
                    S[union.Value.Item2[j]] = union.Value.Item1[j];
                }
            }

            return S.ToString();
        }
    }
}
