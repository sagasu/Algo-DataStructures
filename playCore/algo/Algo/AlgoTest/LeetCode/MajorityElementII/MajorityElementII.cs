using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.MajorityElementII
{
    [TestClass]
    public class MajorityElementII
    {
        [TestMethod]
        public void Test()
        {
            //MajorityElement(new int[] {1, 2});
            MajorityElement(new int[] {2, 2});
        }

        public IList<int> MajorityElement(int[] nums)
        {
            if (nums == null)
                return nums;

            var number = nums.Length / 3;
            if (number == 0)
                return nums.Distinct().ToList();

            var ele = new List<int>();
            var set = new Dictionary<int,int>();

            foreach (var num in nums)
            {
                if (!set.TryAdd(num, 1))
                {
                    set[num] += 1;
                    if(set[num] > number)
                    {
                        ele.Add(num);
                        set[num] = int.MinValue;
                    }
                }
                

            }

            return ele;

        }
    }
}
