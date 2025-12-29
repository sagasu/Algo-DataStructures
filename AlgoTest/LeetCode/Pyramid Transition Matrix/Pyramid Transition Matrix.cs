using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Pyramid_Transition_Matrix;

public class Pyramid_Transition_Matrix
{
    public bool PyramidTransition(string bottom, IList<string> allowed) 
    {
        var failedStreamedBottom = new HashSet<string>();

        var dict = allowed
            .ToLookup(_ => _[..2], _ => _[2])
            .ToDictionary(_ => _.Key, _ => _.ToList());	

        return dfs(bottom + "#");

        bool dfs(string streamedBottom)
        {
            if(streamedBottom.Length == 1) return true;

            if(failedStreamedBottom.Contains(streamedBottom)) return false;
            
            if(streamedBottom[1] == '#') 
                return dfs(streamedBottom[2..] + "#");
            
            if(dict.TryGetValue(streamedBottom[..2], out var variants))
            {
                foreach(var c in variants)
                    if(dfs(streamedBottom[1..] + c)) return true;
            }

            return !failedStreamedBottom.Add(streamedBottom);
        }
    }
}