namespace AlgoTest.LeetCode.Number_of_Ways_to_Stay_in_the_Same_Place_After_Some_Steps;

public class Number_of_Ways_to_Stay_in_the_Same_Place_After_Some_Steps
{
    public int NumWays(int steps, int arrLen) {
        var mod=(int)1e9+7;
        var dp=new long[arrLen];
        dp[0]=1;
        
        while(steps-->0)
        {
            var tmp=new long[dp.Length];
            for(int i=0;i<dp.Length;i++)
            {
                var left=i-1>=0?dp[i-1]:0;
                var right=i+1<dp.Length?dp[i+1]:0;
                tmp[i]=(dp[i]+left+right)%mod;
                
                if(tmp[i]==0)break;
            }
            
            dp=tmp;
        }
        
        return (int)dp[0];
    }
}