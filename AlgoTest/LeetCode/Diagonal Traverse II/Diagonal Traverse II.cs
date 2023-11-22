using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Diagonal_Traverse_II;

[TestClass]
public class Diagonal_Traverse_II
{
    [TestMethod]
    public void Test() => Assert.IsTrue(FindDiagonalOrder(new List<IList<int>>
    {
        new List<int> { 1, 2, 3, 4, 5 },
        new List<int> { 6, 7 },
        new List<int> { 8 },
        new List<int> { 9, 10, 11 },
        new List<int> { 12, 13, 14, 15, 16 },
    }) is [1,6,2,8,7,3,9,4,12,10,5,13,11,14,15,16]);
        
    public int[] FindDiagonalOrder(IList<IList<int>> nums)
    {
        var queue = new Queue<KeyValuePair<int, int>>();
        queue.Enqueue(new KeyValuePair<int, int>(0, 0));
        var ans = new List<int>();
        
        while (queue.Count > 0) {
            var p = queue.Dequeue();
            var row = p.Key;
            var col = p.Value;
            ans.Add(nums[row][col]);
            
            if (col == 0 && row + 1 < nums.Count) 
                queue.Enqueue(new KeyValuePair<int, int>(row + 1, col));
            
            if (col + 1 < nums[row].Count) 
                queue.Enqueue(new KeyValuePair<int, int>(row, col + 1));
        }
        
        return ans.ToArray();     
    }
}