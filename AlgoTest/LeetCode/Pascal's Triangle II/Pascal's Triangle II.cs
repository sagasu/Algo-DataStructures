using System.Collections.Generic;

namespace AlgoTest.LeetCode.Pascal_s_Triangle_II;

public class Pascal_s_Triangle_II
{
    public IList<int> GetRow(int rowIndex) {
        var pre = new List<int>() { 1 };
        if (rowIndex == 0) return pre;

        for (int i = 1; i <= rowIndex; i++) {
            var oneResult = new List<int>();
            oneResult.Add(1);

            for (int j = 0; j < pre.Count - 1; j++) 
                oneResult.Add(pre[j] + pre[j + 1]);
            
            oneResult.Add(1);

            pre = oneResult;
        }

        return pre;
    }
}