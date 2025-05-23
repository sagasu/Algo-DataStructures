using System.Collections.Generic;

public class Solution2323
{
    public int GetCommon(int[] nums1, int[] nums2)
    {
        HashSet<int> set = new HashSet<int>(nums1);

        foreach (int num in nums2)
        {
            if (set.Contains(num))
            {
                return num;
            }
        }

        return -1;
    }
}
