using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.Reorganize_String;

public class Reorganize_String
{
    public string ReorganizeString(string s) {
        var freqByChar = new Dictionary<char, int>();
        var pq = new PriorityQueue<char, int>(Comparer<int>.Create((i1, i2) => i2 - i1));
        
        foreach(var c in s) {
            if(!freqByChar.ContainsKey(c)) 
                freqByChar[c] = 0;
            
            freqByChar[c]++;
        }
        
        foreach(var kvp in freqByChar) 
            pq.Enqueue(kvp.Key, kvp.Value);
        
        
        var prevChar = '@';
        var sb = new StringBuilder();
        
        while(pq.Count > 0) {
            var currChar = pq.Dequeue();
            
            if(prevChar != '@' && freqByChar[prevChar] > 0) 
                pq.Enqueue(prevChar, freqByChar[prevChar]);
            
            sb.Append(currChar);
            freqByChar[currChar] -= 1;
            prevChar = currChar;
        }
        
        return sb.Length == s.Length ? sb.ToString() : string.Empty;
    }
}