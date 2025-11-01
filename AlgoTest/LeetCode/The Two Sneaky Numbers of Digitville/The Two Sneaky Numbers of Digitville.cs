namespace AlgoTest.LeetCode.The_Two_Sneaky_Numbers_of_Digitville;

public class The_Two_Sneaky_Numbers_of_Digitville
{
    public int[] GetSneakyNumbers(int[] nums)
    {
        int index = -1;
        int[] ans = new int[2];
        bool[] isDuplicate = new bool[nums.Length - 2];

        for (int i = 0; i < nums.Length; i++)
        {
            if (isDuplicate[nums[i]])
            {
                index++;
                ans[index] = nums[i];

                continue;
            }

            isDuplicate[nums[i]] = true;
        }

        return ans;
    }
    
}