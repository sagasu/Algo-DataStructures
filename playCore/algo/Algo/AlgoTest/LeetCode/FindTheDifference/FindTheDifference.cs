using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.FindTheDifference
{
    public class FindTheDifferenceSolution
    {
        public char FindTheDifference(string s, string t)
        {
            var dic = new Dictionary<char, int>();
            foreach (var character in s)
            {
                if (!dic.TryAdd(character, 1))
                    dic[character] += 1;
            }

            foreach (var character in t)
            {
                if (dic.ContainsKey(character))
                {
                    dic[character] -= 1;
                    if (dic[character] <= 0)
                        dic.Remove(character);
                }
                else
                {
                    return character;
                }
            }

            throw new ArgumentException("wrong arguments");
        }
    }
}
