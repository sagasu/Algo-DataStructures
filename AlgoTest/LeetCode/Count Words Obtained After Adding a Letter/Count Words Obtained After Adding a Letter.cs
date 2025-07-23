using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Count_Words_Obtained_After_Adding_a_Letter;

public class Count_Words_Obtained_After_Adding_a_Letter
{
    public int WordCount(string[] startWords, string[] targetWords) {
        int count = 0;
        HashSet<string> startSet = new HashSet<string>();

        foreach(string word in startWords){
            char[] arr = word.ToCharArray();
            Array.Sort(arr);
            startSet.Add(new string(arr));
        }

        foreach(string word in targetWords){
            char[] arr = word.ToCharArray();
            Array.Sort(arr);
            string target = new string(arr);

            for(int i = 0; i < target.Length; i++){
                string candidate = target.Remove(i,1);
                if(startSet.Contains(candidate)){
                    count++;
                    break;
                }
            }
        }

        return count;
    }
}