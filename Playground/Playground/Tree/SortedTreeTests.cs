using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Playground.Tree
{
    [TestFixture]
    class SortedTreeTests
    {
        [Test]
        public void Add_OneElement_ShouldReturnWhenTravers()
        {
            var st = new SortedTree<int>();
            st.Add(3);

            CollectionAssert.AreEqual(new List<int> { 3 }, st.Traverse());
        }

        [Test]
        public void Travers_EmptyList_ShouldReturnEmptyCollection()
        {
            var st = new SortedTree<int>();

            CollectionAssert.AreEqual(new List<int>(), st.Traverse());
        }

        [Test]
        public void AddRage_MultipleElements_ShouldSortWhenTravers()
        {
            var st = new SortedTree<int>();
            st.AddRange(new List<int> { 3, 23, 52, 1, 44, 11, 9 });

            CollectionAssert.AreEqual(new List<int> { 1,3,9,11,23,44,52 }, st.Traverse());
        }

        [Test]
        public void AddRange_TwoSameElements_ShouldThrowArgumentException()
        {
            var st = new SortedTree<int>();
            
            Assert.Throws<ArgumentException>(() => st.AddRange(new List<int> { 3, 23, 3, }));
        }

        [Test]
        public void AddRange_NullPassedAsElements_ShouldThrowArgumentException()
        {
            var st = new SortedTree<int>();
            Assert.Throws<ArgumentException>(() => st.AddRange(null));
        }


        [Test]
        public void Add_OneElementAlternativeTraverse_ShouldReturnWhenTravers()
        {
            var st = new SortedTree<int>(true);
            st.Add(3);

            CollectionAssert.AreEqual(new List<int> { 3 }, st.Traverse());
        }

        [Test]
        public void Travers_EmptyListAlternativeTraverse_ShouldReturnEmptyCollection()
        {
            var st = new SortedTree<int>(true);

            CollectionAssert.AreEqual(new List<int>(), st.Traverse());
        }

        [Test]
        public void AddRage_MultipleElementsAlternativeTraverse_ShouldSortWhenTravers()
        {
            var st = new SortedTree<int>(true);
            st.AddRange(new List<int> { 3, 23, 52, 1, 44, 11, 9 });

            CollectionAssert.AreEqual(new List<int> { 1, 3, 9, 11, 23, 44, 52 }, st.Traverse());
        }

        [Test]
        public void AddRange_TwoSameElementsAlternativeTraverse_ShouldThrowArgumentException()
        {
            var st = new SortedTree<int>(true);

            Assert.Throws<ArgumentException>(() => st.AddRange(new List<int> { 3, 23, 3, }));
        }

        [Test]
        public void AddRange_NullPassedAsElementsAlternativeTraverse_ShouldThrowArgumentException()
        {
            var st = new SortedTree<int>(true);
            Assert.Throws<ArgumentException>(() => st.AddRange(null));
        }

        [Test]
        public void Remove_AddThreeElementsRemoveOne_ShouldRemoveElement()
        {
            var st = new SortedTree<int>(true);
            st.Add(2);
            st.Add(4);
            st.Add(1);
            st.Remove(1);

            CollectionAssert.AreEqual(new List<int> { 2,4 }, st.Traverse());
        }
    }
}
