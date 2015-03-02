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
    }
}
