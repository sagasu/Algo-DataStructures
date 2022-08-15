using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Roman_to_Integer
{
    internal class Roman_to_Integer
    {
        public int RomanToInt(string s)
        {
            var romanKeys = new Dictionary<string, int> {
                { "M", 1000 },
                { "CM", 900 },
                { "D",  500 },
                { "CD", 400 },
                { "C",  100 },
                { "XC",  90 },
                { "L",   50 },
                { "XL",  40 },
                { "X",   10 },
                { "IX",   9 },
                { "V",    5 },
                { "IV",   4 },
                { "I",    1 }
            };

            var output = 0;

            var i = 0;
            foreach (var roman in romanKeys)
            {
                if (roman.Key.Length == 2)
                {
                    while (i < s.Length - 1 && (s[i].ToString() + s[i + 1].ToString()) == roman.Key)
                    {
                        output += roman.Value;
                        i += 2;
                    }
                }
                else
                {
                    while (i < s.Length && s[i].ToString() == roman.Key)
                    {
                        output += roman.Value;
                        i++;
                    }
                }
            }

            return output;
        }
	}
}
