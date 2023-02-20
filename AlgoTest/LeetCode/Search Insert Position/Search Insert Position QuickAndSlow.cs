public class Search_Insert_Position
{
    // this is O(n) but leetcode approves it :)
    public int SearchInsert(int[] nums, int target)
    {
        for (var i = 0; i < nums.Length; i++)
            if (nums[i] >= target) return i;
        return nums.Length;
    }
}