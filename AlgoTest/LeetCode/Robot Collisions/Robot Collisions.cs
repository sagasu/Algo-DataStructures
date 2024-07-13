using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Robot_Collisions;

public class Robot_Collisions
{
    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
    {
        var n = positions.Length;
        Span<(int, int, char, int)> arr = stackalloc (int, int, char, int)[n];
        
        for (var i = 0; i < n; i++)
            arr[i] = (positions[i], healths[i], directions[i], i);
        
        arr.Sort((a, b) => a.Item1.CompareTo(b.Item1));
        var res = new List<(int, int)>();
        var carry = new LinkedList<(int, int)>();
        
        for (var i = 0; i < n; i++)
        {
            var curHP = arr[i].Item2;
            var curInd = arr[i].Item4;
            if (arr[i].Item3 == 'L')
            {
                if (carry.Count == 0) res.Add((curHP, curInd));
                else
                {
                    while (carry.Count > 0)
                    {
                        var (hp, ind) = carry.Last.Value;
                        carry.RemoveLast();
                        if (hp < curHP) --curHP;
                        else if (hp == curHP) goto Next;
                        else
                        {
                            carry.AddLast((hp - 1, ind));
                            goto Next;
                        }
                    }
                    res.Add((curHP, curInd));
                }
            }
            else
                carry.AddLast((curHP, curInd));
            Next:;
        }
        
        while (carry.Count > 0) 
        {
            res.Add(carry.First.Value);
            carry.RemoveFirst();
        }
        
        res.Sort((a, b) => a.Item2.CompareTo(b.Item2));
        var resEn = from one in res select one.Item1;
        return resEn.ToArray();
    }
}