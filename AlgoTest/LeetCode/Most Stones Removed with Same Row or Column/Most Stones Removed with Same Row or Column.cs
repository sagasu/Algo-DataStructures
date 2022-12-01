using System.Collections.Generic;

public class Solution15 {
    public int RemoveStones(int[][] stones) {
        
        var visited = new HashSet<(int,int)>();
        
        var Island = 0;
        

        foreach(var s in stones)
        {
            if(visited.Contains((s[0],s[1])))
            {
                continue;
            }
            var queue = new Queue<(int,int)>();

            queue.Enqueue((s[0],s[1]));
            visited.Add((s[0],s[1]));
            

            while(queue.Count != 0)
            {
                var cur = queue.Dequeue();

                foreach(var stone in stones)
                {
                    if(!visited.Contains((stone[0],stone[1])) && (stone[0] == cur.Item1 || stone[1] == cur.Item2))
                    {
                        visited.Add((stone[0],stone[1]));
                        queue.Enqueue((stone[0],stone[1]));
                    }
                }
            }
            
            
            ++Island;
            
        }
        
        return stones.Length - Island;
        

        
    }
}