using System.Collections.Generic;

namespace AlgoTest.LeetCode.Avoid_Flood_in_The_City;

public class Avoid_Flood_in_The_City
{
    public int[] AvoidFlood(int[] rains)
    {
        var dryDays = new LinkedList<int>();
        var lakeFullDays = new Dictionary<int, int>();

        for(var i =  0; i < rains.Length; i++)
        {
            var lake = rains[i];

            if(lake == 0)
            {                
                dryDays.AddLast(i);
            }
            else
            {
                if(lakeFullDays.TryGetValue(lake, out var day))
                {
                    var isDry = false;
                    foreach(var dryDay in dryDays)
                    {
                        if(dryDay > day)
                        {
                            rains[dryDay] = lake;
                            dryDays.Remove(dryDay);
                            isDry = true;
                            break;
                        }
                    }
                    if(!isDry)
                    {
                        return [];
                    }
                }
                lakeFullDays[lake] = i;
                rains[i] = -1;
            }
        }

        foreach(var d in dryDays)
        {
            rains[d] = 1;
        }

        return rains;
    }
}