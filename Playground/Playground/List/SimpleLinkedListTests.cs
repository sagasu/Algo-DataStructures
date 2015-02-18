using System.Linq;
using NUnit.Framework;

namespace Playground.List
{
    [TestFixture]
    public class SimpleLinkedListTests
    {
        [Test]
        public void Add_SingleElementToList_ShouldBeAbleToRetriveIt()
        {
            var sll = new SimpleLinkedList<bool> {true};

            Assert.AreEqual(1, sll.Count());
            Assert.AreEqual(true, sll.First());
        }

        [Test]
        public void Add_ThreeElementsToList_ShouldBeAbleToRetriveIt()
        {
            var sll = new SimpleLinkedList<bool> {true, true, false};

            Assert.AreEqual(3, sll.Count());
            Assert.AreEqual(true, sll.First());
            Assert.AreEqual(true, sll.Skip(1).First());
            Assert.AreEqual(false, sll.Last());
        }

        [Test]
        public void Add_ElementByIndex_ShouldBeAbleToRetriveIt()
        {
            var sll = new SimpleLinkedList<bool> {true, true, true, {false, 1}};

            Assert.AreEqual(4, sll.Count());
            Assert.AreEqual(true, sll.First());
            Assert.AreEqual(false, sll.Skip(1).First());
            Assert.AreEqual(true, sll.Skip(2).First());
            Assert.AreEqual(true, sll.Last());
        }

        [Test]
        public void Add_ElementByIndexZero_ShouldBeAbleToRetriveIt()
        {
            var sll = new SimpleLinkedList<bool> { { true, 0 } };

            Assert.AreEqual(1, sll.Count());
            Assert.AreEqual(true, sll.First());
        }

        [Test]
        public void Remove_SingleElement_ShouldWork()
        {
            var sll = new SimpleLinkedList<bool> { true };
            sll.Remove(0);

            Assert.AreEqual(0, sll.Count());
        }
    }
}
