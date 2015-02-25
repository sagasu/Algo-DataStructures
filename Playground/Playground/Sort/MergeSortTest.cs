using System.Collections.Generic;
using NUnit.Framework;

namespace Playground.Sort
{
    [TestFixture]
    public class MergeSortTest
    {
        [Test]
        public void Sort_FewElements_ShouldSortElements()
        {
            var elements = new List<int> {5, 6, 7, 435, 2, 23, 456, 63, 89, 2};
            var sorted = new MergeSort<int>().Sort(elements);
            CollectionAssert.AreEqual(new List<int>{2,2,5,6,7,23,63, 89,435,456}, sorted);
        }

        [Test]
        public void Sort_EmptyCollection_ShouldReturnEmptyCollection()
        {
            var elements = new List<int>();
            var sorted = new MergeSort<int>().Sort(elements);
            CollectionAssert.AreEqual(new List<int>(), sorted);
        }

        [Test]
        public void Sort_OneElement_ShouldSortElements()
        {
            var elements = new List<int> { 5,};
            var sorted = new MergeSort<int>().Sort(elements);
            CollectionAssert.AreEqual(new List<int> {5}, sorted);
        }

        [Test]
        public void Sort_TwoElements_ShouldSortElements()
        {
            var elements = new List<int> { 89, 2 };
            var sorted = new MergeSort<int>().Sort(elements);
            CollectionAssert.AreEqual(new List<int> { 2, 89}, sorted);
        }

        [Test]
        public void Sort_ThreeElements_ShouldSortElements()
        {
            var elements = new List<int> { 7, 435, 2};
            var sorted = new MergeSort<int>().Sort(elements);
            CollectionAssert.AreEqual(new List<int> { 2, 7, 435 }, sorted);
        }
    }
}
