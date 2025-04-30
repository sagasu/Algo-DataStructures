namespace AlgoTest.LeetCode.Find_Numbers_with_Even_Number_of_Digits;

public class Find_Numbers_with_Even_Number_of_Digits
{
    public int FindNumbers(int[] nums) {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int num = Math.Abs(nums[i]).ToString().Length;
                if ((num & 1) == 0) count++;
            }
            return count;
        }
}