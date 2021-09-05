using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Orderly_Queue
{
    class Orderly_Queue
    {
        public virtual string OrderlyQueue(string s, int k)
        {
            if (k > 1) {
                var temp = s.ToCharArray();
                Array.Sort(temp);
                s = new string(temp);
            } else {
                var sTwice = s + s;
                for (var i = 1; i < s.Length; i++) {
                    var tmp = sTwice.Substring(i, s.Length);
                    s = (s.CompareTo(tmp) > 0) ? tmp : s;
                }
            }
            return s;
        }
	}
}
