using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Fair_Distribution_of_Cookies
{
    internal class Fair_Distribution_of_Cookies
    {
        int min;
        public int DistributeCookies(int[] cookies, int k)
        {
            min = int.MaxValue;
            DistributeCookiesUntil(cookies, k, new int[k], 0, 0);
            return min;
        }

        private void DistributeCookiesUntil(int[] cookies, int k, int[] bag, int idx, int max_cookies)
        {
            if (idx >= cookies.Length)
            {
                min = Math.Min(min, max_cookies);
                return;
            }

            for (var i = 0; i < k; i++)
            {
                bag[i] += cookies[idx];
                var max_cookies_so_far = Math.Max(max_cookies, bag[i]);
                DistributeCookiesUntil(cookies, k, bag, idx + 1, max_cookies_so_far);
                bag[i] -= cookies[idx];
            }
        }
    }
}
