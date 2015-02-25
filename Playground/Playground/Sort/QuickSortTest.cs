using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Playground.Sort
{
    [TestFixture]
    public class QuickSortTest
    {
        [Test]
        public void Sort_SimpleList_ShouldSort()
        {
            var elements = new List<int> {42, 534, 63, 3, 2, 23, 1};
            var sorted = new QuickSort<int>().Sort(elements, Comparer<int>.Default);

            CollectionAssert.AreEqual(new List<int>{1,2,3,23,42,63,534}, sorted);
        }

        [Test]
        public void Sort_EmptyList_ShouldReturnEmptyList()
        {
            var elements = new List<int>();
            var sorted = new QuickSort<int>().Sort(elements, Comparer<int>.Default);

            CollectionAssert.AreEqual(new List<int>(), sorted);
        }

        [Test]
        public void Sort_SingleElement_ShouldReturnSingleElement()
        {
            var elements = new List<int> { 42 };
            var sorted = new QuickSort<int>().Sort(elements, Comparer<int>.Default);

            CollectionAssert.AreEqual(new List<int> { 42 }, sorted);
        }

        [Test]
        public void Sort_TwoElements_ShouldSort()
        {
            var elements = new List<int> { 534, 63};
            var sorted = new QuickSort<int>().Sort(elements, Comparer<int>.Default);

            CollectionAssert.AreEqual(new List<int> { 63, 534 }, sorted);
        }

        [Test]
        public void Sort_ThreeElements_ShouldSort()
        {
            var elements = new List<int> { 42, 534, 63};
            var sorted = new QuickSort<int>().Sort(elements, Comparer<int>.Default);

            CollectionAssert.AreEqual(new List<int> {  42, 63, 534 }, sorted);
        }
    }
}
