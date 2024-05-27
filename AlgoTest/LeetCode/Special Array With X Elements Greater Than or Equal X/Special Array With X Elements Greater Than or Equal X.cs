using System.Linq;

namespace AlgoTest.LeetCode.Special_Array_With_X_Elements_Greater_Than_or_Equal_X;

public class Special_Array_With_X_Elements_Greater_Than_or_Equal_X
{
    public int SpecialArray(int[] nums) {
        var low = 0;
        var high = nums.Max();

        while (low <= high)
        {
            var mid = low + (high - low) / 2;

            var count = nums.Count(x=>x>=mid);

            if (count == mid) return mid;

            if (count > mid)
                low = mid+1;
            else
                high = mid-1;
        }

        return -1;
    }
}