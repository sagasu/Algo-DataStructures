using System.Collections.Generic;

namespace AlgoTest.LeetCode.Design_a_Number_Container_System;

public class NumberContainers
{
    private Dictionary<int,int> map = new();
    private Dictionary<int,SortedSet<int>> set = new();
    public NumberContainers() {
        
    }
    
    public void Change(int index, int number) {
        if(map.ContainsKey(index) && map[index] == number)
            return;
        if(map.ContainsKey(index) && map[index] != number)
        {
            set[map[index]].Remove(index);
            map[index] = number;
            set.TryAdd(number,new());
            set[number].Add(index);
        }
        else
        {
            map[index] = number;
            set.TryAdd(number,new());
            set[number].Add(index);
        }
    }
    
    public int Find(int number) {
        return set.ContainsKey(number) 
               && set[number].Count > 0? set[number].Min : -1;
    }
}