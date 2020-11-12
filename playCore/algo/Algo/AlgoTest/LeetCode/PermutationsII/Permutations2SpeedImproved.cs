using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.PermutationsII
{
    [TestClass]
    public class Permutations2SpeedImproved
    {
        [TestMethod]
        public void Test()
        {
            //var t = new int[] {1, 1, 2};
            //PermuteUnique(t);
            /*
               [[1,1,2],
                [1,2,1],
                [2,1,1]]
             */

            //var t = new int[] { 1, 1 };
            //PermuteUnique(t);

            
            var t = new int[] { 3, 3, 0, 3};
            PermuteUnique(t);


        }

        // The biggest problem is to get rid of elements that have same value, but have a different index otherwise for a set [1,1,2] we will have [1,1,2] and [1,1,2]
        // To achieve this we sort it and ignore elements that have same value. But please notice that this ignoring while loop is after we set up recursion. 
        // This while will not work if it is before adding to used/permutations lists.
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> ret = new List<IList<int>>();
            Array.Sort(nums);

            void SetPermutations(IList<int> permutations, IList<int> used)
            {
                if (permutations.Count == nums.Length)
                {
                    ret.Add(new List<int>(permutations));
                    return;
                }

                for (var i = 0; i < nums.Length; i++)
                {
                    if (!used.Contains(i))
                    {
                        permutations.Add(nums[i]);
                        used.Add(i);
                        SetPermutations(permutations, used);
                        used.RemoveAt(used.Count -1);
                        permutations.RemoveAt(permutations.Count-1);

                        // this while will not work, because it will ignore scenario [1,1]
                        //while (i < nums.Length - 2 && nums[i] == nums[i + 1])

                        while (i + 1 < nums.Length && nums[i] == nums[i + 1])
                            i++;
                    }

                    
                }
            }

            SetPermutations(new List<int>(), new List<int>());
            return ret;
        }
    }
}
