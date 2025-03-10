using System.Collections.Generic;

namespace AlgoTest.LeetCode.Count_of_Substrings_Containing_Every_Vowel_and_K_Consonants_II;

public class Count_of_Substrings_Containing_Every_Vowel_and_K_Consonants_II
{
    static string vowel = "aeiou";
    
    public long CountOfSubstrings(string word, int k) {
        int n = word.Length;
        return AtleastK(k) - AtleastK(k+1);
        
        long AtleastK(int minKReq)
        {
            Dictionary<char,int> vowelFreq = new();
            int lt = 0, rt = -1, nonVowel = 0;
            long result = 0;
            while(++rt<n)
            {
                if(vowel.Contains(word[rt]))
                {
                    if(vowelFreq.TryGetValue(word[rt], out int freq))
                        vowelFreq[word[rt]] = 1+freq;
                    else vowelFreq[word[rt]] = 1;
                }
                else nonVowel++;

                while(nonVowel>= minKReq && vowelFreq.Count==5)
                {
                    result+=n-rt;
                    if(vowel.Contains(word[lt]))
                    {
                        if(--vowelFreq[word[lt]]==0)
                            vowelFreq.Remove(word[lt]);
                    }
                    else nonVowel--;
                    
                    lt++;
                }
            }
            return result;
        }
    }
}