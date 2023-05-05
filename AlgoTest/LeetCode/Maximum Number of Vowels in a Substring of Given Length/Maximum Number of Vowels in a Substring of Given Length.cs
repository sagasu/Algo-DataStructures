using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Maximum_Number_of_Vowels_in_a_Substring_of_Given_Length
{
    internal class Maximum_Number_of_Vowels_in_a_Substring_of_Given_Length
    {
        public int MaxVowels(string s, int k)
        {
            var maxVowels = 0;
            var currentVowels = 0;
            var vowels = "aeiou";

            for (var i = 0; i < k; i++)
                if (vowels.Contains(s[i])) currentVowels++;
            
            maxVowels = currentVowels;

            for (var i = k; i < s.Length; i++)
            {
                if (vowels.Contains(s[i - k])) currentVowels--;
                
                if (vowels.Contains(s[i])) currentVowels++;
                
                if (currentVowels > maxVowels) maxVowels = currentVowels;
            }

            return maxVowels;
        }
    }
}
