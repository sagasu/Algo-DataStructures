namespace AlgoTest.LeetCode.Minimum_One_Bit_Operations_to_Make_Integers;

public class Minimum_One_Bit_Operations_to_Make_Integers
{
    public int MinimumOneBitOperations(int n) {
        if (n == 0) return 0;
        
        var k = 0;
        var curr = 1;
        while (curr * 2 <= n) {
            curr *= 2;
            k++;
        }
        
        return (1 << (k + 1)) - 1 - MinimumOneBitOperations(n ^ curr);
    }
}