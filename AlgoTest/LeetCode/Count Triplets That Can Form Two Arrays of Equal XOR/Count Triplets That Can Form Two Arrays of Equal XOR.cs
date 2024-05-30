namespace AlgoTest.LeetCode.Count_Triplets_That_Can_Form_Two_Arrays_of_Equal_XOR;

public class Count_Triplets_That_Can_Form_Two_Arrays_of_Equal_XOR
{
    public int CountTriplets(int[] arr) {
        int len=arr.Length, count=0;

        for(var i=0;i<len-1;i++)
        {
            var a=0;
            for(var j=i;j<len-1;j++)
            {
                a^=arr[j];
                var b=0;
                for(var k=j+1;k<len;k++)
                {
                    b^=arr[k];
                    if(a==b)
                        count++;
                }
            }
        }

        return count;
    }
}