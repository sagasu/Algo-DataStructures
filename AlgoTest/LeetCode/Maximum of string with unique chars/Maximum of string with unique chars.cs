using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Maximum_of_string_with_unique_chars
{
    internal class Maximum_of_string_with_unique_chars
    {
        public int MaxLength(IList<string> arr)
        {
            return MaxUnique(arr, 0, "");
        }

        private int MaxUnique(IList<string> arr, int index, string curr)
        {
            if (index == arr.Count)
            {
                return IsUnique(curr);
            }
            if (IsUnique(curr) == -1)
            {
                return -1;
            }
            int res = MaxUnique(arr, index + 1, curr);
            int res2 = MaxUnique(arr, index + 1, curr + arr[index]);
            return Math.Max(res, res2);

        }


        private int IsUnique(string str)
        {
            HashSet<char> set = new HashSet<char>();
            foreach (var c in str)
            {
                if (set.Contains(c))
                {
                    return -1;
                }
                set.Add(c);
            }
            return str.Length;
        }

    }
}
