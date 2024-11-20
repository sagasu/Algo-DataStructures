namespace AlgoTest.LeetCode.Minimum_Array_End;

public class Minimum_Array_End
{
    public long MinEnd(int n, int x) {
        n--;
        long result=x, mask=1;
        for(var nbit=0; nbit<30; mask<<=1)
            if((result & mask)==0 && (n & 1<<nbit++)!=0)
                result |= mask;
        return result;
    }
}