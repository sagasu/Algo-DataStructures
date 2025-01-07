using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.String_Matching_in_an_Array;

public class String_Matching_in_an_Array
{
    public IList<string> StringMatching(string[] words) => words.Where(w => words.Any(a => a.Contains(w) && a.Length > w.Length)).ToList();
    
}