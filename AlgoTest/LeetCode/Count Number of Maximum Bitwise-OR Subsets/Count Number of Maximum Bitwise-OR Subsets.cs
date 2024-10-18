namespace AlgoTest.LeetCode.Count_Number_of_Maximum_Bitwise_OR_Subsets;

public class Count_Number_of_Maximum_Bitwise_OR_Subsets
{
    int sum;
    int count;

    public void Rec(int[] nums, int cur, int index){
        cur |= nums[index];
        if (cur == sum) count++;
        for (int i = index+1; i < nums.Length; i++){
            Rec(nums, cur, i);
        }
    }

    public int CountMaxOrSubsets(int[] nums) {
        sum = 0;
        count = 0;
        foreach (int num in nums) sum |= num;
        for (int i = 0; i < nums.Length; i++) Rec(nums, 0, i);
        return count;
    }
}