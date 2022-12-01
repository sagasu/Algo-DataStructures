using System.Collections.Generic;
using System.Linq;

public class Solution12 {
    public int MinMutation(string start, string end, string[] bank) {
        var queue = new Queue<string>();
        var visited = new HashSet<string>();
        
        queue.Enqueue(start);
        var mutationsCount = 0;
        
        while(queue.Count > 0)
        {
            var count = queue.Count;
            for(var i = 0; i < count; i++)
            {
                var gene = queue.Dequeue();
                if(gene == end)
                {
                    return mutationsCount;
                }

                foreach(var mutation in bank.Where(x => !visited.Contains(x)))
                {
                    var diff = CountDiff(gene, mutation);
                    if(diff != 1)
                    {
                        continue;
                    }
                    visited.Add(mutation);
                    queue.Enqueue(mutation);
                }
            }
            mutationsCount++;
        }
        return -1;
        
        int CountDiff(string first, string second) => first.Zip(second, (x, y) => x != y ? 1 : 0).Sum();
    }
}