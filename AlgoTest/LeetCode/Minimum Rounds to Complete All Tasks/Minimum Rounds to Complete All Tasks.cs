using System;
using System.Linq;

public class MinimumRoundsSolution
{
    public int MinimumRounds(int[] tasks) {
        var freq = tasks.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());	// group
	if (freq.Any(x => x.Value < 2)) // Check if invalid
		return -1; 
	int result = 0;
	foreach (var kvp in freq) 
		result += (int)Math.Ceiling((decimal)kvp.Value / (decimal)3);
	return result;
    }
}