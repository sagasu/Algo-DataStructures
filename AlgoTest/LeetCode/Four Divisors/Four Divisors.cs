namespace AlgoTest.LeetCode.Four_Divisors;

public class Four_Divisors
{
    public int SumFourDivisors(int[] nums) {
        int totalSum=0;

        foreach(int num in nums){
            int sum=0;
            int count=0;

            for(int i=1;i*i<=num;i++){

                if(num%i==0)
                {
                    count++;
                    sum+=i;

                    if(i!=num/i){
                        count++;
                        sum+=num/i;
                    }
                }

                if (count>4) break;
            }

            if(count==4){
                totalSum+=sum;
            }
        }
        return totalSum;
    }
}