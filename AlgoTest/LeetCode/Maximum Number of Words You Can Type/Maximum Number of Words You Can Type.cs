using System.Collections.Generic;

namespace AlgoTest.LeetCode.Maximum_Number_of_Words_You_Can_Type;

public class Maximum_Number_of_Words_You_Can_Type
{
    public int CanBeTypedWords(string text, string brokenLetters) {
        int count=0;
        var hs = new HashSet<char>();
        foreach(char b in brokenLetters){
            hs.Add(b);
        }

        string[] words = text.Split(" ");
        foreach(string s in words){
            if(containsNoBroken(s,hs)) count++;
        }

        return count;
        
    }
    bool containsNoBroken(string s, HashSet<char> hs){
        foreach(char c in s){
            if(hs.Contains(c)) return false;
        }
        return true;
    }
}