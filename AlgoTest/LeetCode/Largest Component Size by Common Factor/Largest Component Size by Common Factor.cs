using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.Largest_Component_Size_by_Common_Factor
{
    class Largest_Component_Size_by_Common_Factor
    {
        private Dictionary<int, int> dict = new Dictionary<int, int>();
        private Dictionary<int, int> count = new Dictionary<int, int>();
        private Dictionary<int, List<int>> group = new Dictionary<int, List<int>>();
        public int LargestComponentSize(int[] a)
        {
            var primes = new HashSet<int>();
            var isPrime = Enumerable.Repeat(true, 100001).ToArray();
            for (int i = 2; i <= 100000; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                    for (int j = 2; j * i <= 100000; j++) isPrime[j * i] = false;
                }
            }

            foreach (var num in a)
            {
                int n = num;
                foreach (var prime in primes)
                {
                    if (prime > n) break;
                    else if (primes.Contains(n))
                    {
                        if (!group.ContainsKey(n)) group[n] = new List<int>();
                        group[n].Add(num);
                        break;
                    }
                    else if (n % prime == 0)
                    {
                        if (!group.ContainsKey(prime)) group[prime] = new List<int>();
                        group[prime].Add(num);
                        n = n / prime;
                    }
                }
            }

            foreach(var z in group.Keys)
            {
                var l = group[z];

                for (int i = 0; i < l.Count - 1; i++)
                {
                    int j = i + 1;
                    int p1 = GetParent(l[i]), p2 = GetParent(l[j]);
                    if (p1 != p2)
                    {
                        dict[p1] = p2;
                        count[p2] = count[p1] + count[p2];
                    }
                }
            }

            return count.Values.Max();
        }

        private int GetParent(int n)
        {
            if (!dict.ContainsKey(n))
            {
                dict[n] = n;
                count[n] = 1;
            }
            if (dict[n] != n) dict[n] = GetParent(dict[n]);
            return dict[n];
        }
    }
}
