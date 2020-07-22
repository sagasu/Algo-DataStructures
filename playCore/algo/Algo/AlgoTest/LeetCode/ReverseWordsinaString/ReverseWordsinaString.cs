using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.ReverseWordsinaString
{
    public class ReverseWordsinaString
    {
        public string ReverseWords(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;
            var reversed = "";
            var isFirst = true;
            var words = s.Split(" ");
            for(var i = words.Length - 1; i >= 0 ; i--)
            {
                var word = words[i].Trim();
                if(string.IsNullOrEmpty(word))
                    continue;

                if (isFirst)
                {
                    reversed += $"{word}";
                }
                else {
                    
                    reversed += $" {word}";
                }

                isFirst = false;
            }

            return reversed;
        }
    }
}
