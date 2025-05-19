namespace AlgoTest.LeetCode.Type_of_Triangle;

public class Type_of_Triangle
{
    public string TriangleType(int[] nums)
    {
        if (nums[0] + nums[1] <= nums[2] ||  nums[2] + nums[1] <= nums[0] ||  nums[2] + nums[0] <= nums[1])
            return "none";
        
        if(nums[0] == nums[1] &&  nums[2] == nums[1])
            return "equilateral";
        
        if(nums[0] == nums[1] ||  nums[2] == nums[1] ||  nums[2] == nums[0])
            return "isosceles";
        
        return "scalene";
    }
}