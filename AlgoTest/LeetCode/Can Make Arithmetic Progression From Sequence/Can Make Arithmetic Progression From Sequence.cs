using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTest.LeetCode.Can_Make_Arithmetic_Progression_From_Sequence
{
    internal class Can_Make_Arithmetic_Progression_From_Sequence
    {
        public bool CanMakeArithmeticProgression(int[] arr)
        {
            if (arr.Length <= 1) return true;
            Array.Sort(arr);

            for (var i = 2; i < arr.Length; i++)
                if (arr[i - 1] - arr[i - 2] != arr[i] - arr[i - 1])
                    return false;
            
            return true;
        }
    }
}
