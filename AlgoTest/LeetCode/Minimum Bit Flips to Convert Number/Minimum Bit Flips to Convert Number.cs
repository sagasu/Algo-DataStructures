namespace AlgoTest.LeetCode.Minimum_Bit_Flips_to_Convert_Number;

public class Minimum_Bit_Flips_to_Convert_Number
{
    public int MinBitFlips(int x, int y) => int.PopCount(x ^ y);
}