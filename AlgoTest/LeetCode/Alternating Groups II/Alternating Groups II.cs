using System.Collections.Generic;

namespace AlgoTest.LeetCode.Alternating_Groups_II;

public class Alternating_Groups_II
{
    public int NumberOfAlternatingGroups(int[] colors, int k) {
        var temp = new List<int>(colors);
        temp.AddRange(colors[..(k - 1)]);
        
        int count = 0;
        int left = 0;
        
        for (int right = 0; right < temp.Count; right++) {
            if (right > 0 && temp[right] == temp[right - 1]) {
                left = right;  
            }
            
            if (right - left + 1 >= k) {
                count++; 
            }
        }
        
        return count;
    }
}