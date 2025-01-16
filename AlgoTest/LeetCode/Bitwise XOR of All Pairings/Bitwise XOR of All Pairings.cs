using System.Linq;

namespace AlgoTest.LeetCode.Bitwise_XOR_of_All_Pairings;

public class Bitwise_XOR_of_All_Pairings
{
    public int XorAllNums(int[] nums1, int[] nums2) {
        var n1 = nums1.Length;
        var n2 = nums2.Length;

        var n1even = (n1%2==0);
        var n2even = (n2%2==0);

        var answer = 0;

        if (!n1even)
        {
            answer = nums2.Aggregate(answer, (current, val) => current ^ val);
        }

        if (!n2even)
        {
            answer = nums1.Aggregate(answer, (current, val) => current ^ val);
        }

        return answer;
    }
}