using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Maximum_Score_Words_Formed_by_Letters;

public class Maximum_Score_Words_Formed_by_Letters
{
    public int MaxScoreWords(string[] words, char[] letters, int[] score) {
        var freq = new Dictionary<char, int>();
        var cache = new Dictionary<string, int>();
        var len = letters.Length;
        for(var i=0; i < len; i++)
        {
            if(!freq.ContainsKey(letters[i]))
                freq.Add(letters[i], 0);

            freq[letters[i]]++;
        }

        return BT(freq, words, 0, score, cache);
    }

    private int BT(Dictionary<char, int> freq, string[] words, int i, int[] score, Dictionary<string, int> cache){
        if(i >= words.Length)
            return 0;

        var sb = new StringBuilder();
        var currentFreq = new Dictionary<char, int>();
        foreach(var k in freq.Keys)
        {
            currentFreq.Add(k, freq[k]);
            sb.Append($"{k}{freq[k]}-");
        }

        var key = $"{i}-{sb}";
        if(cache.ContainsKey(key))
            return cache[key];
            
        var sum=0;
        var len=words[i].Length;
        var currSum=0;
        var j=0;
        for(j=0;j<len;j++)
        {
            if(!currentFreq.ContainsKey(words[i][j]) || currentFreq[words[i][j]]==0)
                break;
            
            currSum+=score[words[i][j]-'a'];
            currentFreq[words[i][j]]--;
        }

        if(j>=len)
            sum=currSum + BT(currentFreq, words, i+1, score, cache);

        sum=Math.Max(sum, BT(freq, words, i+1, score, cache));

        cache.Add(key, sum);
        return cache[key];
    }
}