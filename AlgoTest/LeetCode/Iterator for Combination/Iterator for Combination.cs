using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.Iterator_for_Combination
{
    class CombinationIterator
    {
        IList<string> comb = new List<string>();
        int prevIndex = -1;

        public CombinationIterator(string characters, int combinationLength)
        {
            Backtrack(characters, combinationLength, 0, new List<char>(), comb);
        }

        private void Backtrack(string chars, int len, int st, IList<char> li, IList<string> comb)
        {
            if (li.Count == len)
            {
                var str = new string(li.ToArray());
                comb.Add(str);
                return;
            }

            for (var i = st; i < chars.Length; i++)
            {
                if (li.Count + 1 > len) continue;
                
                li.Add(chars[i]);
                Backtrack(chars, len, i + 1, li, comb);
                li.RemoveAt(li.Count - 1);
            }
        }

        public string Next()
        {
            return comb[++prevIndex];
        }

        public bool HasNext()
        {
            return prevIndex != comb.Count - 1;
        }
    }
}
