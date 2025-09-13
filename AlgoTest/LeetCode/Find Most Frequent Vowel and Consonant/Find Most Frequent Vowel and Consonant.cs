using System.Collections.Generic;

namespace AlgoTest.LeetCode.Find_Most_Frequent_Vowel_and_Consonant;

public class Find_Most_Frequent_Vowel_and_Consonant
{
    public int MaxFreqSum(string s) {
        Dictionary<char,int> freq=new Dictionary<char,int>();
        HashSet<char> vowels=new HashSet<char>(){'a','e','i','o','u'};

        int vowelsMax=0;
        int consMax=0;
        foreach(char ch in s)
        {
            freq.TryAdd(ch,0);
            int chFreq=++freq[ch];            
            if(vowels.Contains(ch))
            {
                if(chFreq>vowelsMax)
                {
                    vowelsMax=chFreq;
                }
            }
            else
            {
                if(chFreq>consMax)
                {
                    consMax=chFreq;
                }
            }
        } 
      
        return consMax+vowelsMax;
       
    }
}