namespace AlgoTest.LeetCode.Smallest_Number_With_All_Set_Bits;

public class Smallest_Number_With_All_Set_Bits
{
    public int SmallestNumber(int n) =>  (1 << (32 - System.Numerics.BitOperations.LeadingZeroCount((uint)n))) - 1;
}