using System.Collections.Generic;

namespace AlgoTest.LeetCode.Design_Skiplist;

public class Skiplist
{
    SortedDictionary<int,int> sortedDict = new();
    public Skiplist() {
    
    }

    public bool Search(int target) => sortedDict.ContainsKey(target);

    public void Add(int num) {
        if(!sortedDict.TryAdd(num,1))
            sortedDict[num]+=1;
    }

    public bool Erase(int num) {
        if(sortedDict.ContainsKey(num))
        {
            if(sortedDict[num]>1)
                sortedDict[num]-=1;
            else
                sortedDict.Remove(num);
            
            return true;
        }
        return false;
    }
}