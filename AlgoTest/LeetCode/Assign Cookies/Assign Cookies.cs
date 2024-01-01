using System;

namespace AlgoTest.LeetCode.Assign_Cookies;

public class Assign_Cookies
{
    public int FindContentChildren(int[] g, int[] s) {
        Array.Sort(g);
        Array.Sort(s);

        var cookie = 0;
        var green = 0;
        var result = 0;
        while (green < g.Length && cookie < s.Length)
        {
            if (s[cookie] >= g[green])
            {
                result++;
                green++;
            }

            cookie++;
        }

        return result;
    }
}