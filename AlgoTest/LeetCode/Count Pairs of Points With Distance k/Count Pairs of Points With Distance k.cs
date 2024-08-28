using System.Collections.Generic;

namespace AlgoTest.LeetCode.Count_Pairs_of_Points_With_Distance_k;

public class Count_Pairs_of_Points_With_Distance_k
{
    public int CountPairs(IList<IList<int>> coordinates, int k) {
        var count = 0;
        var map = new Dictionary<(int,int),int>();
        foreach (var t in coordinates)
        {
            var x1 = t[0];
            var y1 = t[1];
            var key1 = (x1,y1);
            for (var j = 0; j <= k; j++){
                var x2 = x1^j;
                var y2 = y1^(k-j);
                var key2 = (x2,y2);
                if (map.ContainsKey(key2))
                    count += map[key2];
                
            }
            if (!map.ContainsKey(key1)) map.Add(key1, 0);
            map[key1]++;
        }
        return count;
    }
}