namespace AlgoTest.LeetCode.Find_Minimum_Operations_to_Make_All_Elements_Divisible_by_Three;

public class Find_Minimum_Operations_to_Make_All_Elements_Divisible_by_Three
{
    public int MinimumOperations(int[] nums) {
        int operations = 0;

        foreach (int num in nums) {
            if (num % 3 != 0) {
                operations++;
            }
        }

        return operations;
    }
}