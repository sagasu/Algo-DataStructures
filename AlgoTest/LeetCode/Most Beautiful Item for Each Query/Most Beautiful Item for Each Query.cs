using System;

namespace AlgoTest.LeetCode.Most_Beautiful_Item_for_Each_Query;

public class Most_Beautiful_Item_for_Each_Query
{
    public int binaryS(int[][] items,int query)
    {
        int l=0,r=items.Length-1;
        var ans=0;
        while(l<=r)
        {
            var mid=(l+r)/2;
            if(items[mid][0]<=query)
            {
                ans=items[mid][1];
                l=mid+1;
            }
            else r=mid-1;
        }
        return ans;
    }
    public int[] MaximumBeauty(int[][] items, int[] queries) {
        var ans = new int[queries.Length];
        Array.Sort(items,(a,b)=>a[0].CompareTo(b[0]));
        var mx=items[0][1];
        
        foreach (var t in items)
        {
            mx=Math.Max(mx,t[1]);
            t[1]=mx;
        }
        
        for(int i=0;i<queries.Length;i++)
            ans[i]=(binaryS(items,queries[i]));
        
        return ans;
    }
}