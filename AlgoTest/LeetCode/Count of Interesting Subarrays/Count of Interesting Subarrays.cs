using System.Collections.Generic;

namespace AlgoTest.LeetCode.Count_of_Interesting_Subarrays;

public class Count_of_Interesting_Subarrays
{
    public long CountInterestingSubarrays(IList<int> num, int modulo, int k) {
        var nums = new int[num.Count];
        for(var i=0;i<num.Count;i++){
            var temp=num[i];
            nums[i]=temp % modulo;
        }
        
        var right=0;
        long total=0;
        long count=0;
        var map=new Dictionary<long,long>();
        map.Add(0l,1l);
        for(;right<nums.Length;right++){
            if(nums[right]==k) count++;
            
            count%=modulo;
            
            long temp=0;
            if(count==k) temp=0;
            else if(count<k) temp=modulo-k+count;
            else temp=count-k;
            
            if(map.ContainsKey(temp)) total+=map[temp];
            
            if(!map.TryAdd(count, 1l)) map[count] += 1;
        }
        
        return total;
    }
    
}