namespace AlgoTest.LeetCode.Find_Kth_Bit_in_Nth_Binary_String;

public class Find_Kth_Bit_in_Nth_Binary_String
{
    public char FindKthBit(int n, int k) {
        return (char)('0' + (((k & ((k & -k) << 1)) != 0 ? 1 : 0) ^ (~k & 1)));
    }
}