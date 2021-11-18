using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Find_All_Numbers_Disappeared_in_an_Array
{
    class Find_All_Numbers_Disappeared_in_an_Array
    {
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            for (var i = 0; i < nums.Length; i++)
                while (nums[i] != i + 1)
                {
                    var value = nums[i];

                    if (nums[value - 1] == value) break;

                    nums[i] = nums[value - 1];
                    nums[value - 1] = value;
                }
            

            var result = new List<int>();

            for (var i = 0; i < nums.Length; i++)
                if (nums[i] != i + 1) result.Add(i + 1);
            
            return result;
        }
    }
}
