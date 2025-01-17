using System.Linq;

namespace AlgoTest.LeetCode.Neighboring_Bitwise_XOR;

public class Neighboring_Bitwise_XOR
{
    public bool DoesValidArrayExist(int[] derived) => derived.Aggregate((x, y) => x ^ y) == 0;
}