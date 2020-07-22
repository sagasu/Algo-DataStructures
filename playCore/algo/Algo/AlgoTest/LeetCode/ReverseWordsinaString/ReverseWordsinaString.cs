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
            foreach (var fullWord in words)
            {
                var word = fullWord.Trim();
                if(string.IsNullOrEmpty(word))
                    continue;
                if (isFirst)
                {
                    reversed += $"{word.Reverse()}";
                }
                else {
                    reversed += $" {word.Reverse()}";
                }

                isFirst = false;
            }

            return reversed;
        }
    }
}
