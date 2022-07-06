using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Implement_strStr
{
    internal class Implement_strStr__
    {
        public int StrStr(string haystack, string needle)
        {
            if (needle.Length == 0)  return 0;
            
            var k = 0;
            var i = 0;
            var j = 0;

            while (true) {

                if (i >= haystack.Length) break;
                
                if (haystack[i] == needle[j]) {
                    k++;

                    if (k == needle.Length) return i - k + 1;

                    i++;
                    j++;

                    continue;
                }

                j = 0;
                i = i - k + 1;
                k = 0;
            }

            return -1;
        }
    }
}
