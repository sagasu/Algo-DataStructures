using System.Collections.Generic;

namespace AlgoTest.LeetCode.Group_the_People_Given_the_Group_Size_They_Belong_To;

public class Group_the_People_Given_the_Group_Size_They_Belong_To
{
    public IList<IList<int>> GroupThePeople(int[] groupSizes) {
        var n = groupSizes.Length;
        var map = new Dictionary<int, List<int>>();
        var result = new List<IList<int>>();

        for (var i = 0; i < n; i++) {
            if (!map.ContainsKey(groupSizes[i])) 
                map.Add(groupSizes[i], new List<int> { i });
            else 
                map[groupSizes[i]].Add(i);
            
            if (map[groupSizes[i]].Count == groupSizes[i]) {
                result.Add(map[groupSizes[i]]);
                map.Remove(groupSizes[i]);
            }
        }

        return result;
    }
}