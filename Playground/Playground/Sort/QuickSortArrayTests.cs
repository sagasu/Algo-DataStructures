using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Playground.Sort
{
    [TestFixture]
    class QuickSortArrayTests
    {
        [Test]
        public void Sort_EmptyList_ShouldReturnEmptyList()
        {
            var qs = new QuickSortArray<int>();
            Assert.AreEqual(Enumerable.Empty<int>(),qs.Sort(new List<int>()));
        }

        [Test]
        public void Sort_OneElement_ShouldReturnOneElement()
        {
            var qs = new QuickSortArray<int>();
            var elements = new List<int> {3};
            Assert.AreEqual(new List<int>{3}, qs.Sort(elements));
        }

        [Test]
        public void Sort_TwoElements_ShouldSort()
        {
            var qs = new QuickSortArray<int>();

            var elements = new List<int> { 3,4 };
            Assert.AreEqual(new List<int> { 3,4 }, qs.Sort(elements));

            elements = new List<int> { 4,3 };
            Assert.AreEqual(new List<int> { 3, 4 }, qs.Sort(elements));
        }

        [Test]
        public void Sort_MultipleElements_ShouldSort()
        {
            var qs = new QuickSortArray<int>();
            var elements = new List<int> { 3,2,55,23,23,1,534,3,444 };
            Assert.AreEqual(new List<int> { 1,2,3,3,23,23,55,444,534 }, qs.Sort(elements));
        }
    }
}
