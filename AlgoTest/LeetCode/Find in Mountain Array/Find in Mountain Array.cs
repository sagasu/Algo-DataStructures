namespace AlgoTest.LeetCode.Find_in_Mountain_Array;

public class MountainArray {
    public int Get(int index)
    {
        return 0;
    }

    public int Length()
    {
        return 0;
    }
}

public class Find_in_Mountain_Array
{
    public int FindInMountainArray(int target, MountainArray mountainArr) {
        var n=mountainArr.Length();
        int l=0,r=n-1;
        var peek=0;
        while(l<=r)
        {
            var mid=(l+r)/2;
            var mval=mountainArr.Get(mid);
            var left=mid>0?mountainArr.Get(mid-1):-1;
            var right=mid<n-1?mountainArr.Get(mid+1):-1;
            if(mval>left&&mval>right)
            {
                peek=mid;
                break;
            }

            if(mval>left&&mval<right) l=mid+1;
            else r=mid-1;
        }
        
        var peekval=mountainArr.Get(peek);
        if(peekval==target)return peek;
        var can=Find(target,0,peek-1,mountainArr,true);
        return can==-1?Find(target,peek+1,n-1,mountainArr,false):can;
    }
    int Find(int tar,int l,int r,MountainArray mountainArr,bool inc)
    {
        while(l<r)
        {
            var m=(l+r)/2;
            if((inc&&mountainArr.Get(m)<tar)||(!inc&&mountainArr.Get(m)>tar))
                l=m+1;
            else r=m;
        }
        
        return mountainArr.Get(l)==tar?l:-1;
    }
}