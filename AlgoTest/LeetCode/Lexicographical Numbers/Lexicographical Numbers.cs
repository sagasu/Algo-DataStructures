using System.Collections.Generic;

namespace AlgoTest.LeetCode.Lexicographical_Numbers;

public class Lexicographical_Numbers
{
    public IList<int> LexicalOrder(int n) {        
        var ret = new List<int>();
        dfs(1, ret, n);
        return ret;
    }
    
    public void dfs(int current, List<int> res, int n) {
        if (current > n) return;
        res.Add(current);
        dfs(10*current, res, n);
        if ((current + 1) % 10 != 0) dfs(current+1, res, n);
    }
}