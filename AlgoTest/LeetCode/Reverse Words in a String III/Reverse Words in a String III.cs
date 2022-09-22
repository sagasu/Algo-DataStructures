using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Reverse_Words_in_a_String_III
{
    internal class Reverse_Words_in_a_String_III
    {
        public string ReverseWords(string s)
        {
            var array = s.Split(' ');

            for (var i = 0; i < array.Length; i++)
            {
                var word = array[i].ToArray();
                var sb = new StringBuilder();
                for (var j = word.Length - 1; j >= 0; j--)
                {
                    sb.Append(word[j]);
                }
                array[i] = sb.ToString();
            }

            return string.Join(" ", array);
        }
    }
}
