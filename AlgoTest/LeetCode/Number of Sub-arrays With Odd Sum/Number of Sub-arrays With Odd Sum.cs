namespace AlgoTest.LeetCode.Number_of_Sub_arrays_With_Odd_Sum;

public class Number_of_Sub_arrays_With_Odd_Sum
{
    public int NumOfSubarrays(int[] arr) {
        int sum=0,cnt=0;
        long evens=1, odds=0, res=0;
        foreach(var n in arr){
            sum+=n;            
            if((sum&1)==0){
                evens++;
                res=(res+odds)%1000000007;                
            }
            else{
                res=(res+evens)%1000000007;
                odds++;                
            }
        }
        return (int)res;
    }
}