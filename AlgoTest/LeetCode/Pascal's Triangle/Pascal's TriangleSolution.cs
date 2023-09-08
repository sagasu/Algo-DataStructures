using System.Collections.Generic;

namespace AlgoTest.LeetCode.Pascal_s_Triangle;

public class Pascal_s_TriangleSolution
{
    public IList<IList<int>> Generate(int numRows) {
        List<IList<int>> res = new();
        
        for(var i = 0; i < numRows; i++)
        {
            List<int> list = new();
            for(var j = 0; j <= i; j++)
            {
                if(j == 0 || j == i)
                    list.Add(1);
                else
                    list.Add(res[i-1][j-1] + res[i-1][j]);
            }
            res.Add(list);
        }
        
        return res;
    }
}