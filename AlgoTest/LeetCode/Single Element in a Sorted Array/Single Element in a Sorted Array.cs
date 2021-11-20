using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoTest.LeetCode.Single_Element_in_a_Sorted_Array
{
    class SingleElementinaSortedArray
    {
        public int SingleNonDuplicate(int[] nums)
        {
            var ans = 0;
            var numsCount = (from num in nums
                group num by num into numGrp
                orderby numGrp.Count() ascending
                select numGrp.Key).ToList();

            return numsCount[0];
        }
    }
}
