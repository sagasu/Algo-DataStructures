using System.Collections.Generic;

namespace AlgoTest.LeetCode.Smallest_Range_Covering_Elements_from_K_Lists;

public class Smallest_Range_Covering_Elements_from_K_Lists
{
    public int[] SmallestRange(IList<IList<int>> nums) {
        int m = nums.Count, n = nums[0].Count;
        
        var heap = new SortedSet<(int val, int i, int j)>();
        
        for(int i=0; i<m; i++)
            heap.Add((nums[i][0], i, 0));
			
        int rangeMin = 0, rangeMax = int.MaxValue;
        
        while(heap.Count > 0){
            var min = heap.Min;
            var max = heap.Max;
            if(rangeMax - rangeMin > max.val - min.val){
                rangeMin  = min.val;
                rangeMax = max.val;
            }
            heap.Remove(min);
            var nextI = min.i;
            var nextJ = min.j + 1;
            if(nextJ == nums[nextI].Count)
                return new int[] {rangeMin, rangeMax};
            
            heap.Add((nums[nextI][nextJ], nextI, nextJ));
        }
        return new int[0];
    }
}