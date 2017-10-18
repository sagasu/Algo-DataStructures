using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Playground.Sort.mergeSort
{
    [TestFixture]
    class MergeSort2Tests
    {
        [TestCase(new []{4,2,3,1}, new[] { 1, 2, 3, 4 })]
        public void Sort_UnsortedArray_ExpectSorted(int[] original, int[] expected)
        {
            //Sort sorts in place, so original array is going to be sorted.
            new MergeSort2().Sort(original);
            Assert.AreEqual(expected, original);
        }
    }
}
