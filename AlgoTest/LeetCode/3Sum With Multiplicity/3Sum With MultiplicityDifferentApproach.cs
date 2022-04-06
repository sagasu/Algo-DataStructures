using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode._3Sum_With_Multiplicity
{
    internal class _3Sum_With_MultiplicityDifferentApproach
    {
        public int ThreeSumMulti(int[] arr, int target)
        {
            long mod = 1000000007;
            Dictionary<int, int> frequency = new();
            foreach (var n in arr)
            {
                if (frequency.ContainsKey(n))
                    frequency[n]++;
                else
                    frequency[n] = 1;
            }

            long ans = 0;
            foreach (var x in frequency.Keys)
            {
                foreach (var y in frequency.Keys)
                {
                    var z = target - x - y;
                    if (frequency.ContainsKey(z))
                    {
                        long xfreq = frequency[x];
                        long yfreq = frequency[y];
                        long zfreq = frequency[z];


                        if (x == y && x == z)
                            ans += xfreq * (xfreq - 1) * (xfreq - 2) / 6;
                        else if (x == y && x != z)
                            ans += (xfreq * (xfreq - 1) / 2) * zfreq;
                        else if (x < y && y < z)
                            ans += xfreq * yfreq * zfreq;
                    }
                }
                ans %= mod;
            }

            return (int)ans;
        }
    }
}
