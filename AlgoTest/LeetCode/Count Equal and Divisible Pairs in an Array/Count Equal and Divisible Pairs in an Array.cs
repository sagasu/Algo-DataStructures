namespace AlgoTest.LeetCode.Count_Equal_and_Divisible_Pairs_in_an_Array;

public class Count_Equal_and_Divisible_Pairs_in_an_Array
{
    public int CountPairs(int[] nums, int k) {
        int n = nums.Length;
        int count = 0;

        for(int i=0; i<n; i++){
            for (int j=i+1; j<n; j++){
                if(nums[i]== nums[j] && (i*j)%k ==0){
                    count++;
                }
            }
        }

        return count;

    }
}