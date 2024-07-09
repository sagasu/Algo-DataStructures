using System.Collections.Generic;

namespace AlgoTest.LeetCode.Find_the_Winner_of_the_Circular_Game;

public class Find_the_Winner_of_the_Circular_Game
{
    public int FindTheWinner(int n, int k) {
        var list = new List<int>();
        for (var i = 1; i <= n; i++)
            list.Add(i);
        
        var index = 0;
        while (list.Count > 1)
        {
            index = (index + k - 1) % list.Count;
            list.RemoveAt(index);
        }
        
        return list[0];
    }
}