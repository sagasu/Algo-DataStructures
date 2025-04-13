namespace AlgoTest.LeetCode.Count_Good_Numbers;

public class Count_Good_Numbers
{
    public int CountGoodNumbers(long n) {
        const int mod=(int)1e9+7;
        int count=1+(int)((n&1)<<2); 
        int mul=20;
        for(n>>=1;; mul=(int)((long)mul*mul%mod)) {
            if((n&1)>0) count=(int)((long)count*mul%mod);
            if((n>>=1)==0) return count;
        }
    }
}