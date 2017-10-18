using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Playground.Sort.mergeSort
{
    [TestFixture]
    class MergeSort3Tests
    {
        [TestCase(new []{4,2,3,1}, new[] { 1, 2, 3, 4 })]
        [TestCase(new []{4,22,3,11,7}, new[] { 3, 4, 7, 11, 22 })]
        [TestCase(new []{432,23333,13,1}, new[] { 1, 13, 432, 23333 })]
        [TestCase(new []{1,2,3,4,5}, new[] { 1, 2, 3, 4,5 })]
        public void Sort_UnsortedArray_ExpectSorted(int[] original, int[] expected)
        {
            //Sort sorts in place, so original array is going to be sorted.
            new MergeSort3().Sort(original);
            Assert.AreEqual(expected, original);
        }
    }
}
